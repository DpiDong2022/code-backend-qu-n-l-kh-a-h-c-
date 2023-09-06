using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;

namespace Final_backend_PhungDaiDong.Entities
{
    public class KhoaHoc
    {
        public int KhoaHocID { get; set; }
        [MaxLength(50)]
        public string TenKhoaHoc { get; set; }
        public int ThoiGianHoc { get; set; }
        public string GioiThieu { get; set; }
        public string  NoiDung { get; set; }
        public double HocPhi { get; set; }
        public int SoHocVien { get; set; } = 0;
        public int SoLuongMon { get; set; }
        public string HinhAnh { get; set; }
        public int LoaiKhoaHocID { get; set; }
        public virtual LoaiKhoaHoc? loaiKhoaHoc { get; set; }
        public virtual IEnumerable<DangKyHoc>? DangKyHocList { get; set; }
    }
}
