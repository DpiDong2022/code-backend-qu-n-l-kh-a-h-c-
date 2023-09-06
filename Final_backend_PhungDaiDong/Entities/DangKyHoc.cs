namespace Final_backend_PhungDaiDong.Entities
{
    public class DangKyHoc
    {
        private int _idTinhTrangHoc;
        public int DangKyHocID { get; set; }
        public int KhoaHocID { get; set; }
        public virtual KhoaHoc? khoaHoc { get; set; }
        public int HocVienID { get; set; }
        public virtual HocVien? hocVien { get; set; }
        public DateTime NgayDangKy { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int TinhTrangHocID 
        {
            get => _idTinhTrangHoc;
            set
            {
                _idTinhTrangHoc = value;
                NgayDangKy = DateTime.Now;
            }
        }
        public virtual TinhTrangHoc? tinhTrangHoc { get; set; }
        public int TaiKhoanID { get; set; }
        public virtual TaiKhoan? taiKhoan { get; set; }
    }
}
