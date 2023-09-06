using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.Page;

namespace Final_backend_PhungDaiDong.IServices
{
    public interface IKhoaHocService
    {
        public ErrorMessage ThemKhoaHoc(KhoaHoc khoaHocMoi);
        public ErrorMessage XoaKhoaHoc(int idKhoaHoc);
        public ErrorMessage SuaKhoaHoc(int idKhoaHoc, KhoaHoc khoaHocThayThe);
        public pageResult<KhoaHoc> HienThiKhoaHoc(Pagination pagination, string? tenKhoaHoc);
    }
}
