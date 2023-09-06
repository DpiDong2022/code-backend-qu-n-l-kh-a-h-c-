using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Final_backend_PhungDaiDong.Entities
{
    public class LoaiKhoaHoc
    {
        public int LoaiKhoaHocID { get; set; }
        [MaxLength(30)]
        public string TenLoai { get; set; }
        public virtual IEnumerable<KhoaHoc>? KhoaHocList { get; set; }
    }
}
