using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MyeStoreProject.ViewModels;

namespace MyeStoreProject.Models
{
    public partial class eStore20Context : DbContext
    {
        public eStore20Context()
        {
        }

        public eStore20Context(DbContextOptions<eStore20Context> options)
            : base(options)
        {
        }

        public virtual DbSet<BanBe> BanBe { get; set; }
        public virtual DbSet<CauHinh> CauHinh { get; set; }
        public virtual DbSet<ChiTietHd> ChiTietHd { get; set; }
        public virtual DbSet<ChuDe> ChuDe { get; set; }
        public virtual DbSet<GopY> GopY { get; set; }
        public virtual DbSet<HangHoa> HangHoa { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<HoiDap> HoiDap { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<Loai> Loai { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCap { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<YeuThich> YeuThich { get; set; }
        public DbQuery<ChiTietHoaDonViewModel> ChiTietHoaDonViewModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=eStore20;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BanBe>(entity =>
            {
                entity.HasKey(e => e.MaBb)
                    .HasName("PK_Promotions");

                entity.Property(e => e.MaBb).HasColumnName("MaBB");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.MaHh).HasColumnName("MaHH");

                entity.Property(e => e.MaKh)
                    .HasColumnName("MaKH")
                    .HasMaxLength(20);

                entity.Property(e => e.NgayGui)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.MaHhNavigation)
                    .WithMany(p => p.BanBe)
                    .HasForeignKey(d => d.MaHh)
                    .HasConstraintName("FK_QuangBa_HangHoa");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.BanBe)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("FK_BanBe_KhachHang");
            });

            modelBuilder.Entity<CauHinh>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.SoNgayHetHanQc).HasColumnName("SoNgayHetHanQC");
            });

            modelBuilder.Entity<ChiTietHd>(entity =>
            {
                entity.HasKey(e => e.MaCt)
                    .HasName("PK_OrderDetails");

                entity.ToTable("ChiTietHD");

                entity.Property(e => e.MaCt).HasColumnName("MaCT");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.MaHh).HasColumnName("MaHH");

                entity.Property(e => e.SoLuong).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.ChiTietHd)
                    .HasForeignKey(d => d.MaHd)
                    .HasConstraintName("FK_OrderDetails_Orders");

                entity.HasOne(d => d.MaHhNavigation)
                    .WithMany(p => p.ChiTietHd)
                    .HasForeignKey(d => d.MaHh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Products");
            });

            modelBuilder.Entity<ChuDe>(entity =>
            {
                entity.HasKey(e => e.MaCd);

                entity.Property(e => e.MaCd).HasColumnName("MaCD");

                entity.Property(e => e.MaNv)
                    .HasColumnName("MaNV")
                    .HasMaxLength(50);

                entity.Property(e => e.TenCd)
                    .HasColumnName("TenCD")
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.ChuDe)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ChuDe_NhanVien");
            });

            modelBuilder.Entity<GopY>(entity =>
            {
                entity.HasKey(e => e.MaGy);

                entity.Property(e => e.MaGy)
                    .HasColumnName("MaGY")
                    .HasMaxLength(50);

                entity.Property(e => e.DienThoai).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.MaCd).HasColumnName("MaCD");

                entity.Property(e => e.NgayGy)
                    .HasColumnName("NgayGY")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NgayTl)
                    .HasColumnName("NgayTL")
                    .HasColumnType("date");

                entity.Property(e => e.NoiDung).IsRequired();

                entity.Property(e => e.TraLoi).HasMaxLength(50);

                entity.HasOne(d => d.MaCdNavigation)
                    .WithMany(p => p.GopY)
                    .HasForeignKey(d => d.MaCd)
                    .HasConstraintName("FK_GopY_ChuDe");
            });

            modelBuilder.Entity<HangHoa>(entity =>
            {
                entity.HasKey(e => e.MaHh)
                    .HasName("PK_Products");

                entity.Property(e => e.MaHh).HasColumnName("MaHH");

                entity.Property(e => e.DonGia).HasDefaultValueSql("((0))");

                entity.Property(e => e.Hinh).HasMaxLength(50);

                entity.Property(e => e.MaNcc)
                    .IsRequired()
                    .HasColumnName("MaNCC")
                    .HasMaxLength(50);

                entity.Property(e => e.MoTaDonVi).HasMaxLength(50);

                entity.Property(e => e.NgaySx)
                    .HasColumnName("NgaySX")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TenHh)
                    .IsRequired()
                    .HasColumnName("TenHH")
                    .HasMaxLength(40);

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.HangHoa)
                    .HasForeignKey(d => d.MaLoai)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.HangHoa)
                    .HasForeignKey(d => d.MaNcc)
                    .HasConstraintName("FK_Products_Suppliers");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK_Orders");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.CachThanhToan)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Cash')");

                entity.Property(e => e.CachVanChuyen)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Airline')");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.MaKh)
                    .IsRequired()
                    .HasColumnName("MaKH")
                    .HasMaxLength(20);

                entity.Property(e => e.MaVn)
                    .HasColumnName("MaVN")
                    .HasMaxLength(50);

                entity.Property(e => e.NgayCan)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NgayDat)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NgayGiao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1)/(1))/(1900))");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Customers");

                entity.HasOne(d => d.MaVnNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.MaVn)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_HoaDon_NhanVien");
            });

            modelBuilder.Entity<HoiDap>(entity =>
            {
                entity.HasKey(e => e.MaHd);

                entity.Property(e => e.MaHd)
                    .HasColumnName("MaHD")
                    .ValueGeneratedNever();

                entity.Property(e => e.CauHoi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaNv)
                    .IsRequired()
                    .HasColumnName("MaNV")
                    .HasMaxLength(50);

                entity.Property(e => e.NgayDua)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TraLoi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.HoiDap)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("FK_HoiDap_NhanVien");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh)
                    .HasName("PK_Customers");

                entity.Property(e => e.MaKh)
                    .HasColumnName("MaKH")
                    .HasMaxLength(20);

                entity.Property(e => e.DiaChi).HasMaxLength(60);

                entity.Property(e => e.DienThoai).HasMaxLength(24);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Hinh)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Photo.gif')");

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MatKhau).HasMaxLength(50);

                entity.Property(e => e.NgaySinh)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Loai>(entity =>
            {
                entity.HasKey(e => e.MaLoai)
                    .HasName("PK_Categories");

                entity.Property(e => e.Hinh).HasMaxLength(50);

                entity.Property(e => e.TenLoai)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DiaChi).HasMaxLength(60);

                entity.Property(e => e.DienThoai).HasMaxLength(24);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Hinh).HasMaxLength(50);

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaNd)
                    .IsRequired()
                    .HasColumnName("MaND")
                    .HasMaxLength(20);

                entity.Property(e => e.MatKhau).HasMaxLength(50);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.MaNcc)
                    .HasName("PK_Suppliers");

                entity.Property(e => e.MaNcc)
                    .HasColumnName("MaNCC")
                    .HasMaxLength(50);

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.DienThoai).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NguoiLienLac).HasMaxLength(50);

                entity.Property(e => e.TenCongTy)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv);

                entity.Property(e => e.MaNv)
                    .HasColumnName("MaNV")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MatKhau).HasMaxLength(50);
            });

            modelBuilder.Entity<YeuThich>(entity =>
            {
                entity.HasKey(e => e.MaYt)
                    .HasName("PK_Favorites");

                entity.Property(e => e.MaYt).HasColumnName("MaYT");

                entity.Property(e => e.MaHh).HasColumnName("MaHH");

                entity.Property(e => e.MaKh)
                    .HasColumnName("MaKH")
                    .HasMaxLength(20);

                entity.Property(e => e.MoTa).HasMaxLength(255);

                entity.Property(e => e.NgayChon).HasColumnType("datetime");

                entity.HasOne(d => d.MaHhNavigation)
                    .WithMany(p => p.YeuThich)
                    .HasForeignKey(d => d.MaHh)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_YeuThich_HangHoa");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.YeuThich)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Favorites_Customers");
            });

            //nếu là code first
            //modelBuilder.Query(@"create view ChiTietHoaDonView AS select cthd.MaHD, lo.TenLoai, hh.TenHH, cthd.DonGia, cthd.SoLuong, cthd.GiamGia, 	cthd.DonGia * cthd.SoLuong * (1 - cthd.GiamGia) 	as ThanhTien from ChiTietHD cthd JOIN HangHoa hh 	ON hh.MaHH = cthd.MaHH oin Loai lo ON lo.MaLoai = hh.MaLoai");

            //OnModelCreating()
            modelBuilder.Query<ChiTietHoaDonViewModel>().ToView("ChiTietHoaDonView");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
