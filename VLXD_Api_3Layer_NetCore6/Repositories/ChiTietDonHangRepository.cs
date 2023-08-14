using VatLieuXayDung_3Layer_Api.Models;

namespace VatLieuXayDung_3Layer_Api.Repositories
{
    public class ChiTietDonHangRepository :BaseRepository<ChiTietDonHang>
    {
        public async Task<ChiTietDonHang?> GetById(int madonhang,int masanpham)
        {
            try
            {
                var entity = await _context.Set<ChiTietDonHang>().FindAsync(madonhang, masanpham);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting entity: {ex.Message}", ex);
            }
        }

        public async Task Delete(int madonhang,int masanpham)
        {
            try
            {
                var item = await _context.Set<ChiTietDonHang>().FindAsync(madonhang, masanpham);
                if (item != null)
                {
                    _context.Set<ChiTietDonHang>().Remove(item);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting entity: {ex.Message}", ex);
            }
        }
    }
}
