using VatLieuXayDung_3Layer_Api.Models.InputModel;
using VatLieuXayDung_3Layer_Api.Models;
using VatLieuXayDung_3Layer_Api.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VatLieuXayDung_3Layer_Api.Models.OutputModel;

namespace VatLieuXayDung_3Layer_Api.Services
{
    public interface ISanPhamService
    {
        public Task<ICollection<SanPham>> GetAll();
        public Task<SanPham> GetByMaSanPham(int masanpham);
        public Task CreateSanPham(SanPhamInput sp);
        public Task UpdateSanPham(int masanpham, SanPhamInput sp);
        public Task DeleteSanPham(int masanpham);
    }
    public class SanPhamService : ISanPhamService
    {
        private readonly SanPhamRepsitory _sanphamRepsitory;
        private readonly IMapper _mapper;

        public SanPhamService(SanPhamRepsitory sanPhamRepsitory,IMapper mapper)
        {
            _sanphamRepsitory = sanPhamRepsitory;
            _mapper = mapper;
        }

        public async Task CreateSanPham(SanPhamInput sp)
        {
            var mappersanpham = _mapper.Map<SanPham>(sp);
            await _sanphamRepsitory.Add(mappersanpham);
        }

        public async Task DeleteSanPham(int masanpham)
        {
            await _sanphamRepsitory.Delete(masanpham);
        }

        public async  Task<ICollection<SanPham>> GetAll()
        {
            var dssanpham = await _sanphamRepsitory.GetAll().ToListAsync();
            return dssanpham;
        }

        public async  Task<SanPham> GetByMaSanPham(int masanpham)
        {
            var sanpham = await _sanphamRepsitory.GetById(masanpham);
            return sanpham;
        }

        public async  Task UpdateSanPham(int masanpham, SanPhamInput sp)
        {
            var sanpham = await _sanphamRepsitory.GetById(masanpham);
            if (sanpham != null)
            {
                sanpham.TenSanPham = sp.TenSanPham;
                sanpham.DonGia = sp.DonGia;
                await _sanphamRepsitory.Update(sanpham);
            }
        }
    }
}
