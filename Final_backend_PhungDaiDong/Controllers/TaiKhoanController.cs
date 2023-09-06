using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.Page;
using Final_backend_PhungDaiDong.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_backend_PhungDaiDong.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly TaiKhoanService _service;

        public TaiKhoanController()
        {
            _service = new TaiKhoanService();
        }

        [HttpPost]
        public IActionResult ThemTaiKhoan(TaiKhoan taiKhoanMoi)
        {
            var res = _service.ThemTaiKhoan(taiKhoanMoi);
            
            if(res == ErrorMessage.datontai)
            {
                return Ok(ErrHelper.Log(res, "Tên"));
            }
            else if (res == ErrorMessage.KhongTonTai)
            {
                return Ok(ErrHelper.Log(res, "Quyền hạn"));
            }
            else return Ok(ErrHelper.Log(res));
        }

        [HttpPut("suataikhoan{idTaiKhoan}")]
        public IActionResult SuaTaiKhoan(int idTaiKhoan, TaiKhoan taiKhoanMoi)
        {
            var res = _service.SuaTaiKhoan(idTaiKhoan, taiKhoanMoi);
            if (res == ErrorMessage.datontai)
            {
                return Ok(ErrHelper.Log(res, "Tên"));
            }
            else if (res == ErrorMessage.KhongTonTai)
            {
                return Ok(ErrHelper.Log(res, "Quyền hạn hoặc tài khoản"));
            }
            else return Ok(ErrHelper.Log(res));
        }

        [HttpDelete("xoataikhoan{idTaiKhoan}")]
        public IActionResult XoaTaiKhoan(int idTaiKhoan)
        {
            var res = _service.XoaTaiKhoan(idTaiKhoan);
            return Ok(ErrHelper.Log(res, "Tài khoản"));
        }

        [HttpGet]
        public IActionResult HienThiTaiKhoan([FromQuery] Pagination pagination, string? tenDangNhap, int? idQuyenHan = null)
        {
            var res = _service.HienThiTaiKhoan(pagination, tenDangNhap, idQuyenHan);
            return Ok(res);
        }
    }
}
