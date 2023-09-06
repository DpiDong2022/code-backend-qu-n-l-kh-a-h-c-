using System.ComponentModel.DataAnnotations;

namespace Final_backend_PhungDaiDong.Entities
{
    public class ChuDe
    {
        public int ChuDeID { get; set; }
        [MaxLength(50)]
        public string TenChuDe { get; set; }
        public string NoiDung { get; set; }
        public int LoaiBaiVietID { get; set; }
        public virtual LoaiBaiViet? loaiBaiViet { get; set; }
        public virtual IEnumerable<BaiViet>? BaiVietList { get; set;}
        
    }
}
