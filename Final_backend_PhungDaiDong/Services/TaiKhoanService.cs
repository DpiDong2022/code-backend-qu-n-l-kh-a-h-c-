using Final_backend_PhungDaiDong.DAO;
using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.IServices;
using Final_backend_PhungDaiDong.Page;

namespace Final_backend_PhungDaiDong.Services
{
    public class TaiKhoanService : ITaiKhoanService
    {
        private readonly AppDbContext _context;
        private readonly QuyenHanService _quyenHanService;

        public TaiKhoanService()
        {
            _context = new AppDbContext();
            _quyenHanService = new QuyenHanService();
        }

        public pageResult<TaiKhoan> HienThiTaiKhoan(Pagination pagination, string? TenDangNhap=null,int? idQuyenHan = null)
        {
            IEnumerable<TaiKhoan> taiKhoanList = _context.TaiKhoan.AsEnumerable();
            if (TenDangNhap != null)
            {
                TenDangNhap = TenDangNhap.ToLower();
                taiKhoanList = taiKhoanList.Where(c => c.TenDangNhap.ToLower().Contains(TenDangNhap));
            }
            if (idQuyenHan != null || _quyenHanService.TonTaiQuyenhan(idQuyenHan) != null)
            {
                taiKhoanList = taiKhoanList.Where(c => c.QuyenHanID == idQuyenHan);
            }

            IEnumerable<TaiKhoan> result = pageResult<TaiKhoan>.toPageResult(pagination, taiKhoanList);
            return new pageResult<TaiKhoan>(pagination, result);
        }

        public ErrorMessage SuaTaiKhoan(int idTaiKhoan, TaiKhoan taiKhoanThayThe)
        {
            TaiKhoan? taiKhoanSua = TonTaiTaiKhoan(idTaiKhoan);

            if (taiKhoanSua != null)
            {
                string tenDangNhap = taiKhoanThayThe.TenDangNhap;
                string matKhau = taiKhoanThayThe.MatKhau;

                if (TonTaiTenDangNhap(tenDangNhap)) return ErrorMessage.datontai;

                ErrorMessage errorMatKhau = KiemTraMatKhau(matKhau);

                if (errorMatKhau != ErrorMessage.hople) return errorMatKhau;

                if(_quyenHanService.TonTaiQuyenhan(taiKhoanThayThe.QuyenHanID)==null) return ErrorMessage.KhongTonTai;

                taiKhoanSua.TenDangNhap = taiKhoanThayThe.TenDangNhap;
                taiKhoanSua.TenNguoiDung = taiKhoanThayThe.TenNguoiDung;
                taiKhoanSua.MatKhau = taiKhoanThayThe.MatKhau;
                taiKhoanSua.QuyenHanID = taiKhoanThayThe.QuyenHanID;

                _context.Update(taiKhoanSua);
                _context.SaveChanges();
                return ErrorMessage.Suathanhcong;
            }
            return ErrorMessage.KhongTonTai;
        }

        public ErrorMessage ThemTaiKhoan(TaiKhoan taiKhoanMoi)
        {
            string tenDangNhap = taiKhoanMoi.TenDangNhap;
            string matKhau = taiKhoanMoi.MatKhau;

            if (TonTaiTenDangNhap(tenDangNhap)) return ErrorMessage.datontai;

            ErrorMessage errorMatKhau = KiemTraMatKhau(matKhau);

            if (errorMatKhau != ErrorMessage.hople) return errorMatKhau;

            if (_quyenHanService.TonTaiQuyenhan(taiKhoanMoi.QuyenHanID) == null) return ErrorMessage.KhongTonTai;

                _context.Add(taiKhoanMoi);
            _context.SaveChanges();
            return ErrorMessage.Themthanhcong;
        }

        public ErrorMessage XoaTaiKhoan(int idTaiKhoan)
        {
            TaiKhoan? taiKhoanXoa = TonTaiTaiKhoan(idTaiKhoan);

            if (taiKhoanXoa != null){
                _context.Remove(taiKhoanXoa);
                _context.SaveChanges();
                return ErrorMessage.Xoathanhcong;
            }
            return ErrorMessage.KhongTonTai;
        }

        private bool TonTaiTenDangNhap(string TenDangNhapMoi) => _context.TaiKhoan.Any(c => c.TenDangNhap == TenDangNhapMoi);
        internal TaiKhoan? TonTaiTaiKhoan(int idTaiKhoan) => _context.TaiKhoan.FirstOrDefault(c => c.TaiKhoanID == idTaiKhoan);
        private ErrorMessage KiemTraMatKhau(string matKhau)
        {
            char[] matkhauChar = matKhau.ToCharArray();
            if (!matkhauChar.Any(c => Char.IsNumber(c))) return ErrorMessage.MKkhongCoSo;
            if (!matkhauChar.Any(c => Char.IsPunctuation(c))) return ErrorMessage.MKkhongCoKiTuDacBiet;
            return ErrorMessage.hople;
        }
    }
}
