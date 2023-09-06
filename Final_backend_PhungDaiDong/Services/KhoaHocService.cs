using Final_backend_PhungDaiDong.DAO;
using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.IServices;
using Final_backend_PhungDaiDong.Page;

namespace Final_backend_PhungDaiDong.Services
{
    public class KhoaHocService : IKhoaHocService

    {
        private readonly AppDbContext _context;
        private readonly LoaiKhoaHocService _loaiKhoaHocService;
        private readonly TinhTrangHocService _tinhTrangHocService;

        public KhoaHocService()
        {
            _context = new AppDbContext();
            _loaiKhoaHocService = new LoaiKhoaHocService();
            _tinhTrangHocService= new TinhTrangHocService();
        }

        public pageResult<KhoaHoc> HienThiKhoaHoc(Pagination pagination, string? tenKhoaHoc=null)
        {
            IEnumerable<KhoaHoc> data = _context.KhoaHoc.AsEnumerable();
            if (tenKhoaHoc != null)
            {
                tenKhoaHoc = tenKhoaHoc.ToLower();
                data = data.Where(c => c.TenKhoaHoc.ToLower().Contains(tenKhoaHoc));
            }

            IEnumerable<KhoaHoc> res = pageResult<KhoaHoc>.toPageResult(pagination, data);
            return new pageResult<KhoaHoc>(pagination, res);
        }

        public ErrorMessage SuaKhoaHoc(int idKhoaHoc, KhoaHoc khoaHocThayThe)
        {
            KhoaHoc? khoaHocSua = TonTaiKhoaHoc(idKhoaHoc);
            if (khoaHocSua == null) return ErrorMessage.KhongTonTai;
            if (!_loaiKhoaHocService.tonTaiLoaiKhoaHoc(khoaHocThayThe.LoaiKhoaHocID)) return ErrorMessage.LoaiKhoaHockoTontai;

            khoaHocSua.HocPhi = khoaHocThayThe.HocPhi;
            khoaHocSua.LoaiKhoaHocID= khoaHocThayThe.LoaiKhoaHocID;
            khoaHocSua.ThoiGianHoc = khoaHocThayThe.ThoiGianHoc;
            khoaHocSua.HinhAnh = khoaHocThayThe.HinhAnh;
            khoaHocSua.GioiThieu = khoaHocThayThe.GioiThieu;
            khoaHocSua.SoLuongMon = khoaHocThayThe.SoLuongMon;
            khoaHocSua.TenKhoaHoc = khoaHocThayThe.TenKhoaHoc;
            khoaHocSua.NoiDung = khoaHocThayThe.NoiDung;

            _context.Update(khoaHocSua);
            _context.SaveChanges();
            return ErrorMessage.Suathanhcong;
        }

        public ErrorMessage ThemKhoaHoc(KhoaHoc khoaHocMoi)
        {
            if (_loaiKhoaHocService.tonTaiLoaiKhoaHoc(khoaHocMoi.LoaiKhoaHocID))
            {
                _context.Add(khoaHocMoi);
                _context.SaveChanges();
                return ErrorMessage.Themthanhcong;
            }
            return ErrorMessage.LoaiKhoaHockoTontai;
        }

        public ErrorMessage XoaKhoaHoc(int idKhoaHoc)
        {
            KhoaHoc? khoahocXoa = TonTaiKhoaHoc(idKhoaHoc);
            if (khoahocXoa == null) return ErrorMessage.KhongTonTai;
            _context.RemoveRange(_context.DangKyHoc.Where(c => c.KhoaHocID == idKhoaHoc));
            _context.Remove(khoahocXoa);
            _context.SaveChanges();
            return ErrorMessage.Xoathanhcong;
        }

        public KhoaHoc? TonTaiKhoaHoc(int ID)
        {
            return _context.KhoaHoc.FirstOrDefault(c => c.KhoaHocID == ID);
        }

        internal void CapNhatSoLuongHocVien(int idKhoaHoc, int idTinhTrangHoc)
        {
            Console.WriteLine(idKhoaHoc);
            KhoaHoc? khoahocCapNhat = TonTaiKhoaHoc(idKhoaHoc);
            if (khoahocCapNhat == null) return;
            if (_tinhTrangHocService.TonTaiTinhTrangHoc(idTinhTrangHoc) == null) return;
            Console.WriteLine(idKhoaHoc);

            if (idTinhTrangHoc == 2)
            {
                khoahocCapNhat.SoHocVien += 1;
            }
            else if (idTinhTrangHoc == 4 || idTinhTrangHoc == 3)
            {
                khoahocCapNhat.SoHocVien -= 1;
            }
            _context.Update(khoahocCapNhat);
            _context.SaveChanges();
        }
    }
}
