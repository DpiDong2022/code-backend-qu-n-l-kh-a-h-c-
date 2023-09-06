using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.Page;

namespace Final_backend_PhungDaiDong.IServices
{
    public interface IHocVienService
    {
        public ErrorMessage ThemHocVien(HocVien hocVienMoi);
        public ErrorMessage SuaHocVien(int idHocVien, HocVien hocVienThayThe);
        public ErrorMessage XoaHocVien(int idHocVien);
        public pageResult<HocVien> HienThiHocVien(Pagination pagination, string? SearchKey);
    }
}
