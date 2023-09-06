using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.Page;

namespace Final_backend_PhungDaiDong.IServices
{
    public interface ITinhTrangHocService
    {
        public ErrorMessage ThemTinhTrangHoc(TinhTrangHoc tinhTrangHocMoi);
        public ErrorMessage SuaTinhTrangHoc(int idTinhTrangHoc, TinhTrangHoc TinhTrangHocThayThe);
        public ErrorMessage XoaTinhTrangHoc(int idTinhTrangHoc);
        public pageResult<TinhTrangHoc> HienThiCacTinhTrangHoc(Pagination pagination);
    }
}
