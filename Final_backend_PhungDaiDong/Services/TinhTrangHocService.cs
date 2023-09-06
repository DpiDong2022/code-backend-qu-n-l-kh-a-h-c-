using Final_backend_PhungDaiDong.DAO;
using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.IServices;
using Final_backend_PhungDaiDong.Page;

namespace Final_backend_PhungDaiDong.Services
{
    public class TinhTrangHocService : ITinhTrangHocService
    {
        private readonly AppDbContext _context;

        public TinhTrangHocService()
        {
            _context = new AppDbContext();
        }

        public pageResult<TinhTrangHoc> HienThiCacTinhTrangHoc(Pagination pagination)
        {
            IEnumerable<TinhTrangHoc> tinhTrangHocList = _context.TinhTrangHoc.AsEnumerable();
            IEnumerable<TinhTrangHoc> tinhTrangHocRes = pageResult<TinhTrangHoc>.toPageResult(pagination, tinhTrangHocList);
            return new pageResult<TinhTrangHoc>(pagination, tinhTrangHocRes);
        }

        public ErrorMessage SuaTinhTrangHoc(int idTinhTrangHoc, TinhTrangHoc TinhTrangHocThayThe)
        {
            TinhTrangHoc? tinhTrangSua = TonTaiTinhTrangHoc(idTinhTrangHoc);
            if (tinhTrangSua != null)
            {
                tinhTrangSua.TenTinhTrang = TinhTrangHocThayThe.TenTinhTrang;

                _context.Update(tinhTrangSua);
                _context.SaveChanges();

                return ErrorMessage.Suathanhcong;
            }
            return ErrorMessage.KhongTonTai;
        }

        public ErrorMessage ThemTinhTrangHoc(TinhTrangHoc tinhTrangHocMoi)
        {
            _context.Add(tinhTrangHocMoi);
            _context.SaveChanges();
            return ErrorMessage.Themthanhcong;
        }

        public ErrorMessage XoaTinhTrangHoc(int idTinhTrangHoc)
        {
            TinhTrangHoc? tinhTrangXoa = TonTaiTinhTrangHoc(idTinhTrangHoc);
            if (tinhTrangXoa != null)
            {
                _context.Remove(tinhTrangXoa);
                _context.SaveChanges();    
                return ErrorMessage.Xoathanhcong;
            }
            return ErrorMessage.KhongTonTai;
        }

        internal TinhTrangHoc? TonTaiTinhTrangHoc(int ID) => _context.TinhTrangHoc.FirstOrDefault(c => c.TinhTrangHocID == ID);
    }
}
