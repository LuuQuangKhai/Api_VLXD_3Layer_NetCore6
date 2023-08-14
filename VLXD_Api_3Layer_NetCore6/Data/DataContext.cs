using Microsoft.EntityFrameworkCore;
using VatLieuXayDung_3Layer_Api.Models;

namespace VatLieuXayDung_3Layer_Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var strConn = config["ConnectionStrings:MyConntectionString"];
            return strConn;
        }

        #region DbSet
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // KhachHang
            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.ToTable("KhachHang");
                entity.HasKey(t => t.MaKhachHang);
            });

            // DonHang   
            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.ToTable("DonHang");
                entity.HasKey(dh => dh.MaDonHang);
                entity.Property(dh => dh.NgayLap).HasDefaultValueSql("getutcdate()");

                entity.HasOne(dh => dh.KhachHang)
                    .WithMany(dh => dh.DonHangs)
                    .HasForeignKey(dh => dh.MaKhachHang);
            });

            // SanPham
            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.ToTable("SanPham");
                entity.HasKey(t => t.MaSanPham);
            });

            // ChiTietDonHang
            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.ToTable("ChiTietDonHang");
                entity.HasKey(t => new { t.MaDonHang, t.MaSanPham });

                entity.HasOne(t => t.DonHang)
                .WithMany(t => t.ChiTietDonHangs)
                .HasForeignKey(t => t.MaDonHang);

                entity.HasOne(t => t.SanPham)
                .WithMany(t => t.ChiTietDonHangs)
                .HasForeignKey(t => t.MaSanPham);
            });
        }
    }
}
