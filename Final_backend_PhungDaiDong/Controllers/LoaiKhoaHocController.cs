using Final_backend_PhungDaiDong.Entities;
using Final_backend_PhungDaiDong.Helper;
using Final_backend_PhungDaiDong.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_backend_PhungDaiDong.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class LoaiKhoaHocController : ControllerBase
    {
        private readonly LoaiKhoaHocService _service;

        public LoaiKhoaHocController()
        {
            _service = new LoaiKhoaHocService();
        }

        [HttpPost]
        public IActionResult ThemLoaKhoaHoc(LoaiKhoaHoc loaiKhoaHocMoi)
        {
            var res = _service.ThemLoaiKhoaHoc(loaiKhoaHocMoi);
            return Ok(ErrHelper.Log(res, "loại khóa học"));
        }

        [HttpPut("sualoaikhoahoc{idLoaiKhoaHoc}")]
        public IActionResult SuaLoaKhoaHoc(int idLoaiKhoaHoc, LoaiKhoaHoc loaiKhoaHocMoi)
        {
            var res = _service.SuaLoaiKhoaHoc(idLoaiKhoaHoc, loaiKhoaHocMoi);
            return Ok(ErrHelper.Log(res, "loại khóa học"));
        }

        [HttpDelete("xoaloaikhoahoc{idLoaiKhoaHoc}")]
        public IActionResult XoaLoaKhoaHoc(int idLoaiKhoaHoc)
        {
            var res = _service.XoaLoaiKhoaHoc(idLoaiKhoaHoc);
            return Ok(ErrHelper.Log(res, "loại khóa học "));
        }
    }
}
