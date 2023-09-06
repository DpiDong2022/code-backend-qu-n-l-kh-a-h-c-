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
    public class HocVienController : ControllerBase
    {
        private readonly HocVienService _service;

        public HocVienController()
        {
            _service = new HocVienService();
        }

        [HttpPost]
        public IActionResult ThemHocVien(HocVien hocVienMoi)
        {
            var res = _service.ThemHocVien(hocVienMoi);
            return Ok(ErrHelper.Log(res, "hoc viên")); 
        }

        [HttpPut("suahocvien{idHocVien}")]
        public IActionResult SuaHocVien(int idHocVien, HocVien hocVienThayThe)
        {
            var res = _service.SuaHocVien(idHocVien, hocVienThayThe);
            if (res == ErrorMessage.KhongTonTai)
            {
                return Ok(ErrHelper.Log(res, "Học viên"));
            }
            return Ok(ErrHelper.Log(res));
        }

        [HttpDelete("xoahocvien{idHocVien}")]
        public IActionResult XoaHocVien(int idHocVien)
        {
            var res = _service.XoaHocVien(idHocVien);
            return Ok(ErrHelper.Log(res, "hoc viên"));
        }

        [HttpGet]
        public IActionResult HienThiHocVien([FromQuery] Pagination pagination, string? searchkey)
        {
            var res = _service.HienThiHocVien(pagination, searchkey);
            return Ok(res);
        }
    }
}
