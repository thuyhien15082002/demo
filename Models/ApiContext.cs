using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Models;

public partial class ApiContext : DbContext
{
    public ApiContext()
    {
    }

    public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CongViec> CongViecs { get; set; }

    public virtual DbSet<Nganh> Nganhs { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    public virtual DbSet<TotNghiep> TotNghieps { get; set; }

    public virtual DbSet<Truong> Truongs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-IPDB6V8;Initial Catalog=api;User ID=sa;Password=123;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CongViec>(entity =>
        {
            entity.HasKey(e => new { e.SoCccd, e.NgayVaoCongTy, e.MaNganh });

            entity.ToTable("cong_viec");

            entity.Property(e => e.SoCccd)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.NgayVaoCongTy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MaNganh)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DiaChiCongTy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TenCongTy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TenCongViec)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ThoiGianLamViec)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.MaNganhNavigation).WithMany(p => p.CongViecs)
                .HasForeignKey(d => d.MaNganh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cong_viec_nganh");

            entity.HasOne(d => d.SoCccdNavigation).WithMany(p => p.CongViecs)
                .HasForeignKey(d => d.SoCccd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cong_viec_sinh_vien");
        });

        modelBuilder.Entity<Nganh>(entity =>
        {
            entity.HasKey(e => e.MaNganh);

            entity.ToTable("nganh");

            entity.Property(e => e.MaNganh)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LoaiNganh)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TenNganh)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.SoCccd);

            entity.ToTable("sinh_vien");

            entity.Property(e => e.SoCccd)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SoDt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SoDT");
        });

        modelBuilder.Entity<TotNghiep>(entity =>
        {
            entity.HasKey(e => new { e.SoCccd, e.MaTruong, e.MaNganh });

            entity.ToTable("tot_nghiep");

            entity.Property(e => e.SoCccd)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.MaTruong)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MaNganh)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HeTn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("HeTN");
            entity.Property(e => e.LoaiTn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("LoaiTN");
            entity.Property(e => e.NgayTn).HasColumnName("NgayTN");

            entity.HasOne(d => d.MaNganhNavigation).WithMany(p => p.TotNghieps)
                .HasForeignKey(d => d.MaNganh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tot_nghiep_nganh");

            entity.HasOne(d => d.MaTruongNavigation).WithMany(p => p.TotNghieps)
                .HasForeignKey(d => d.MaTruong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tot_nghiep_truong");

            entity.HasOne(d => d.SoCccdNavigation).WithMany(p => p.TotNghieps)
                .HasForeignKey(d => d.SoCccd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tot_nghiep_sinh_vien");
        });

        modelBuilder.Entity<Truong>(entity =>
        {
            entity.HasKey(e => e.MaTruong);

            entity.ToTable("truong");

            entity.Property(e => e.MaTruong)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SoDt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SoDT");
            entity.Property(e => e.TenTruong)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
