using Final_backend_PhungDaiDong.DAO;
using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.IServices;
using Final_backend_PhungDaiDong.Page;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Runtime.Serialization;

namespace Final_backend_PhungDaiDong.Services
{
    public class HocVienService : IHocVienService
    {
        private readonly AppDbContext _context;

        public HocVienService()
        {
            _context = new AppDbContext();
        }

        public pageResult<HocVien> HienThiHocVien(Pagination pagination, string? SearchKey)
        {
            IEnumerable<HocVien> hocVienList = _context.HocVien.AsEnumerable();
            if (SearchKey != null)
            {
                SearchKey = SearchKey.ToLower();
                IEnumerable<HocVien> hocVienList2 = hocVienList.Where(c => c.HoTen.ToLower().Contains(SearchKey));

                if (hocVienList2.Count() == 0 || hocVienList2 == null)
                {
                    hocVienList2 = hocVienList.Where(c => c.Email == SearchKey);
                }
                hocVienList = hocVienList2;
            }

            IEnumerable<HocVien> result = pageResult<HocVien>.toPageResult(pagination, hocVienList);
            return new pageResult<HocVien>(pagination, result);
        }

        public ErrorMessage SuaHocVien(int idHocVien, HocVien hocVienThayThe)
        {
            HocVien? hocvienSua = TonTaiHocVien(idHocVien);
            if (hocvienSua != null)
            {
                string sdt = hocVienThayThe.SoDienThoai;
                string email = hocVienThayThe.Email;
                string hotenDinhDang = DinhDangHoTen(hocVienThayThe.HoTen);

                if (TonTaiSDT(sdt, hocvienSua.SoDienThoai)) return ErrorMessage.SDTdatontai;
                if (TonTaiEmail(email, hocvienSua.Email)) return ErrorMessage.emailDaTontai;

                hocvienSua.HoTen = hotenDinhDang;
                hocvienSua.SoDienThoai = sdt;
                hocvienSua.Email = email;
                hocvienSua.NgaySinh = hocVienThayThe.NgaySinh;
                hocvienSua.QuanHuyen = hocVienThayThe.QuanHuyen;
                hocvienSua.TinhThanh = hocVienThayThe.TinhThanh;
                hocvienSua.SoNha = hocVienThayThe.SoNha;
                hocvienSua.HinhAnh = hocVienThayThe.HinhAnh;

                _context.Update(hocvienSua);
                _context.SaveChanges();

                return ErrorMessage.Suathanhcong;
            }
            return ErrorMessage.KhongTonTai;
        }

        public ErrorMessage ThemHocVien(HocVien hocVienMoi)
        {
            string sdt = hocVienMoi.SoDienThoai;
            string email = hocVienMoi.Email;

            if (TonTaiSDT(sdt)) return ErrorMessage.SDTdatontai;
            if (TonTaiEmail(email)) return ErrorMessage.emailDaTontai;

            string HoTenDinhDang = DinhDangHoTen(hocVienMoi.HoTen);
            hocVienMoi.HoTen = HoTenDinhDang;

            _context.Add(hocVienMoi);
            _context.SaveChanges();

            return ErrorMessage.Themthanhcong;

        }

        public ErrorMessage XoaHocVien(int idHocVien)
        {
            HocVien? hocvienXoa = TonTaiHocVien(idHocVien);
            if (hocvienXoa != null)
            {
                _context.Remove(hocvienXoa);
                _context.SaveChanges();
                return ErrorMessage.Xoathanhcong;
            }
            return ErrorMessage.KhongTonTai;
        }

        internal string DinhDangHoTen(string hoten)
        {
            string[] hotenArr = hoten.Split();

            string HotenMoi = "";

            for (int i = 1; i < hotenArr.Length - 1; i++)
            {
                if (hotenArr[i] != "")
                {
                    HotenMoi += hotenArr[i].Substring(0, 1).ToUpper()
                    + hotenArr[i].Substring(1).ToLower() +" ";
                }
            }
            HotenMoi = HotenMoi.TrimEnd();

            return HotenMoi;
        }
        internal bool TonTaiSDT(string sdt) => _context.HocVien.Any(c => c.SoDienThoai == sdt);
        internal bool TonTaiSDT(string sdt, string sdtNgoaile)
        {
            return _context.HocVien.Any(c => c.SoDienThoai == sdt && c.SoDienThoai != sdtNgoaile);
        }
        internal bool TonTaiEmail(string email) => _context.HocVien.Any(c => c.Email==email);
        internal bool TonTaiEmail(string email, string emailNgoaiLe)
        {
            return _context.HocVien.Any(c => c.Email == email && c.Email != emailNgoaiLe);
        }
        internal HocVien? TonTaiHocVien(int id) => _context.HocVien.FirstOrDefault(c => c.HocVienID==id);
    }
}
