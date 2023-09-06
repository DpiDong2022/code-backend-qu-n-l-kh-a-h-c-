using System.ComponentModel.DataAnnotations;

namespace Final_backend_PhungDaiDong.Entities
{
    public class TaiKhoan
    {
        public int TaiKhoanID { get; set; }
        [MaxLength(50)]
        public string TenNguoiDung { get; set; }
        [MaxLength(50)]
        public string TenDangNhap { get; set; }
        [MaxLength(50)]
        public string MatKhau { get; set; }
        public int QuyenHanID { get; set; }
        public virtual QuyenHan? quyenHan { get; set; }
        public virtual IEnumerable<DangKyHoc>? DangKyHocList { get; set; }
        public virtual IEnumerable<BaiViet>? BaiVietList { get; set; }  
    }
}
