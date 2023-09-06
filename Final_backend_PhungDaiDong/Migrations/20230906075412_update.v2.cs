using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_backend_PhungDaiDong.Migrations
{
    /// <inheritdoc />
    public partial class updatev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHoc_TinhTrangHoc_TinhTrangHocID",
                table: "DangKyHoc");

            migrationBuilder.AlterColumn<int>(
                name: "TinhTrangHocID",
                table: "DangKyHoc",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHoc_TinhTrangHoc_TinhTrangHocID",
                table: "DangKyHoc",
                column: "TinhTrangHocID",
                principalTable: "TinhTrangHoc",
                principalColumn: "TinhTrangHocID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHoc_TinhTrangHoc_TinhTrangHocID",
                table: "DangKyHoc");

            migrationBuilder.AlterColumn<int>(
                name: "TinhTrangHocID",
                table: "DangKyHoc",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHoc_TinhTrangHoc_TinhTrangHocID",
                table: "DangKyHoc",
                column: "TinhTrangHocID",
                principalTable: "TinhTrangHoc",
                principalColumn: "TinhTrangHocID");
        }
    }
}
