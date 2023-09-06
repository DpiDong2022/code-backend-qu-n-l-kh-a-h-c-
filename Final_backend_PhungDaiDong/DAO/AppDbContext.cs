using Final_backend_PhungDaiDong.Entities;
using Microsoft.EntityFrameworkCore;

namespace Final_backend_PhungDaiDong.DAO
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<KhoaHoc> KhoaHoc { get; set; }
        public virtual DbSet<LoaiKhoaHoc> LoaiKhoaHoc { get; set; }
        public virtual DbSet<DangKyHoc> DangKyHoc { get; set; }
        public virtual DbSet<HocVien> HocVien { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }
        public virtual DbSet<QuyenHan> QuyenHan { get; set; }
        public virtual DbSet<TinhTrangHoc> TinhTrangHoc { get; set; }
        public virtual DbSet<BaiViet> BaiViet { get; set; }
        public virtual DbSet<LoaiBaiViet> LoaiBaiViet { get; set; }
        public virtual DbSet<ChuDe> ChuDe { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\DONGSQLSERVER;" +
                "database=FINAL_TEST_BACKEND_course;" +
                "trusted_connection=true; " +
                "trustservercertificate=true; " +
                "MultipleActiveResultSets=true");
        }

        
    }
}
