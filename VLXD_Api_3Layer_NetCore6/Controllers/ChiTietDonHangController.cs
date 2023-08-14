using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VatLieuXayDung_3Layer_Api.Models;
using VatLieuXayDung_3Layer_Api.Models.InputModel;
using VatLieuXayDung_3Layer_Api.Models.OutputModel;
using VatLieuXayDung_3Layer_Api.Repositories;
using VatLieuXayDung_3Layer_Api.Services;

namespace VatLieuXayDung_3Layer_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietDonHangController : ControllerBase
    {
        private readonly IChiTietDonHangService _chitietdonhangSerivce;
        private readonly IMapper _mapper;

        public ChiTietDonHangController(IChiTietDonHangService chiTietDonHangService, IMapper mapper)
        {
            _chitietdonhangSerivce = chiTietDonHangService;
            _mapper = mapper;
        }

        [HttpGet("ChiTietDonHang")]
        public async Task<IActionResult> GetAll()
        {
            var dschitietdonhang = await _chitietdonhangSerivce.GetAll();
            return Ok(_mapper.Map<List<ChiTietDonHangOutput>>(dschitietdonhang));
        }

        [HttpGet("ChiTietDonHang/{madonhang}")]
        public async Task<IActionResult> GetBymadonhang(int madonhang)  
        {
            var donhang = await _chitietdonhangSerivce.GetByMaDonHang(madonhang);
            return Ok(_mapper.Map<List<ChiTietDonHangOutput>>(donhang));
        }
        [HttpGet("ChiTietDonHang/{madonhang}/{masanpham}")]
        public async Task<IActionResult> GetBymadonhangmasanpham(int madonhang,int masanpham)
        {
            var chitiet = await _chitietdonhangSerivce.GetByMaDonHangMaSanPham(madonhang, masanpham);
            return Ok(chitiet);
        }

        [HttpPost("ChiTietDonHang")]
        public async Task<IActionResult> Create(ChiTietDonHangInput kh)
        {
            await _chitietdonhangSerivce.CreateChiTietDonHang(kh);
            return Ok();
        }

        [HttpPut("ChiTietDonHang/{madonhang}/{masanpham}")]
        public async Task<IActionResult> Updatedonhang(int madonhang,int masanpham, ChiTietDonHangInput kh)
        {
            await _chitietdonhangSerivce.UpdateChiTietDonHang(madonhang,masanpham, kh);
            return Ok();
        }

        [HttpDelete("ChiTietDonHang/{madonhang}/{masanpham}")]
        public async Task<IActionResult> Delete(int madonhang,int masanpham)
        {
            await _chitietdonhangSerivce.DeleteChiTietDonHang(madonhang,masanpham);
            return Ok();
        }
    }
}
