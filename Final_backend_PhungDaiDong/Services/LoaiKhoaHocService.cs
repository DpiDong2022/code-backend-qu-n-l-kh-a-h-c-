using Final_backend_PhungDaiDong.DAO;
using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.IServices;

namespace Final_backend_PhungDaiDong.Services
{
    public class LoaiKhoaHocService : ILoaiKhoaHocService
    {
        private readonly AppDbContext _context;

        public LoaiKhoaHocService()
        {
            _context = new AppDbContext();
        }

        public ErrorMessage SuaLoaiKhoaHoc(int idLoaiKhoaHoc, LoaiKhoaHoc loaiKhoaHocThayThe)
        {
            if (tonTaiLoaiKhoaHoc(idLoaiKhoaHoc))
            {
                LoaiKhoaHoc? loaiKhoaHocDuocSua = _context.LoaiKhoaHoc.Find(idLoaiKhoaHoc);
                loaiKhoaHocDuocSua.TenLoai = loaiKhoaHocThayThe.TenLoai;

                _context.Update(loaiKhoaHocDuocSua);
                _context.SaveChanges();

                return ErrorMessage.Suathanhcong;
            }
            return ErrorMessage.KhongTonTai;
        }

        public ErrorMessage ThemLoaiKhoaHoc(LoaiKhoaHoc loaiKhoaHocMoi)
        {
            _context.Add(loaiKhoaHocMoi);
            _context.SaveChanges();
            return ErrorMessage.Themthanhcong;
        }

        public ErrorMessage XoaLoaiKhoaHoc(int idLoaiKhoaHoc)
        {
            if (tonTaiLoaiKhoaHoc(idLoaiKhoaHoc))
            {
                LoaiKhoaHoc loaiKhoaHocXoa = _context.LoaiKhoaHoc.Find(idLoaiKhoaHoc);

                _context.Remove(loaiKhoaHocXoa);
                _context.SaveChanges();

                return ErrorMessage.Xoathanhcong;
            }
            return ErrorMessage.KhongTonTai;
        }

        internal bool tonTaiLoaiKhoaHoc(int idLoaiKhoaHoc) => _context.LoaiKhoaHoc.Find(idLoaiKhoaHoc) != null;
    }
}
