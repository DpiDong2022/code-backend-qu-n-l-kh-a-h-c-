using System.ComponentModel.DataAnnotations;

namespace Final_backend_PhungDaiDong.Entities
{
    public class LoaiBaiViet
    {
        public int LoaiBaiVietID { get; set; }
        [MaxLength(50)]
        public string TenLoai { get; set; }
        public virtual IEnumerable<ChuDe>? ChuDeList { get; set; }
    }
}
