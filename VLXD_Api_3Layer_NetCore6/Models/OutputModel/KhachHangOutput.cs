namespace VatLieuXayDung_3Layer_Api.Models.OutputModel
{
    public class KhachHangOutput
    {
        public int MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
        public List<DonHangOutput> DonHangOutputs { get; set; }
    }
}
