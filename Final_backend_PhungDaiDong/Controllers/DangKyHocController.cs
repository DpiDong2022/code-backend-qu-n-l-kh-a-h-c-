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
    public class DangKyHocController : ControllerBase
    {
        private readonly DangKyHocService _service;

        public DangKyHocController()
        {
            _service = new DangKyHocService();
        }

        [HttpPost]
        public IActionResult ThemDangKyHoc(DangKyHoc dangKyhocMoi)
        {
            var res = _service.ThemDangKyHoc(dangKyhocMoi);
            return Ok(ErrHelper.Log(res));
        }

        [HttpPut("suadangkyhoc{idDangKyHoc}")]
        public IActionResult SuaDangKyHoc(int idDangKyhoc, DangKyHoc dangKyHocThayThe)
        {
            var res = _service.SuaDangKyHoc(idDangKyhoc, dangKyHocThayThe);
            if (res == ErrorMessage.Suathanhcong || res==ErrorMessage.KhongTonTai)
            {
                return Ok(ErrHelper.Log(res, "Đăng ký học"));
            }
            return Ok(ErrHelper.Log(res));
        }

        [HttpDelete("xoadangkyhoc{idDangKyHoc}")]
        public IActionResult XoaDangKyHoc(int idDangKyHoc)
        {
            var res = _service.XoaDangKyHoc(idDangKyHoc);
            return Ok(ErrHelper.Log(res));
        }

        [HttpGet]
        public IActionResult HienThiTaiKhoan([FromQuery] Pagination pagination)
        {
            var res = _service.HienThiDangKyHoc(pagination);
            return Ok(res);
        }
    }
}
