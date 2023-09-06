using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.Page;

namespace Final_backend_PhungDaiDong.IServices
{
    public interface IQuyenHanService
    {
        public ErrorMessage ThemQuyenHan(QuyenHan quyenHanMoi);
        public ErrorMessage SuaQuyenHan(int idQuyenHan, QuyenHan QuyenHanThayThe);
        public ErrorMessage XoaQuyenHan(int idQuyenHan);
        public pageResult<QuyenHan> HienThiQuyenHan(Pagination pagination);

    }
}
