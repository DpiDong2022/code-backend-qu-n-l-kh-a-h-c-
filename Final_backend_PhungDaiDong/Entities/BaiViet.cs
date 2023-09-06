using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Net.Security;

namespace Final_backend_PhungDaiDong.Entities
{
    public class BaiViet
    {
        private int _taiKhoanID;
        public int BaiVietID { get; set; }
        [MaxLength(50)]
        public string TenBaiViet { get; set; }
        [MaxLength(50)]
        public string TenTacGia { get; set; }
        public string NoiDung { get; set; }
        [MaxLength(1000)]
        public string NoiDungNgan { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public string HinhAnh { get; set; }
        public int ChuDeID { get; set; }
        public virtual ChuDe? chuDe { get; set; }
        public int TaiKhoanID 
        {
            get => _taiKhoanID;
            set
            {
                ThoiGianTao = DateTime.Now;
                _taiKhoanID= value;
            }
        }
        public virtual TaiKhoan? taiKhoan { get; set;}
        
        
    }
}
