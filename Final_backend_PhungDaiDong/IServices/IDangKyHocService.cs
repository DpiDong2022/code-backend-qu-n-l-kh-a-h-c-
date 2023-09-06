using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.Page;

namespace Final_backend_PhungDaiDong.IServices
{
    public interface IDangKyHocService
    {
        public ErrorMessage ThemDangKyHoc(DangKyHoc khoaHocMoi);
        public ErrorMessage XoaDangKyHoc(int idDangKyHoc);
        public ErrorMessage SuaDangKyHoc(int idDangKyHoc, DangKyHoc dangKyHocThayThe);
        public pageResult<DangKyHoc> HienThiDangKyHoc(Pagination pagination);
    }
}
