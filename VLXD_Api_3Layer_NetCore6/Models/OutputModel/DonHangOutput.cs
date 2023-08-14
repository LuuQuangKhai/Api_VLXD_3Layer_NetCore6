namespace VatLieuXayDung_3Layer_Api.Models.OutputModel
{
    public class DonHangOutput
    {
        public int MaDonHang { get; set; }
        public DateTimeOffset NgayLap { get; set; }
        public string TrangThai { get; set; }
        public int MaKhachHang { get; set; }
        public List<ChiTietDonHangOutput> ChiTietDonHangOutputs { get; set; }
    }
}
