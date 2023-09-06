using System.ComponentModel.DataAnnotations;

namespace Final_backend_PhungDaiDong.Entities
{
    public class TinhTrangHoc
    {
        public int TinhTrangHocID { get; set; }
        [MaxLength(40)]
        public string TenTinhTrang { get; set; }
        public virtual IEnumerable<DangKyHoc>? DangKyHocList { get; set; }
    }
}
