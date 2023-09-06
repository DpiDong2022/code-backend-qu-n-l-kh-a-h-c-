using Azure.Core;
using Final_backend_PhungDaiDong.DAO;
using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.IServices;
using Final_backend_PhungDaiDong.Page;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_backend_PhungDaiDong.Services
{
    public class DangKyHocService : IDangKyHocService
    {
        private readonly KhoaHocService _khoahocService;
        private readonly HocVienService _hocVienService;
        private readonly TinhTrangHocService _tinhTrangService;
        private readonly TaiKhoanService _taiKhoanService;
        private readonly AppDbContext _context;

        public DangKyHocService()
        {
            _khoahocService = new KhoaHocService();
            _hocVienService = new HocVienService();
            _tinhTrangService = new TinhTrangHocService();
            _taiKhoanService = new TaiKhoanService();
            _context = new AppDbContext();
        }

        public pageResult<DangKyHoc> HienThiDangKyHoc(Pagination pagination)
        {
            IEnumerable<DangKyHoc> data = _context.DangKyHoc.AsEnumerable();
            IEnumerable<DangKyHoc> res = pageResult<DangKyHoc>.toPageResult(pagination, data);
            return new pageResult<DangKyHoc>(pagination, res);
        }

        public ErrorMessage SuaDangKyHoc(int idDangKyHoc, DangKyHoc dangKyHocThayThe)
        {
            DangKyHoc? dangKyHocSua = TonTaiDangKyHoc(idDangKyHoc);
            if (dangKyHocSua == null) return ErrorMessage.KhongTonTai;

            int tinhtrangHocThayThe = dangKyHocThayThe.TinhTrangHocID;
            int tinhtrangHocCu = dangKyHocSua.TinhTrangHocID;
            int idKhoaHocthayThe = dangKyHocThayThe.KhoaHocID;
            int idKhoaHocCu = dangKyHocSua.KhoaHocID;

            if (_hocVienService.TonTaiHocVien(dangKyHocThayThe.HocVienID) == null) return ErrorMessage.kotontaihocvien;
            if (_tinhTrangService.TonTaiTinhTrangHoc(tinhtrangHocThayThe) == null) return ErrorMessage.tinhTrangKoTontai;
            if (_taiKhoanService.TonTaiTaiKhoan(dangKyHocThayThe.TaiKhoanID) == null) return ErrorMessage.taikhoankotontai;
            if (_khoahocService.TonTaiKhoaHoc(dangKyHocThayThe.KhoaHocID) == null) return ErrorMessage.kotontaiKhoaHoc;

            
            int hours = _context.KhoaHoc.FirstOrDefault(c => c.KhoaHocID == idKhoaHocthayThe).ThoiGianHoc;

            dangKyHocSua.KhoaHocID = idKhoaHocthayThe;
            dangKyHocSua.HocVienID = dangKyHocThayThe.HocVienID;
            dangKyHocSua.NgayDangKy = dangKyHocThayThe.NgayDangKy;
            dangKyHocSua.TaiKhoanID = dangKyHocThayThe.TaiKhoanID;
            dangKyHocSua.TinhTrangHocID = tinhtrangHocThayThe;

            if (tinhtrangHocCu > 1 && tinhtrangHocThayThe == 1)
            {
                return ErrorMessage.koTheChuyenSangChoDuyet;
            }

            if(idKhoaHocCu != idKhoaHocthayThe)
            {
                _khoahocService.CapNhatSoLuongHocVien(idKhoaHocCu, 3); // tru so luong hoc vien
            }

            if (tinhtrangHocCu == 1)
            {
                if (tinhtrangHocThayThe == 2)
                {
                    _khoahocService.CapNhatSoLuongHocVien(idKhoaHocthayThe, 2);
                    dangKyHocSua.NgayBatDau = DateTime.Now;
                    dangKyHocSua.NgayKetThuc = DateTime.Now.AddHours(hours);
                }
                else if (tinhtrangHocThayThe == 3 || tinhtrangHocThayThe == 4)
                {
                    dangKyHocSua.NgayBatDau = DateTime.Now;
                    dangKyHocSua.NgayKetThuc = DateTime.Now.AddHours(hours);
                }
            }
            else if (tinhtrangHocCu == 2)
            {
                if (tinhtrangHocThayThe == 3 || tinhtrangHocThayThe == 4)
                {
                    _khoahocService.CapNhatSoLuongHocVien(idKhoaHocthayThe, 3);
                }
            }
            else if(tinhtrangHocCu == 4)
            {
                if (tinhtrangHocThayThe == 2)
                {
                    _khoahocService.CapNhatSoLuongHocVien(idKhoaHocthayThe, 2);
                }
            }


            _context.Update(dangKyHocSua);
            _context.SaveChanges();
            return ErrorMessage.Suathanhcong;
        }

        public ErrorMessage ThemDangKyHoc(DangKyHoc khoaHocMoi)
        {
            if (_hocVienService.TonTaiHocVien(khoaHocMoi.HocVienID) == null) return ErrorMessage.kotontaihocvien;
            /*if (_tinhTrangService.TonTaiTinhTrangHoc(khoaHocMoi.TinhTrangHocID) == null) return ErrorMessage.tinhTrangKoTontai;*/
            if (_taiKhoanService.TonTaiTaiKhoan(khoaHocMoi.TaiKhoanID) == null) return ErrorMessage.taikhoankotontai;
            if (_khoahocService.TonTaiKhoaHoc(khoaHocMoi.KhoaHocID) == null) return ErrorMessage.kotontaiKhoaHoc;

            /*_khoahocService.CapNhatSoLuongHocVien(khoaHocMoi.KhoaHocID, khoaHocMoi.TinhTrangHocID);*/
            khoaHocMoi.NgayDangKy = DateTime.Now;
            khoaHocMoi.NgayBatDau = null;
            khoaHocMoi.NgayKetThuc = null;
            khoaHocMoi.TinhTrangHocID = 1;

            _context.Add(khoaHocMoi);
            _context.SaveChanges();
            return ErrorMessage.Themthanhcong;
        }

        public ErrorMessage XoaDangKyHoc(int idDangKyHoc)
        {
            DangKyHoc? dangKyHocXoa = TonTaiDangKyHoc(idDangKyHoc);
            if (dangKyHocXoa == null) return ErrorMessage.KhongTonTai;

            if(dangKyHocXoa.TinhTrangHocID !=1)
            {
                _khoahocService.CapNhatSoLuongHocVien(dangKyHocXoa.KhoaHocID, 3);
            }
            
            _context.Remove(dangKyHocXoa);
            _context.SaveChanges();
            return ErrorMessage.Xoathanhcong;
        }

        public DangKyHoc? TonTaiDangKyHoc(int idDangkyHoc) => _context.DangKyHoc.FirstOrDefault(c => c.DangKyHocID == idDangkyHoc);
    }
}
