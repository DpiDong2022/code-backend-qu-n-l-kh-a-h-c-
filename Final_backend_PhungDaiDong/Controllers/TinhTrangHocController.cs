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
    public class TinhTrangHocController : ControllerBase
    {
        private readonly TinhTrangHocService _service;

        public TinhTrangHocController()
        {
            _service = new TinhTrangHocService();
        }

        [HttpPost]
        public IActionResult ThemTinhTrangHoc(TinhTrangHoc tinhTrangHocMoi)
        {
            var res = _service.ThemTinhTrangHoc(tinhTrangHocMoi);
            return Ok(ErrHelper.Log(res));
        }

        [HttpPut("suatinhtranghoc{idTinhTrangHoc}")]
        public IActionResult SuaTinhTrangHoc(int idTinhTrangHoc, TinhTrangHoc tinhTrangHocMoi)
        {
            var res = _service.SuaTinhTrangHoc(idTinhTrangHoc, tinhTrangHocMoi);
            return Ok(ErrHelper.Log(res,"Tình Trạng học"));
        }

        [HttpDelete("xoatinhtranghoc{idTinhTrangHoc}")]
        public IActionResult XoaTinhTrangHoc(int idTinhTrangHoc)
        {
            var res = _service.XoaTinhTrangHoc(idTinhTrangHoc);
            return Ok(ErrHelper.Log(res,"Tình trạng học"));
        }

        [HttpGet]
        public IActionResult HienThiTinhTrangHoc([FromQuery] Pagination pagination)
        {
            var res = _service.HienThiCacTinhTrangHoc(pagination);
            return Ok(res);
        }
    }
}
