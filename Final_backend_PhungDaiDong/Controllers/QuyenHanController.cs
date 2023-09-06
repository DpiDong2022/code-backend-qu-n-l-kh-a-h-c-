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
    public class QuyenHanController : ControllerBase
    {
        private readonly QuyenHanService _service;

        public QuyenHanController()
        {
            _service = new QuyenHanService();
        }

        [HttpPost]
        public IActionResult ThemQuyenHan(QuyenHan quyenHanMoi)
        {
            var res = _service.ThemQuyenHan(quyenHanMoi);
            return Ok(ErrHelper.Log(res, "quyền hạn"));
        }

        [HttpPut("suaquyenhan{idQuyenHan}")]
        public IActionResult SuaLoaKhoaHoc(int idQuyenHan, QuyenHan quyenHanMoi)
        {
            var res = _service.SuaQuyenHan(idQuyenHan, quyenHanMoi);
            return Ok(ErrHelper.Log(res));
        }

        [HttpDelete("xoaquyenhan{idQuyenHan}")]
        public IActionResult XoaQuyenHan(int idQuyenHan)
        {
            var res = _service.XoaQuyenHan(idQuyenHan);
            return Ok(ErrHelper.Log(res, "quyền hạn"));
        }

        [HttpGet]
        public IActionResult HienThiQuyenHan([FromQuery] Pagination pagination)
        {
            var res = _service.HienThiQuyenHan(pagination);
            return Ok(res);
        }
    }
}
