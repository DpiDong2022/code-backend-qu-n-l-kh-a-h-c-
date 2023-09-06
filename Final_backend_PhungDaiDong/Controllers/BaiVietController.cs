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
    public class BaiVietController : ControllerBase
    {
        private readonly BaiVietService _service;

        public BaiVietController()
        {
            _service = new BaiVietService();
        }

        [HttpPost]
        public IActionResult ThemBaiViet(BaiViet baiVietMoi)
        {
            var res = _service.ThemBaiViet(baiVietMoi);
            if (res == ErrorMessage.Themthanhcong)
            {
                return Ok(ErrHelper.Log(res, "Chủ đề"));
            }
            return Ok(ErrHelper.Log(res));
        }

        [HttpPut("suabaiviet{idBaiViet}")]
        public IActionResult SuaBaiViet(int idBaiViet, BaiViet baiVietThayThe)
        {
            var res = _service.SuaBaiViet(idBaiViet, baiVietThayThe);
            if(res == ErrorMessage.thanhcong || res==ErrorMessage.KhongTonTai)
            {
                return Ok(ErrHelper.Log(res, "Chủ đề"));
            }
            return Ok(ErrHelper.Log(res));
        }

        [HttpDelete("xoabaiviet{idBaiViet}")]
        public IActionResult XoaChuDe(int idBaiViet)
        {
            var res = _service.XoaBaiViet(idBaiViet);
            return Ok(ErrHelper.Log(res, "Chủ đề"));
        }

        [HttpGet]
        public IActionResult HienThiChuDe([FromQuery] Pagination pagination, string? tenBaiViet)
        {
            var res = _service.HienThiBaiViet(pagination, tenBaiViet);
            return Ok(res);
        }
    }
}
