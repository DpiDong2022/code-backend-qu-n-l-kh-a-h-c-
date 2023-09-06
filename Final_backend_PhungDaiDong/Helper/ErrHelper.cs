using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_backend_PhungDaiDong.Helper
{
    public enum ErrorMessage
    {
        Themthanhcong,
        Xoathanhcong,
        Suathanhcong,
        thanhcong,
        MuaThanhCong,
        KhongTonTai,
        CapNhatThanhCong,
        datontai,
        hople,
        MKkhongCoSo,
        MKkhongCoKiTuDacBiet,
        emailDaTontai,
        SDTdatontai,
        loaiBvietKTonTai,
        chudekotontai,
        taikhoankotontai,
        LoaiKhoaHockoTontai,
        kotontaihocvien,
        kotontaiKhoaHoc,
        tinhTrangKoTontai,
        koTheChuyenSangChoDuyet
    }

    class ErrHelper
    {
        public static string Log(ErrorMessage em, string? ObjectName="")
        {
            switch (em)
            {
                case ErrorMessage.thanhcong:
                    return "Thực hiện thành công";
                case ErrorMessage.Themthanhcong:
                    return $"Thêm {ObjectName} thành công";
                case ErrorMessage.Xoathanhcong:
                    return $"Xóa {ObjectName} thành công";
                case ErrorMessage.Suathanhcong:
                    return $"Sửa {ObjectName} thành công";
                case ErrorMessage.MuaThanhCong:
                    return "Mua san pham thanh cong";
                case ErrorMessage.KhongTonTai:
                    return $"{ObjectName} không tồn tai";
                case ErrorMessage.datontai:
                    return $"{ObjectName} đã tồn tại";
                case ErrorMessage.CapNhatThanhCong:
                    return "Cap nhat thanh cong";
                case ErrorMessage.hople:
                    return $"{ObjectName} hợp lệ";
                case ErrorMessage.MKkhongCoSo:
                    return "Mật khẩu phải chứa ít nhất một chữ số";
                case ErrorMessage.MKkhongCoKiTuDacBiet:
                    return "Mật khẩu phải chứa ít nhất một ký tự đặc biệt";
                case ErrorMessage.emailDaTontai:
                    return "Email đã tồn tại";
                case ErrorMessage.SDTdatontai:
                    return "Số điên thoại đã tồn tại";
                case ErrorMessage.loaiBvietKTonTai:
                    return "Loại bài viết không tồn tại";
                case ErrorMessage.chudekotontai:
                    return " Chủ đề không tồn tại";
                case ErrorMessage.taikhoankotontai:
                    return "Tài khoản không tồn tại";
                case ErrorMessage.LoaiKhoaHockoTontai:
                    return "Loại khóa học không tồn tại";
                case ErrorMessage.kotontaihocvien:
                    return "Học viên không tồn tại";
                case ErrorMessage.kotontaiKhoaHoc:
                    return "Khóa học không tồn tại";
                case ErrorMessage.tinhTrangKoTontai:
                    return "Tình trạng học không tồn tại";
                case ErrorMessage.koTheChuyenSangChoDuyet:
                    return "Không thể chuyển sang tình trạng chờ duyệt(đây là tình trạng tự động khi người dùng mới đăng kí)";
                default:
                    return "Khong xac dinh";
            }
        }
    }
}
