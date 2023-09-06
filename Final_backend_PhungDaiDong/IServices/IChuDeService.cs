using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.Page;

namespace Final_backend_PhungDaiDong.IServices
{
    public interface IChuDeService
    {
        public ErrorMessage ThemChuDe(ChuDe chuDeMoi);
        public ErrorMessage SuaChuDe(int idChuDe, ChuDe chuDeThayThe);
        public ErrorMessage XoaChuDe(int idChuDe);
        public pageResult<ChuDe> HienThiChuDe(Pagination pagination);
    }
}
