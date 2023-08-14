namespace VatLieuXayDung_3Layer_Api.Models.OutputModel
{
    public class ChiTietDonHangOutput
    {
        public int MaDonHang { get; set; }
        public int MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public SanPhamOutput SanPhamOutput { get; set; }
    }
}
