using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_backend_PhungDaiDong.Entities
{
    public class HocVien
    {
        public int HocVienID { get; set; }
        public string HinhAnh { get; set; }
        [MaxLength(50)]
        public string HoTen { get; set; }
        [Column(TypeName ="DATE")]
        public DateTime NgaySinh { get; set; }
        [Column(TypeName ="VARCHAR"), MaxLength(11)]
        public string SoDienThoai { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(40)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string TinhThanh { get; set; }
        [MaxLength(50)]
        public string QuanHuyen { get; set; }
        [MaxLength(50)]
        public string PhuongXa { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(50)]
        public string SoNha { get; set; }
        public virtual IEnumerable<DangKyHoc>? DangKyHocList { get; set; }
    }
}
