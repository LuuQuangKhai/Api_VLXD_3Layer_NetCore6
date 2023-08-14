using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VatLieuXayDung_3Layer_Api.Models.InputModel;
using VatLieuXayDung_3Layer_Api.Models.OutputModel;
using VatLieuXayDung_3Layer_Api.Services;

namespace VatLieuXayDung_3Layer_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamService _sanphamService;
        private readonly IMapper _mapper;

        public SanPhamController(ISanPhamService sanPhamService, IMapper mapper)
        {
            _sanphamService = sanPhamService;
            _mapper = mapper;
        }

        [HttpGet("SanPham")]
        public async Task<IActionResult> GetAll()
        {
            var dssanpham = await _sanphamService.GetAll();
            return Ok(_mapper.Map<List<SanPhamOutput>>(dssanpham));
        }

        [HttpGet("SanPham/{masanpham}")]
        public async Task<IActionResult> GetBymasanpham(int masanpham)
        {
            var sanpham = await _sanphamService.GetByMaSanPham(masanpham);
            return Ok(sanpham);
        }

        [HttpPost("SanPham")]
        public async Task<IActionResult> CreateKhachHang(SanPhamInput sp)
        {
            await _sanphamService.CreateSanPham(sp);
            return Ok();
        }

        [HttpPut("SanPham/{masanpham}")]
        public async Task<IActionResult> UpdateKhachHang(int masanpham, SanPhamInput sp)
        {
            await _sanphamService.UpdateSanPham(masanpham, sp);
            return Ok();
        }

        [HttpDelete("SanPham/{masanpham}")]
        public async Task<IActionResult> DeleteKhachHang(int masanpham)
        {
            await _sanphamService.DeleteSanPham(masanpham);
            return Ok();
        }
    }
}
