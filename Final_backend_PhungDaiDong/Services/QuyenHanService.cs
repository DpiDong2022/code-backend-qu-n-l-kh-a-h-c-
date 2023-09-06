using Final_backend_PhungDaiDong.DAO;
using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.IServices;
using Final_backend_PhungDaiDong.Page;

namespace Final_backend_PhungDaiDong.Services
{
    public class QuyenHanService : IQuyenHanService
    {
        private readonly AppDbContext _context;

        public QuyenHanService()
        {
            _context = new AppDbContext();
        }

        public pageResult<QuyenHan> HienThiQuyenHan(Pagination pagination)
        {
            IEnumerable<QuyenHan> quyenHanList = _context.QuyenHan.AsEnumerable();
            IEnumerable<QuyenHan> quyenHanRes = pageResult<QuyenHan>.toPageResult(pagination, quyenHanList);
            return new pageResult<QuyenHan>(pagination, quyenHanRes);
        }

        public ErrorMessage SuaQuyenHan(int idQuyenHan, QuyenHan QuyenHanThayThe)
        {
            QuyenHan? quyenHanSua = TonTaiQuyenhan(idQuyenHan);
            if (quyenHanSua!=null)
            {
                quyenHanSua.TenQuyenHan = QuyenHanThayThe.TenQuyenHan;

                _context.Update(quyenHanSua);
                _context.SaveChanges();

                return ErrorMessage.Suathanhcong;
            }
            return ErrorMessage.KhongTonTai;
        }

        public ErrorMessage ThemQuyenHan(QuyenHan quyenHanMoi)
        {
            _context.Add(quyenHanMoi);
            _context.SaveChanges();
            return ErrorMessage.thanhcong;
        }

        public ErrorMessage XoaQuyenHan(int idQuyenHan)
        {
            QuyenHan? quyenHanXoa = TonTaiQuyenhan(idQuyenHan);
            if (quyenHanXoa!=null)
            {
                _context.Remove(quyenHanXoa);
                _context.SaveChanges();

                return ErrorMessage.Xoathanhcong;
            }
            return ErrorMessage.KhongTonTai;
        }

        internal QuyenHan? TonTaiQuyenhan(int? ID) => _context.QuyenHan.FirstOrDefault(c => c.QuyenHanID == ID);
    }
}
