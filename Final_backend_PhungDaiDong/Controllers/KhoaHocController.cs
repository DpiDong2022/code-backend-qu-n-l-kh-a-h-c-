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
    public class KhoaHocController : ControllerBase
    {
        private readonly KhoaHocService _service;

        public KhoaHocController()
        {
            _service = new KhoaHocService();
        }

        [HttpPost]
        public IActionResult ThemKhoaHoc(KhoaHoc khoaHocMoi)
        {
            var res = _service.ThemKhoaHoc(khoaHocMoi);
            if (res == ErrorMessage.Themthanhcong)
            {
                return Ok(ErrHelper.Log(res, "Khóa học"));
            }
            return Ok(ErrHelper.Log(res));
        }

        [HttpPut("suakhoahoc{idKhoaHoc}")]
        public IActionResult SuaKhoaHoc(int idKhoaHoc, KhoaHoc khoaHocThayThe)
        {
            var res = _service.SuaKhoaHoc(idKhoaHoc, khoaHocThayThe);
            return Ok(ErrHelper.Log(res,"Khóa học"));
        }

        [HttpDelete("xoakhoahoc{idKhoaHoc}")]
        public IActionResult XoaKhoaHoc(int idKhoaHoc)
        {
            var res = _service.XoaKhoaHoc(idKhoaHoc);
            return Ok(ErrHelper.Log(res, "Khóa học"));
        }

        [HttpGet]
        public IActionResult HienThiKhoaHoc([FromQuery] Pagination pagination, string? tenKhoaHoc)
        {
            var res = _service.HienThiKhoaHoc(pagination, tenKhoaHoc);
            return Ok(res);
        }
    }
}
