using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.Page;

namespace Final_backend_PhungDaiDong.IServices
{
    public interface IBaiVietService
    {
        public ErrorMessage ThemBaiViet(BaiViet baiVietMoi);
        public ErrorMessage SuaBaiViet(int idBaiViet, BaiViet baiVietThayThe);
        public ErrorMessage XoaBaiViet(int idBaiViet);
        public pageResult<BaiViet> HienThiBaiViet(Pagination pagination, string? tenBaiViet);
    }
}
