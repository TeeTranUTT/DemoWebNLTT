using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DemoWebNLTT.Models
{
    public partial class TTDLContext : DbContext
    {
        public TTDLContext()
        {
        }

        public TTDLContext(DbContextOptions<TTDLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblNangLuong> TblNangLuongs { get; set; }
        public virtual DbSet<TblTaiKhoan> TblTaiKhoans { get; set; }
        public virtual DbSet<TblThongSoNangLuong> TblThongSoNangLuongs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-0DT0F8D\\SQLEXPRESS2017; Initial Catalog=TTDL;User ID=sa;Password=0969605418;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblNangLuong>(entity =>
            {
                entity.ToTable("tbl_NangLuong");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CsHientai)
                    .HasMaxLength(50)
                    .HasColumnName("CS_HIENTAI");

                entity.Property(e => e.CsMax)
                    .HasMaxLength(50)
                    .HasColumnName("CS_MAX");

                entity.Property(e => e.CsThietke)
                    .HasMaxLength(50)
                    .HasColumnName("CS_THIETKE");

                entity.Property(e => e.SanluongNgay)
                    .HasMaxLength(50)
                    .HasColumnName("SANLUONG_NGAY");

                entity.Property(e => e.TenTieude)
                    .HasMaxLength(50)
                    .HasColumnName("TEN_TIEUDE");

                entity.Property(e => e.Tgian)
                    .HasColumnType("datetime")
                    .HasColumnName("TGian");
            });

            modelBuilder.Entity<TblTaiKhoan>(entity =>
            {
                entity.ToTable("tbl_TaiKhoan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(500)
                    .HasColumnName("MAT_KHAU");

                entity.Property(e => e.NgayHieuluc)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAY_HIEULUC");

                entity.Property(e => e.TenDangnhap)
                    .HasMaxLength(50)
                    .HasColumnName("TEN_DANGNHAP");

                entity.Property(e => e.TenTaikhoan)
                    .HasMaxLength(50)
                    .HasColumnName("TEN_TAIKHOAN");

                entity.Property(e => e.TrangThai).HasColumnName("TRANG_THAI");
            });

            modelBuilder.Entity<TblThongSoNangLuong>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_ThongSoNangLuong");

                entity.Property(e => e.GioCshienTai).HasColumnName("Gio_CSHienTai");

                entity.Property(e => e.GioCsmax).HasColumnName("Gio_CSMax");

                entity.Property(e => e.GioCssanLuongNgay).HasColumnName("Gio_CSSanLuongNgay");

                entity.Property(e => e.GioCsthietKe).HasColumnName("Gio_CSThietKe");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.MtCshienTai).HasColumnName("MT_CSHienTai");

                entity.Property(e => e.MtCsmax).HasColumnName("MT_CSMax");

                entity.Property(e => e.MtCssanLuongNgay).HasColumnName("MT_CSSanLuongNgay");

                entity.Property(e => e.MtCsthietKe).HasColumnName("MT_CSThietKe");

                entity.Property(e => e.SkCshienTai).HasColumnName("SK_CSHienTai");

                entity.Property(e => e.SkCsmax).HasColumnName("SK_CSMax");

                entity.Property(e => e.SkCssanLuongNgay).HasColumnName("SK_CSSanLuongNgay");

                entity.Property(e => e.SkCsthietKe).HasColumnName("SK_CSThietKe");

                entity.Property(e => e.Tgian).HasColumnType("datetime");

                entity.Property(e => e.TongCshienTai).HasColumnName("Tong_CSHienTai");

                entity.Property(e => e.TongCsmax).HasColumnName("Tong_CSMax");

                entity.Property(e => e.TongCssanLuongNgay).HasColumnName("Tong_CSSanLuongNgay");

                entity.Property(e => e.TongCsthietKe).HasColumnName("Tong_CSThietKe");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
