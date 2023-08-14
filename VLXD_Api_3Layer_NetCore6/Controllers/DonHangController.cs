using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VatLieuXayDung_3Layer_Api.Models.InputModel;
using VatLieuXayDung_3Layer_Api.Models.OutputModel;
using VatLieuXayDung_3Layer_Api.Services;

namespace VatLieuXayDung_3Layer_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonHangController : ControllerBase
    {
        private readonly IDonHangService _donHangService;
        private readonly IMapper _mapper;

        public DonHangController(IDonHangService donHangService,IMapper mapper)
        {
            _donHangService = donHangService;
            _mapper = mapper;
        }

        [HttpGet("DonHang")]
        public async Task<IActionResult> GetAll()
        {
            var dsdonhang = await _donHangService.GetAll();
            return Ok(_mapper.Map<List<DonHangOutput>>(dsdonhang));
        }

        [HttpGet("DonHang/{madonhang}")]
        public async Task<IActionResult> GetBymadonhang(int madonhang)
        {
            var donhang = await _donHangService.GetByMaDonHang(madonhang);
            return Ok(donhang);
        }

        [HttpPost("DonHang")]
        public async Task<IActionResult> Createdonhang(DonHangInput kh)
        {
            await _donHangService.CreateDonHang(kh);
            return Ok();
        }

        [HttpPut("DonHang/{madonhang}")]
        public async Task<IActionResult> Updatedonhang(int madonhang, DonHangInput kh)
        {
            await _donHangService.UpdateDonHang(madonhang, kh);
            return Ok();
        }

        [HttpDelete("DonHang/{madonhang}")]
        public async Task<IActionResult> Deletedonhang(int madonhang)
        {
            await _donHangService.DeleteDonHang(madonhang);
            return Ok();
        }
    }
}
