﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyProject.DataModels;

namespace MyProject.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyProject.DataModels.ChiTietDonHang", b =>
                {
                    b.Property<int>("MaCtDh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<long>("MaDonHang")
                        .HasColumnType("bigint");

                    b.Property<Guid>("MaHangHoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaCtDh");

                    b.HasIndex("MaDonHang");

                    b.HasIndex("MaHangHoa");

                    b.ToTable("ChiTietDonHang");
                });

            modelBuilder.Entity("MyProject.DataModels.DonHang", b =>
                {
                    b.Property<long>("MaHoaDon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MaKH")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayDat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayGiao")
                        .HasColumnType("datetime2");

                    b.Property<int>("PhuongThucThanhToan")
                        .HasColumnType("int");

                    b.Property<int>("TrangThaiDatHang")
                        .HasColumnType("int");

                    b.HasKey("MaHoaDon");

                    b.HasIndex("MaKH");

                    b.ToTable("DonHang");
                });

            modelBuilder.Entity("MyProject.DataModels.HangHoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ChiTiet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<byte>("GiamGia")
                        .HasColumnType("tinyint");

                    b.Property<string>("Hinh")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int?>("MaLoai")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("SKU")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenHH")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("MaLoai");

                    b.HasIndex("SKU")
                        .IsUnique()
                        .HasFilter("[SKU] IS NOT NULL");

                    b.ToTable("HangHoa");
                });

            modelBuilder.Entity("MyProject.DataModels.Hinh", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LoaiHinh")
                        .HasColumnType("int");

                    b.Property<Guid>("MaLoai")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hinh");
                });

            modelBuilder.Entity("MyProject.DataModels.KhachHang", b =>
                {
                    b.Property<string>("MaKhachHang")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RandomKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKhachHang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.Property<int>("VaiTro")
                        .HasColumnType("int");

                    b.HasKey("MaKhachHang");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("MyProject.DataModels.Loai", b =>
                {
                    b.Property<int>("MaLoai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaLoaiCha")
                        .HasColumnType("int");

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("MaLoai");

                    b.HasIndex("MaLoaiCha");

                    b.ToTable("Loai");
                });

            modelBuilder.Entity("MyProject.DataModels.ChiTietDonHang", b =>
                {
                    b.HasOne("MyProject.DataModels.DonHang", "DonHang")
                        .WithMany("ChiTietDonHangs")
                        .HasForeignKey("MaDonHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyProject.DataModels.HangHoa", "HangHoa")
                        .WithMany()
                        .HasForeignKey("MaHangHoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyProject.DataModels.DonHang", b =>
                {
                    b.HasOne("MyProject.DataModels.KhachHang", "KhachHang")
                        .WithMany("DonHangs")
                        .HasForeignKey("MaKH");
                });

            modelBuilder.Entity("MyProject.DataModels.HangHoa", b =>
                {
                    b.HasOne("MyProject.DataModels.Loai", "Loai")
                        .WithMany()
                        .HasForeignKey("MaLoai");
                });

            modelBuilder.Entity("MyProject.DataModels.Loai", b =>
                {
                    b.HasOne("MyProject.DataModels.Loai", "LoaiCha")
                        .WithMany()
                        .HasForeignKey("MaLoaiCha");
                });
#pragma warning restore 612, 618
        }
    }
}
