namespace VatLieuXayDung_3Layer_Api.Models
{
    public class SanPham
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public double DonGia { get; set; }
        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
