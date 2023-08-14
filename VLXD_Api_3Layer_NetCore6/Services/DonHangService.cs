using VatLieuXayDung_3Layer_Api.Models.InputModel;
using VatLieuXayDung_3Layer_Api.Models;
using VatLieuXayDung_3Layer_Api.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace VatLieuXayDung_3Layer_Api.Services
{
    public interface IDonHangService
    {
        public Task<ICollection<DonHang>> GetAll();
        public Task<DonHang> GetByMaDonHang(int madonhang);
        public Task CreateDonHang(DonHangInput dh);
        public Task UpdateDonHang(int madonhang, DonHangInput dh);
        public Task DeleteDonHang(int madonhang);
    }
    public class DonHangService : IDonHangService
    {
        private readonly DonHangRepository _donhangRepository;
        private readonly IMapper _mapper;

        public DonHangService(DonHangRepository donHangRepository,IMapper mapper) 
        {
            _donhangRepository = donHangRepository;
            _mapper = mapper;
        }
        public async Task CreateDonHang(DonHangInput dh)
        {
            var mapperdonhang = _mapper.Map<DonHang>(dh);
            await _donhangRepository.Add(mapperdonhang);
        }

        public async Task DeleteDonHang(int madonhang)
        {
            await _donhangRepository.Delete(madonhang);
        }

        public async Task<ICollection<DonHang>> GetAll()
        {
            var dsdonhang = await _donhangRepository.GetAll().ToListAsync();
            return dsdonhang;
        }

        public async Task<DonHang> GetByMaDonHang(int madonhang)
        {
            var donhang = await _donhangRepository.GetById(madonhang);
            return donhang;
        }

        public async Task UpdateDonHang(int madonhang, DonHangInput dh)
        {
            var donhang = await _donhangRepository.GetById(madonhang);
            if(donhang != null)
            {
                donhang.TrangThai = dh.TrangThai;
                donhang.MaKhachHang = dh.MaKhachHang;
                await _donhangRepository.Update(donhang);
            }
        }
    }
}
