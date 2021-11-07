using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ClientServer.Models.EntityFramework
{
    public partial class ClientServerDbContext : DbContext
    {
        public ClientServerDbContext()
            : base("name=ClientServerDbContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<DanhMucCongNhanThucHienKhoan> DanhMucCongNhanThucHienKhoans { get; set; }
        public virtual DbSet<DanhMucCongViec> DanhMucCongViecs { get; set; }
        public virtual DbSet<DanhMucCongViecDaLam> DanhMucCongViecDaLams { get; set; }
        public virtual DbSet<NhatKiSanLuongKhoan> NhatKiSanLuongKhoans { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThongTinCongNhan> ThongTinCongNhans { get; set; }
        public virtual DbSet<ThongTinSanPham> ThongTinSanPhams { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucCongViec>()
                .Property(e => e.DonGia)
                .HasPrecision(38, 6);

            modelBuilder.Entity<DanhMucCongViec>()
                .HasMany(e => e.DanhMucCongViecDaLams)
                .WithRequired(e => e.DanhMucCongViec)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<UserGroup>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<UserGroup>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
