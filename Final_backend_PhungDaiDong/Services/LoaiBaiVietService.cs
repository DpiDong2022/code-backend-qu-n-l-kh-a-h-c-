using Final_backend_PhungDaiDong.DAO;
using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.IServices;
using Final_backend_PhungDaiDong.Page;
using Microsoft.AspNetCore.Routing.Tree;

namespace Final_backend_PhungDaiDong.Services
{
    public class LoaiBaiVietService : ILoaiBaiVietService
    {
        private readonly AppDbContext _context;

        public LoaiBaiVietService()
        {
            _context = new AppDbContext();
        }

        public pageResult<LoaiBaiViet> HienThiLoaiBaiViet(Pagination pagination)
        {
            IEnumerable<LoaiBaiViet> data = _context.LoaiBaiViet.AsEnumerable();
            IEnumerable<LoaiBaiViet> res = pageResult<LoaiBaiViet>.toPageResult(pagination, data);
            return new pageResult<LoaiBaiViet>(pagination, res);
        }

        public ErrorMessage SuaLoaiBaiViet(int idLoaiBaiViet, LoaiBaiViet loaiBaiVietThayThe)
        {
            LoaiBaiViet? loaiBaiVietSua = TonTaiLoaiBaiViet(idLoaiBaiViet);
            if (loaiBaiVietSua != null)
            {
                loaiBaiVietSua.TenLoai = loaiBaiVietThayThe.TenLoai;

                _context.Update(loaiBaiVietSua);
                _context.SaveChanges();
                return ErrorMessage.Suathanhcong;
            }
            return ErrorMessage.loaiBvietKTonTai;
        }

        public ErrorMessage ThemLoaiBaiViet(LoaiBaiViet loaiBaiVietMoi)
        {
            _context.Add(loaiBaiVietMoi);
            _context.SaveChanges();
            return ErrorMessage.Themthanhcong;
        }

        public ErrorMessage XoaLoaiBaiViet(int idLoaiBaiViet)
        {
            LoaiBaiViet? loaiBaiVietXoa = TonTaiLoaiBaiViet(idLoaiBaiViet);
            if (loaiBaiVietXoa != null)
            {
                _context.Remove(loaiBaiVietXoa);
                _context.SaveChanges();
                return ErrorMessage.Xoathanhcong;
            }
            return ErrorMessage.loaiBvietKTonTai;
        }

        internal LoaiBaiViet? TonTaiLoaiBaiViet(int ID) => _context.LoaiBaiViet.FirstOrDefault(c => c.LoaiBaiVietID == ID);
    }
}
