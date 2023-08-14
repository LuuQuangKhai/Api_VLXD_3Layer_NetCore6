using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VatLieuXayDung_3Layer_Api.Models;
using VatLieuXayDung_3Layer_Api.Models.InputModel;
using VatLieuXayDung_3Layer_Api.Models.OutputModel;
using VatLieuXayDung_3Layer_Api.Repositories;

namespace VatLieuXayDung_3Layer_Api.Services
{
    public interface IKhachHangService
    {
        public Task<ICollection<KhachHang>> GetAll();
        public Task<KhachHang> GetByMaKhachHang(int makhachhang);
        public Task Create(KhachHangInput kh);
        public Task Update(int makhachhang, KhachHangInput kh);
        public Task Delete(int makhachhang);
    }
    public class KhachHangService : IKhachHangService
    {
        private readonly KhachHangRepository _khachhangRepository;
        private readonly IMapper _mapper;   

        public KhachHangService(KhachHangRepository khachhangRepository, IMapper mapper)
        {
            _khachhangRepository = khachhangRepository;
            _mapper = mapper;
        }

        public async Task Create(KhachHangInput kh)
        {
            var mapperkhachhang = _mapper.Map<KhachHang>(kh);
            await _khachhangRepository.Add(mapperkhachhang);
        }

        public async Task Delete(int makhachhang)
        {
            await _khachhangRepository.Delete(makhachhang);
        }

        public async Task<ICollection<KhachHang>> GetAll()
        {
            var dskhachhang = await _khachhangRepository.GetAll().ToListAsync();
            return dskhachhang;
        }

        public async Task<KhachHang> GetByMaKhachHang(int makhachhang)
        {
            var khachhang = await _khachhangRepository.GetById(makhachhang);
            return khachhang;
        }

        public async Task Update(int makhachhang, KhachHangInput kh)
        {
            var khachhang = await _khachhangRepository.GetById(makhachhang);
            if(khachhang != null)
            {
                khachhang.TenKhachHang = kh.TenKhachHang;
                khachhang.DiaChi = kh.DiaChi;
                await _khachhangRepository.Update(khachhang);
            }
        }


    }
}
