using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_backend_PhungDaiDong.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HocVien",
                columns: table => new
                {
                    HocVienID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "DATE", nullable: false),
                    SoDienThoai = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    TinhThanh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    QuanHuyen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhuongXa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoNha = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocVien", x => x.HocVienID);
                });

            migrationBuilder.CreateTable(
                name: "LoaiBaiViet",
                columns: table => new
                {
                    LoaiBaiVietID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiBaiViet", x => x.LoaiBaiVietID);
                });

            migrationBuilder.CreateTable(
                name: "LoaiKhoaHoc",
                columns: table => new
                {
                    LoaiKhoaHocID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiKhoaHoc", x => x.LoaiKhoaHocID);
                });

            migrationBuilder.CreateTable(
                name: "QuyenHan",
                columns: table => new
                {
                    QuyenHanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyenHan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenHan", x => x.QuyenHanID);
                });

            migrationBuilder.CreateTable(
                name: "TinhTrangHoc",
                columns: table => new
                {
                    TinhTrangHocID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTinhTrang = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhTrangHoc", x => x.TinhTrangHocID);
                });

            migrationBuilder.CreateTable(
                name: "ChuDe",
                columns: table => new
                {
                    ChuDeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChuDe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiBaiVietID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuDe", x => x.ChuDeID);
                    table.ForeignKey(
                        name: "FK_ChuDe_LoaiBaiViet_LoaiBaiVietID",
                        column: x => x.LoaiBaiVietID,
                        principalTable: "LoaiBaiViet",
                        principalColumn: "LoaiBaiVietID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhoaHoc",
                columns: table => new
                {
                    KhoaHocID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoaHoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ThoiGianHoc = table.Column<int>(type: "int", nullable: false),
                    GioiThieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HocPhi = table.Column<double>(type: "float", nullable: false),
                    SoHocVien = table.Column<int>(type: "int", nullable: false),
                    SoLuongMon = table.Column<int>(type: "int", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiKhoaHocID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoaHoc", x => x.KhoaHocID);
                    table.ForeignKey(
                        name: "FK_KhoaHoc_LoaiKhoaHoc_LoaiKhoaHocID",
                        column: x => x.LoaiKhoaHocID,
                        principalTable: "LoaiKhoaHoc",
                        principalColumn: "LoaiKhoaHocID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    TaiKhoanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNguoiDung = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenDangNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    QuyenHanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.TaiKhoanID);
                    table.ForeignKey(
                        name: "FK_TaiKhoan_QuyenHan_QuyenHanID",
                        column: x => x.QuyenHanID,
                        principalTable: "QuyenHan",
                        principalColumn: "QuyenHanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaiViet",
                columns: table => new
                {
                    BaiVietID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBaiViet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenTacGia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDungNgan = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChuDeID = table.Column<int>(type: "int", nullable: false),
                    TaiKhoanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiViet", x => x.BaiVietID);
                    table.ForeignKey(
                        name: "FK_BaiViet_ChuDe_ChuDeID",
                        column: x => x.ChuDeID,
                        principalTable: "ChuDe",
                        principalColumn: "ChuDeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaiViet_TaiKhoan_TaiKhoanID",
                        column: x => x.TaiKhoanID,
                        principalTable: "TaiKhoan",
                        principalColumn: "TaiKhoanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DangKyHoc",
                columns: table => new
                {
                    DangKyHocID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhoaHocID = table.Column<int>(type: "int", nullable: false),
                    HocVienID = table.Column<int>(type: "int", nullable: false),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TinhTrangHocID = table.Column<int>(type: "int", nullable: false),
                    TaiKhoanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKyHoc", x => x.DangKyHocID);
                    table.ForeignKey(
                        name: "FK_DangKyHoc_HocVien_HocVienID",
                        column: x => x.HocVienID,
                        principalTable: "HocVien",
                        principalColumn: "HocVienID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DangKyHoc_KhoaHoc_KhoaHocID",
                        column: x => x.KhoaHocID,
                        principalTable: "KhoaHoc",
                        principalColumn: "KhoaHocID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DangKyHoc_TaiKhoan_TaiKhoanID",
                        column: x => x.TaiKhoanID,
                        principalTable: "TaiKhoan",
                        principalColumn: "TaiKhoanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DangKyHoc_TinhTrangHoc_TinhTrangHocID",
                        column: x => x.TinhTrangHocID,
                        principalTable: "TinhTrangHoc",
                        principalColumn: "TinhTrangHocID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_ChuDeID",
                table: "BaiViet",
                column: "ChuDeID");

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_TaiKhoanID",
                table: "BaiViet",
                column: "TaiKhoanID");

            migrationBuilder.CreateIndex(
                name: "IX_ChuDe_LoaiBaiVietID",
                table: "ChuDe",
                column: "LoaiBaiVietID");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHoc_HocVienID",
                table: "DangKyHoc",
                column: "HocVienID");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHoc_KhoaHocID",
                table: "DangKyHoc",
                column: "KhoaHocID");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHoc_TaiKhoanID",
                table: "DangKyHoc",
                column: "TaiKhoanID");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHoc_TinhTrangHocID",
                table: "DangKyHoc",
                column: "TinhTrangHocID");

            migrationBuilder.CreateIndex(
                name: "IX_KhoaHoc_LoaiKhoaHocID",
                table: "KhoaHoc",
                column: "LoaiKhoaHocID");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_QuyenHanID",
                table: "TaiKhoan",
                column: "QuyenHanID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaiViet");

            migrationBuilder.DropTable(
                name: "DangKyHoc");

            migrationBuilder.DropTable(
                name: "ChuDe");

            migrationBuilder.DropTable(
                name: "HocVien");

            migrationBuilder.DropTable(
                name: "KhoaHoc");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "TinhTrangHoc");

            migrationBuilder.DropTable(
                name: "LoaiBaiViet");

            migrationBuilder.DropTable(
                name: "LoaiKhoaHoc");

            migrationBuilder.DropTable(
                name: "QuyenHan");
        }
    }
}
