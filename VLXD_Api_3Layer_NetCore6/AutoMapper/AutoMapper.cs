using AutoMapper;
using VatLieuXayDung_3Layer_Api.Models;
using VatLieuXayDung_3Layer_Api.Models.OutputModel;
using VatLieuXayDung_3Layer_Api.Models.InputModel;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace VatLieuXayDung_3Layer_Api.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            MapKhachHang();
            MapDonHang();
            MapSanPham();
            MapChiTietDonHang();
        }

        private void MapKhachHang()
        {
            CreateMap<KhachHang, KhachHangOutput>().ReverseMap();
            CreateMap<KhachHangInput, KhachHang>().ReverseMap();
        }

        private void MapDonHang()
        {
            CreateMap<DonHang, DonHangOutput>().ReverseMap();
            CreateMap<DonHangInput, DonHang>().ReverseMap();
        }

        private void MapSanPham()
        {
            CreateMap<SanPham, SanPhamOutput>().ReverseMap();
            CreateMap<SanPhamInput, SanPham>().ReverseMap();
        }

        private void MapChiTietDonHang()
        {
            CreateMap<ChiTietDonHang,ChiTietDonHangOutput>().ReverseMap();
            CreateMap<ChiTietDonHangInput, ChiTietDonHang>().ReverseMap();
        }
    }
}
