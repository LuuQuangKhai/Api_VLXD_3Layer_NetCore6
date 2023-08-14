using VatLieuXayDung_3Layer_Api.Models.InputModel;
using VatLieuXayDung_3Layer_Api.Models;
using System.Security.Authentication;
using VatLieuXayDung_3Layer_Api.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VatLieuXayDung_3Layer_Api.Models.OutputModel;

namespace VatLieuXayDung_3Layer_Api.Services
{
    public interface IChiTietDonHangService
    {
        public Task<ICollection<ChiTietDonHang>> GetAll();
        public Task<ICollection<ChiTietDonHang>> GetByMaDonHang(int madonhang);
        public Task<ChiTietDonHang> GetByMaDonHangMaSanPham(int madonhang,int masanpham);
        public Task CreateChiTietDonHang(ChiTietDonHangInput ct);
        public Task UpdateChiTietDonHang(int madonhang,int masanpham, ChiTietDonHangInput ct);
        public Task DeleteChiTietDonHang(int madonhang,int masanpham);
    }
    public class ChiTietDonHangService : IChiTietDonHangService
    {
        private readonly ChiTietDonHangRepository _chitietdonhangRepository;
        private readonly IMapper _mapper;

        public ChiTietDonHangService(ChiTietDonHangRepository chiTietDonHangRepository,IMapper mapper)
        {
            _chitietdonhangRepository = chiTietDonHangRepository;
            _mapper = mapper;
        }
        public async Task CreateChiTietDonHang(ChiTietDonHangInput ct)
        {
            var mapperctdh = _mapper.Map<ChiTietDonHang>(ct);
            await _chitietdonhangRepository.Add(mapperctdh);
        }

        public async Task DeleteChiTietDonHang(int madonhang, int masanpham)
        {
            await _chitietdonhangRepository.Delete(madonhang,masanpham);
        }

        public async Task<ICollection<ChiTietDonHang>> GetAll()
        {
            var dschitiet = await _chitietdonhangRepository.GetAll().ToListAsync();
            return dschitiet;
        }

        public async Task<ICollection<ChiTietDonHang>> GetByMaDonHang(int madonhang)
        {
            var dschitiet = await _chitietdonhangRepository.GetAll().ToListAsync();
            List<ChiTietDonHang> ds = new List<ChiTietDonHang>();
            foreach(var item in dschitiet)
            {
                if(item.MaDonHang ==  madonhang)
                {
                    ds.Add(item); 
                }
            }
            return ds;
        }

        public async Task<ChiTietDonHang> GetByMaDonHangMaSanPham(int madonhang, int masanpham)
        {
            var chitiet = await _chitietdonhangRepository.GetById(madonhang,masanpham);
            return chitiet;
        }

        public async Task UpdateChiTietDonHang(int madonhang, int masanpham, ChiTietDonHangInput ct)
        {
            var chitietdonhang = await _chitietdonhangRepository.GetById(madonhang,masanpham);
            if (chitietdonhang != null)
            {
                chitietdonhang.SoLuong = ct.SoLuong;
                await _chitietdonhangRepository.Update(chitietdonhang);
            }
        }
    }
}
