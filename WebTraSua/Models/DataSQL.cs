namespace WebTraSua.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataSQL : DbContext
    {
        public DataSQL()
            : base("name=DataSQL")
        {
        }

        public virtual DbSet<CTHoaDon> CTHoaDons { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<PTThanhToan> PTThanhToans { get; set; }
        public virtual DbSet<ResetPass> ResetPasses { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TinhTrang> TinhTrangs { get; set; }
        public virtual DbSet<Topping> Toppings { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTHoaDon>()
                .Property(e => e.Gia)
                .HasPrecision(10, 0);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.maPT)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.CTHoaDons)
                .WithOptional(e => e.HoaDon)
                .HasForeignKey(e => e.ID_HoaDon);

            modelBuilder.Entity<LoaiSanPham>()
                .Property(e => e.maLoai)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.maTinhTrang)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.NguoiDung)
                .HasForeignKey(e => e.ID_NguoiDung);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.ResetPasses)
                .WithOptional(e => e.NguoiDung)
                .HasForeignKey(e => e.ID_NguoiDung);

            modelBuilder.Entity<PTThanhToan>()
                .Property(e => e.maPT)
                .IsUnicode(false);

            modelBuilder.Entity<ResetPass>()
                .Property(e => e.maRS)
                .IsUnicode(false);

            modelBuilder.Entity<ResetPass>()
                .Property(e => e.ThoiHan)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Gia)
                .HasPrecision(10, 0);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Anh)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.maLoai)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.maTinhTrang)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.CTHoaDons)
                .WithOptional(e => e.SanPham)
                .HasForeignKey(e => e.ID_SanPham);

            modelBuilder.Entity<TinhTrang>()
                .Property(e => e.maTinhTrang)
                .IsUnicode(false);

            modelBuilder.Entity<Topping>()
                .Property(e => e.Gia)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Topping>()
                .Property(e => e.maTinhTrang)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<WebTraSua.Models.GioHang> GioHangs { get; set; }
    }
}
