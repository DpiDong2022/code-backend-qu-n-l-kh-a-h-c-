﻿// <auto-generated />
using System;
using Final_backend_PhungDaiDong.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Final_backend_PhungDaiDong.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.BaiViet", b =>
                {
                    b.Property<int>("BaiVietID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BaiVietID"));

                    b.Property<int>("ChuDeID")
                        .HasColumnType("int");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoiDungNgan")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("TaiKhoanID")
                        .HasColumnType("int");

                    b.Property<string>("TenBaiViet")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenTacGia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ThoiGianTao")
                        .HasColumnType("datetime2");

                    b.HasKey("BaiVietID");

                    b.HasIndex("ChuDeID");

                    b.HasIndex("TaiKhoanID");

                    b.ToTable("BaiViet");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.ChuDe", b =>
                {
                    b.Property<int>("ChuDeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChuDeID"));

                    b.Property<int>("LoaiBaiVietID")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenChuDe")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ChuDeID");

                    b.HasIndex("LoaiBaiVietID");

                    b.ToTable("ChuDe");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.DangKyHoc", b =>
                {
                    b.Property<int>("DangKyHocID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DangKyHocID"));

                    b.Property<int>("HocVienID")
                        .HasColumnType("int");

                    b.Property<int>("KhoaHocID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayDangKy")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<int>("TaiKhoanID")
                        .HasColumnType("int");

                    b.Property<int>("TinhTrangHocID")
                        .HasColumnType("int");

                    b.HasKey("DangKyHocID");

                    b.HasIndex("HocVienID");

                    b.HasIndex("KhoaHocID");

                    b.HasIndex("TaiKhoanID");

                    b.HasIndex("TinhTrangHocID");

                    b.ToTable("DangKyHoc");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.HocVien", b =>
                {
                    b.Property<int>("HocVienID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HocVienID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("DATE");

                    b.Property<string>("PhuongXa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("QuanHuyen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("SoNha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("TinhThanh")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("HocVienID");

                    b.ToTable("HocVien");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.KhoaHoc", b =>
                {
                    b.Property<int>("KhoaHocID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KhoaHocID"));

                    b.Property<string>("GioiThieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("HocPhi")
                        .HasColumnType("float");

                    b.Property<int>("LoaiKhoaHocID")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoHocVien")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongMon")
                        .HasColumnType("int");

                    b.Property<string>("TenKhoaHoc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ThoiGianHoc")
                        .HasColumnType("int");

                    b.HasKey("KhoaHocID");

                    b.HasIndex("LoaiKhoaHocID");

                    b.ToTable("KhoaHoc");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.LoaiBaiViet", b =>
                {
                    b.Property<int>("LoaiBaiVietID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoaiBaiVietID"));

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LoaiBaiVietID");

                    b.ToTable("LoaiBaiViet");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.LoaiKhoaHoc", b =>
                {
                    b.Property<int>("LoaiKhoaHocID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoaiKhoaHocID"));

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("LoaiKhoaHocID");

                    b.ToTable("LoaiKhoaHoc");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.QuyenHan", b =>
                {
                    b.Property<int>("QuyenHanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuyenHanID"));

                    b.Property<string>("TenQuyenHan")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("QuyenHanID");

                    b.ToTable("QuyenHan");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.TaiKhoan", b =>
                {
                    b.Property<int>("TaiKhoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaiKhoanID"));

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("QuyenHanID")
                        .HasColumnType("int");

                    b.Property<string>("TenDangNhap")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenNguoiDung")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TaiKhoanID");

                    b.HasIndex("QuyenHanID");

                    b.ToTable("TaiKhoan");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.TinhTrangHoc", b =>
                {
                    b.Property<int>("TinhTrangHocID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TinhTrangHocID"));

                    b.Property<string>("TenTinhTrang")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("TinhTrangHocID");

                    b.ToTable("TinhTrangHoc");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.BaiViet", b =>
                {
                    b.HasOne("Final_backend_PhungDaiDong.Entities.ChuDe", "chuDe")
                        .WithMany("BaiVietList")
                        .HasForeignKey("ChuDeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Final_backend_PhungDaiDong.Entities.TaiKhoan", "taiKhoan")
                        .WithMany("BaiVietList")
                        .HasForeignKey("TaiKhoanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("chuDe");

                    b.Navigation("taiKhoan");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.ChuDe", b =>
                {
                    b.HasOne("Final_backend_PhungDaiDong.Entities.LoaiBaiViet", "loaiBaiViet")
                        .WithMany("ChuDeList")
                        .HasForeignKey("LoaiBaiVietID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("loaiBaiViet");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.DangKyHoc", b =>
                {
                    b.HasOne("Final_backend_PhungDaiDong.Entities.HocVien", "hocVien")
                        .WithMany("DangKyHocList")
                        .HasForeignKey("HocVienID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Final_backend_PhungDaiDong.Entities.KhoaHoc", "khoaHoc")
                        .WithMany("DangKyHocList")
                        .HasForeignKey("KhoaHocID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Final_backend_PhungDaiDong.Entities.TaiKhoan", "taiKhoan")
                        .WithMany("DangKyHocList")
                        .HasForeignKey("TaiKhoanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Final_backend_PhungDaiDong.Entities.TinhTrangHoc", "tinhTrangHoc")
                        .WithMany("DangKyHocList")
                        .HasForeignKey("TinhTrangHocID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hocVien");

                    b.Navigation("khoaHoc");

                    b.Navigation("taiKhoan");

                    b.Navigation("tinhTrangHoc");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.KhoaHoc", b =>
                {
                    b.HasOne("Final_backend_PhungDaiDong.Entities.LoaiKhoaHoc", "loaiKhoaHoc")
                        .WithMany("KhoaHocList")
                        .HasForeignKey("LoaiKhoaHocID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("loaiKhoaHoc");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.TaiKhoan", b =>
                {
                    b.HasOne("Final_backend_PhungDaiDong.Entities.QuyenHan", "quyenHan")
                        .WithMany("TaiKhoanList")
                        .HasForeignKey("QuyenHanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("quyenHan");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.ChuDe", b =>
                {
                    b.Navigation("BaiVietList");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.HocVien", b =>
                {
                    b.Navigation("DangKyHocList");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.KhoaHoc", b =>
                {
                    b.Navigation("DangKyHocList");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.LoaiBaiViet", b =>
                {
                    b.Navigation("ChuDeList");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.LoaiKhoaHoc", b =>
                {
                    b.Navigation("KhoaHocList");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.QuyenHan", b =>
                {
                    b.Navigation("TaiKhoanList");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.TaiKhoan", b =>
                {
                    b.Navigation("BaiVietList");

                    b.Navigation("DangKyHocList");
                });

            modelBuilder.Entity("Final_backend_PhungDaiDong.Entities.TinhTrangHoc", b =>
                {
                    b.Navigation("DangKyHocList");
                });
#pragma warning restore 612, 618
        }
    }
}
