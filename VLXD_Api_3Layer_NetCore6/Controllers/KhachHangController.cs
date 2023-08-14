using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VatLieuXayDung_3Layer_Api.Models.InputModel;
using VatLieuXayDung_3Layer_Api.Models.OutputModel;
using VatLieuXayDung_3Layer_Api.Repositories;
using VatLieuXayDung_3Layer_Api.Services;

namespace VatLieuXayDung_3Layer_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangService _khachhangService;
        private readonly IMapper _mapper;

        public KhachHangController(IKhachHangService khachHangService, IMapper mapper)
        {
            _khachhangService = khachHangService;
            _mapper = mapper;
        }

        [HttpGet("KhachHang")]
        public async Task<IActionResult> GetAll()
        {
            var dskhachhang = await _khachhangService.GetAll();
            return Ok(_mapper.Map<List<KhachHangOutput>>(dskhachhang));
        }

        [HttpGet("KhachHang/{makhachhang}")]
        public async Task<IActionResult> GetByMaKhachHang(int makhachhang)
        {
            var khachhang = await _khachhangService.GetByMaKhachHang(makhachhang);
            return Ok(khachhang);
        }

        [HttpPost("KhachHang")]
        public async Task<IActionResult> CreateKhachHang(KhachHangInput kh)
        {
            await _khachhangService.Create(kh);
            return Ok();
        }

        [HttpPut("KhachHang/{makhachhang}")]
        public async Task<IActionResult> UpdateKhachHang(int makhachhang, KhachHangInput kh)
        {
            await _khachhangService.Update(makhachhang,kh);
            return Ok();
        }

        [HttpDelete("KhachHang/{makhachhang}")]
        public async Task<IActionResult> DeleteKhachHang(int makhachhang)
        {
            await _khachhangService.Delete(makhachhang);
            return Ok();
        }
    }
}
