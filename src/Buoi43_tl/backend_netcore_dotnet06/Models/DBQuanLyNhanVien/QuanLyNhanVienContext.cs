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

    public virtual DbSet<DiaDiem> DiaDiems { get; set; }

    public virtual DbSet<DuAn> DuAns { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<NhanVienDuan> NhanVienDuans { get; set; }

    public virtual DbSet<PhongBan> PhongBans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DBQuanLyNhanVienConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DiaDiem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DiaDiem__3214EC07ED611296");

            entity.ToTable("DiaDiem");

            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.TenDiaDiem).HasMaxLength(255);
        });

        modelBuilder.Entity<DuAn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DuAn__3214EC0738DC33C8");

            entity.ToTable("DuAn");

            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.TenDuAn).HasMaxLength(255);

            entity.HasOne(d => d.MaDiaDiemNavigation).WithMany(p => p.DuAns)
                .HasForeignKey(d => d.MaDiaDiem)
                .HasConstraintName("FK_DuAn_DiaDiem");
        });

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

        modelBuilder.Entity<NhanVienDuan>(entity =>
        {
            entity.HasKey(e => new { e.MaNhanVien, e.MaDuAn }).HasName("PK__NhanVien__294FBF594E4436EC");

            entity.ToTable("NhanVien_Duan");

            entity.HasOne(d => d.MaDuAnNavigation).WithMany(p => p.NhanVienDuans)
                .HasForeignKey(d => d.MaDuAn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NhanVien___MaDuA__75A278F5");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.NhanVienDuans)
                .HasForeignKey(d => d.MaNhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NhanVien___MaNha__74AE54BC");
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
