using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.Page;

namespace Final_backend_PhungDaiDong.IServices
{
    public interface ITaiKhoanService
    {
        public ErrorMessage ThemTaiKhoan(TaiKhoan taiKhoanMoi);
        public ErrorMessage SuaTaiKhoan(int idTaiKhoan, TaiKhoan taiKhoanThayThe);
        public ErrorMessage XoaTaiKhoan(int idTaiKhoan);
        public pageResult<TaiKhoan> HienThiTaiKhoan(Pagination pagination, string? TenDangNhap = null, int? idQuyenHan = null);
    }
}
