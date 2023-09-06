using System.ComponentModel.DataAnnotations;

namespace Final_backend_PhungDaiDong.Entities
{
    public class QuyenHan
    {
        public int QuyenHanID { get; set; }
        [MaxLength(50)]
        public string TenQuyenHan { get; set; }
        public virtual IEnumerable<TaiKhoan>? TaiKhoanList { get; set; }    
    }
}
