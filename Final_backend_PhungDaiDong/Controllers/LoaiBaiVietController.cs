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
    public class LoaiBaiVietController : ControllerBase
    {
        private readonly LoaiBaiVietService _service;

        public LoaiBaiVietController()
        {
            _service = new LoaiBaiVietService();
        }

        [HttpPost]
        public IActionResult ThemLoaiBaiViet(LoaiBaiViet loaiBaiVietMoi)
        {
            var res = _service.ThemLoaiBaiViet(loaiBaiVietMoi);
            return Ok(ErrHelper.Log(res, "Loại bài viết"));
        }

        [HttpPut("sualoaibaiviet{idLoaiBaiViet}")]
        public IActionResult SuaLoaiBaiViet(int idLoaiBaiViet, LoaiBaiViet loaiBaiVietThayThe)
        {
            var res = _service.SuaLoaiBaiViet(idLoaiBaiViet, loaiBaiVietThayThe);
            return Ok(ErrHelper.Log(res, "Loại bài viết"));
        }

        [HttpDelete("xoaloaibaiviet{idLoaiBaiViet}")]
        public IActionResult XoaLoaiBaiViet(int idLoaiBaiViet)
        {
            var res = _service.XoaLoaiBaiViet(idLoaiBaiViet);
            return Ok(ErrHelper.Log(res, "Loại bài viết"));
        }

        [HttpGet]
        public IActionResult HienThiLoaiBaiViet([FromQuery] Pagination pagination)
        {
            var res = _service.HienThiLoaiBaiViet(pagination);
            return Ok(res);
        }
    }
}
