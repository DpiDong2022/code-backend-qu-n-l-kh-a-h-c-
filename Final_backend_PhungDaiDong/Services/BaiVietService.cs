using Final_backend_PhungDaiDong.DAO;
using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.IServices;
using Final_backend_PhungDaiDong.Page;

namespace Final_backend_PhungDaiDong.Services
{

    public class BaiVietService : IBaiVietService
    {
        private readonly AppDbContext _context;
        private readonly ChuDeService _chudeService;
        private readonly TaiKhoanService _taiKhoanService;

        public BaiVietService()
        {
            _context = new AppDbContext() ;
            _chudeService = new ChuDeService();
            _taiKhoanService = new TaiKhoanService(); ;
        }

        public pageResult<BaiViet> HienThiBaiViet(Pagination pagination, string? tenBaiViet=null)
        {
            IEnumerable<BaiViet> data = _context.BaiViet.AsEnumerable();
            if (tenBaiViet!=null)
            {
                tenBaiViet = tenBaiViet.ToLower();
                data = data.Where(c => c.TenBaiViet.ToLower().Contains(tenBaiViet));
            }

            IEnumerable<BaiViet> res = pageResult<BaiViet>.toPageResult(pagination, data);
            return new pageResult<BaiViet>(pagination, res);
        }

        public ErrorMessage SuaBaiViet(int idBaiViet, BaiViet baiVietThayThe)
        {
            BaiViet? baivietSua = TonTaiBaiViet(idBaiViet);
            if (baivietSua != null)
            {
                if (_taiKhoanService.TonTaiTaiKhoan(baiVietThayThe.TaiKhoanID) == null) return ErrorMessage.taikhoankotontai;
                if (_chudeService.TonTaiChuDe(baiVietThayThe.ChuDeID) == null) return ErrorMessage.chudekotontai;

                baivietSua.ChuDeID = baiVietThayThe.ChuDeID;
                baivietSua.NoiDung = baiVietThayThe.NoiDung;
                baivietSua.NoiDungNgan = baiVietThayThe.NoiDungNgan;
                baivietSua.HinhAnh = baiVietThayThe.HinhAnh;

                _context.Update(baivietSua);
                _context.SaveChanges();
                return ErrorMessage.Suathanhcong;
            }
            return ErrorMessage.KhongTonTai;
        }

        public ErrorMessage ThemBaiViet(BaiViet baiVietMoi)
        {
            if (_taiKhoanService.TonTaiTaiKhoan(baiVietMoi.TaiKhoanID) == null) return ErrorMessage.taikhoankotontai;
            if (_chudeService.TonTaiChuDe(baiVietMoi.ChuDeID) == null) return ErrorMessage.chudekotontai;

            _context.Add(baiVietMoi);
            _context.SaveChanges();
            return ErrorMessage.Themthanhcong;
        }

        public ErrorMessage XoaBaiViet(int idBaiViet)
        {
            BaiViet? baivietXoa = TonTaiBaiViet(idBaiViet);
            if(baivietXoa != null)
            {
                _context.Remove(baivietXoa);
                _context.SaveChanges();
                return ErrorMessage.Xoathanhcong;
            }
            return ErrorMessage.KhongTonTai;
        }

        private BaiViet? TonTaiBaiViet(int ID) => _context.BaiViet.FirstOrDefault(c => c.BaiVietID == ID);
    }
}
