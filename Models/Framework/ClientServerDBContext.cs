using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.Framework
{
    public partial class ClientServerDBContext : DbContext
    {
        public ClientServerDBContext()
            : base("name=ClientServerDBContext")
        {
        }

        public virtual DbSet<DanhMucCongNhanThucHienKhoan> DanhMucCongNhanThucHienKhoans { get; set; }
        public virtual DbSet<DanhMucCongViec> DanhMucCongViecs { get; set; }
        public virtual DbSet<DanhMucCongViecDaLam> DanhMucCongViecDaLams { get; set; }
        public virtual DbSet<NhatKiSanLuongKhoan> NhatKiSanLuongKhoans { get; set; }
        public virtual DbSet<ThongTinCongNhan> ThongTinCongNhans { get; set; }
        public virtual DbSet<ThongTinSanPham> ThongTinSanPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMucCongNhanThucHienKhoan>()
                .Property(e => e.ThoiGianBatDauCongViec)
                .HasPrecision(0);

            modelBuilder.Entity<DanhMucCongNhanThucHienKhoan>()
                .Property(e => e.ThoiGianKetThucCongViec)
                .HasPrecision(0);

            modelBuilder.Entity<DanhMucCongViec>()
                .Property(e => e.DonGia)
                .HasPrecision(38, 6);

            modelBuilder.Entity<DanhMucCongViec>()
                .HasMany(e => e.DanhMucCongViecDaLams)
                .WithRequired(e => e.DanhMucCongViec)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhatKiSanLuongKhoan>()
                .Property(e => e.GioBatDau)
                .HasPrecision(0);

            modelBuilder.Entity<NhatKiSanLuongKhoan>()
                .Property(e => e.GioKetThuc)
                .HasPrecision(0);

            modelBuilder.Entity<NhatKiSanLuongKhoan>()
                .HasMany(e => e.DanhMucCongNhanThucHienKhoans)
                .WithRequired(e => e.NhatKiSanLuongKhoan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhatKiSanLuongKhoan>()
                .HasMany(e => e.DanhMucCongViecDaLams)
                .WithRequired(e => e.NhatKiSanLuongKhoan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThongTinCongNhan>()
                .HasMany(e => e.DanhMucCongNhanThucHienKhoans)
                .WithRequired(e => e.ThongTinCongNhan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThongTinSanPham>()
                .Property(e => e.SoDangKy)
                .IsFixedLength();
        }
    }
}
