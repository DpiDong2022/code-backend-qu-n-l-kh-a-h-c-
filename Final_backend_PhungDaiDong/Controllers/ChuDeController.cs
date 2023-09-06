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
    public class ChuDeController : ControllerBase
    {
        private readonly ChuDeService _service;

        public ChuDeController()
        {
            _service = new ChuDeService();
        }

        [HttpPost]
        public IActionResult ThemChuDe(ChuDe chuDeMoi)
        {
            var res = _service.ThemChuDe(chuDeMoi);
            if(res == ErrorMessage.Themthanhcong)
            {
                return Ok(ErrHelper.Log(res, "Chủ đề"));
            }
            return Ok(ErrHelper.Log(res, "Loại bài viết"));
        }

        [HttpPut("suachude{idChuDe}")]
        public IActionResult SuaChuDe(int idChuDe, ChuDe chuDeThayThe)
        {
            var res = _service.SuaChuDe(idChuDe, chuDeThayThe);
            return Ok(ErrHelper.Log(res, "Chủ đề"));
        }

        [HttpDelete("xoachude{idChuDe}")]
        public IActionResult XoaChuDe(int idChuDe)
        {
            var res = _service.XoaChuDe(idChuDe);
            return Ok(ErrHelper.Log(res, "Chủ đề"));
        }

        [HttpGet]
        public IActionResult HienThiChuDe([FromQuery] Pagination pagination)
        {
            var res = _service.HienThiChuDe(pagination);
            return Ok(res);
        }
    }
}
