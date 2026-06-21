using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend_netcore_dotnet06.Models.DBQuanLyNhanVien;

public partial class QuanLyNhanVienContext : DbContext
{
    public QuanLyNhanVienContext()
    {
    }

    public QuanLyNhanVienContext(DbContextOptions<QuanLyNhanVienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhongBan> PhongBans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DBQuanLyNhanVienConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NhanVien__3214EC076B48F90A");

            entity.ToTable("NhanVien");

            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.MaPb).HasColumnName("MaPB");
            entity.Property(e => e.SoDienThoai).HasMaxLength(15);
            entity.Property(e => e.TenNv)
                .HasMaxLength(100)
                .HasColumnName("TenNV");

            entity.HasOne(d => d.MaPbNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaPb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NhanVien_PhongBan");

            entity.HasOne(d => d.MaTruongPhongNavigation).WithMany(p => p.InverseMaTruongPhongNavigation)
                .HasForeignKey(d => d.MaTruongPhong)
                .HasConstraintName("FK_MaTruongPhong");
        });

        modelBuilder.Entity<PhongBan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PhongBan__3214EC07D8BB36AE");

            entity.ToTable("PhongBan");

            entity.Property(e => e.TenPb)
                .HasMaxLength(100)
                .HasColumnName("TenPB");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
