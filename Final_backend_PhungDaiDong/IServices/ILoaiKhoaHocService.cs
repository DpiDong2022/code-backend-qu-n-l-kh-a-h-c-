using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;

namespace Final_backend_PhungDaiDong.IServices
{
    public interface ILoaiKhoaHocService
    {
        public ErrorMessage ThemLoaiKhoaHoc(LoaiKhoaHoc loaiKhoaHocMoi);
        public ErrorMessage SuaLoaiKhoaHoc(int idLoaiKhoaHoc, LoaiKhoaHoc loaiKhoaHocThayThe);
        public ErrorMessage XoaLoaiKhoaHoc(int idLoaiKhoaHoc);
    }
}
