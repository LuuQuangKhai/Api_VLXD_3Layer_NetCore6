using AutoMapper.Configuration.Conventions;

namespace VatLieuXayDung_3Layer_Api.Models
{
    public class ChiTietDonHang
    {
        public int MaDonHang { get; set; }
        public int MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public SanPham SanPham { get; set; }
        public DonHang DonHang { get; set; }
    }
}
