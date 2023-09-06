using Final_backend_PhungDaiDong.DAO;
using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.IServices;
using Final_backend_PhungDaiDong.Page;

namespace Final_backend_PhungDaiDong.Services
{
    public class ChuDeService : IChuDeService
    {
        private readonly AppDbContext _context;
        private readonly LoaiBaiVietService _loaibaiVietService;

        public ChuDeService()
        {
            _context = new AppDbContext();
            _loaibaiVietService = new LoaiBaiVietService();
        }

        public pageResult<ChuDe> HienThiChuDe(Pagination pagination)
        {
            IEnumerable<ChuDe> data = _context.ChuDe.AsEnumerable();
            IEnumerable<ChuDe> res = pageResult<ChuDe>.toPageResult(pagination, data);
            return new pageResult<ChuDe>(pagination, res);
        }

        public ErrorMessage SuaChuDe(int idChuDe, ChuDe chuDeThayThe)
        {
            ChuDe? chuDeSua = TonTaiChuDe(idChuDe);
            if(_loaibaiVietService.TonTaiLoaiBaiViet(chuDeThayThe.LoaiBaiVietID) == null)
            {
                return ErrorMessage.loaiBvietKTonTai;
            }
            if (chuDeSua != null)
            {
                chuDeSua.TenChuDe = chuDeThayThe.TenChuDe;
                chuDeSua.NoiDung = chuDeThayThe.NoiDung;
                chuDeSua.LoaiBaiVietID = chuDeThayThe.LoaiBaiVietID;

                _context.Update(chuDeSua);
                _context.SaveChanges();
                return ErrorMessage.Suathanhcong;
            }
            return ErrorMessage.KhongTonTai;
        }

        public ErrorMessage ThemChuDe(ChuDe chuDeMoi)
        {
            if (_loaibaiVietService.TonTaiLoaiBaiViet(chuDeMoi.LoaiBaiVietID) != null)
            {
                _context.Add(chuDeMoi);
                _context.SaveChanges();
                return ErrorMessage.Themthanhcong;
            }
            return ErrorMessage.KhongTonTai;
        }

        public ErrorMessage XoaChuDe(int idChuDe)
        {
            ChuDe? chuDeXoa = TonTaiChuDe(idChuDe);
            if (chuDeXoa != null)
            {
                _context.Remove(chuDeXoa);
                _context.SaveChanges();
                return ErrorMessage.Xoathanhcong;
            }
            return ErrorMessage.KhongTonTai;
        }

        internal ChuDe? TonTaiChuDe(int ID) => _context.ChuDe.FirstOrDefault(c => c.ChuDeID == ID);
    }
}
