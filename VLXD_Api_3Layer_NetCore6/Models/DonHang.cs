namespace VatLieuXayDung_3Layer_Api.Models
{
    public class DonHang
    {
        public int MaDonHang { get; set; }
        public DateTimeOffset NgayLap { get; set; }
        public string TrangThai { get; set; }
        public int MaKhachHang { get; set; }
        public KhachHang KhachHang { get; set; }
        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
