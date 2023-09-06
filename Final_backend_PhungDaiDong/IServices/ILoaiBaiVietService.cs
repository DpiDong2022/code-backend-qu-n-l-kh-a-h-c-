using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.Page;

namespace Final_backend_PhungDaiDong.IServices
{
    public interface ILoaiBaiVietService
    {
        public ErrorMessage ThemLoaiBaiViet(LoaiBaiViet loaiBaiVietMoi);
        public ErrorMessage SuaLoaiBaiViet(int idLoaiBaiViet, LoaiBaiViet loaiBaiVietThayThe);
        public ErrorMessage XoaLoaiBaiViet(int idLoaiBaiViet);
        public pageResult<LoaiBaiViet> HienThiLoaiBaiViet(Pagination pagination);
    }
}
