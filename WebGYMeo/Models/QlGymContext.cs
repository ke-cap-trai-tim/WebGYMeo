using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebGYMeo.Models;

public partial class QlGymContext : DbContext
{
    public QlGymContext()
    {
    }

    public QlGymContext(DbContextOptions<QlGymContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChucVu> ChucVus { get; set; }

    public virtual DbSet<GoiDichVu> GoiDichVus { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<HoaDonSanPham> HoaDonSanPhams { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhongTap> PhongTaps { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-EGMHSJ1;Initial Catalog=qlGYM;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChucVu>(entity =>
        {
            entity.ToTable("Chuc_vu");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.QuenHang)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("quen_hang");
            entity.Property(e => e.TenChucVụ)
                .HasMaxLength(50)
                .HasColumnName("ten_chuc_vụ");
        });

        modelBuilder.Entity<GoiDichVu>(entity =>
        {
            entity.HasKey(e => e.IdGoi);

            entity.ToTable("Goi_dich_vu");

            entity.Property(e => e.IdGoi)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_goi");
            entity.Property(e => e.Gia).HasColumnName("gia");
            entity.Property(e => e.TenGoi)
                .HasMaxLength(50)
                .HasColumnName("ten_goi");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.IdHoaDon);

            entity.ToTable("Hoa_don");

            entity.Property(e => e.IdHoaDon)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_hoa_don");
            entity.Property(e => e.Gia).HasColumnName("gia");
            entity.Property(e => e.IdGoi)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_goi");
            entity.Property(e => e.IdKhach)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_khach");
            entity.Property(e => e.IdNhanVien)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_nhan_vien");
            entity.Property(e => e.ThoiGian).HasColumnName("thoi_gian");

            entity.HasOne(d => d.IdGoiNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.IdGoi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hoa_don_Goi_dich_vu");

            entity.HasOne(d => d.IdKhachNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.IdKhach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hoa_don_Khach_hang");

            entity.HasOne(d => d.IdNhanVienNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.IdNhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hoa_don_Nhan_vien");
        });

        modelBuilder.Entity<HoaDonSanPham>(entity =>
        {
            entity.HasKey(e => e.IdHoaDon);

            entity.ToTable("Hoa_don_san_pham");

            entity.Property(e => e.IdHoaDon)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_hoa_don");
            entity.Property(e => e.IdKhac)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_khac");
            entity.Property(e => e.IdNhanVien)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_nhan_vien");
            entity.Property(e => e.IdSabPham)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_sab_pham");
            entity.Property(e => e.ThoiGian).HasColumnName("thoi_gian");
            entity.Property(e => e.TongTien).HasColumnName("tong_tien");

            entity.HasOne(d => d.IdKhacNavigation).WithMany(p => p.HoaDonSanPhams)
                .HasForeignKey(d => d.IdKhac)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hoa_don_san_pham_Khach_hang");

            entity.HasOne(d => d.IdNhanVienNavigation).WithMany(p => p.HoaDonSanPhams)
                .HasForeignKey(d => d.IdNhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hoa_don_san_pham_Nhan_vien");

            entity.HasOne(d => d.IdSabPhamNavigation).WithMany(p => p.HoaDonSanPhams)
                .HasForeignKey(d => d.IdSabPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hoa_don_san_pham_San_pham");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.IdKhach);

            entity.ToTable("Khach_hang");

            entity.Property(e => e.IdKhach)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_khach");
            entity.Property(e => e.AnhDaiDien)
                .HasColumnType("image")
                .HasColumnName("anh_dai_dien");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.IbGioiTinh)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ib_gioi_tinh");
            entity.Property(e => e.Mk)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mk");
            entity.Property(e => e.NgaySinh).HasColumnName("ngay_sinh");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SDT");
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ten_dang_nhap");
            entity.Property(e => e.TenKhach)
                .HasMaxLength(50)
                .HasColumnName("ten_khach");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.IdNhanVien).HasName("PK_Nhan vien");

            entity.ToTable("Nhan_vien");

            entity.Property(e => e.IdNhanVien)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_nhan_vien");
            entity.Property(e => e.AnhDaiDien)
                .HasColumnType("image")
                .HasColumnName("anh_dai_dien");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IbGioiTinh)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ib_gioi_tinh");
            entity.Property(e => e.IdChucVụ)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_chuc_vụ");
            entity.Property(e => e.Mk)
                .HasMaxLength(50)
                .HasColumnName("mk");
            entity.Property(e => e.NgaySinh).HasColumnName("ngay_sinh");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SDT");
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(50)
                .HasColumnName("ten_dang_nhap");
            entity.Property(e => e.TenNhanVien)
                .HasMaxLength(50)
                .HasColumnName("ten_nhan_vien");

            entity.HasOne(d => d.IdChucVụNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.IdChucVụ)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Nhan_vien_Chuc_vu");
        });

        modelBuilder.Entity<PhongTap>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Phong_tap");

            entity.Property(e => e.ChucNang)
                .HasMaxLength(50)
                .HasColumnName("chuc_nang");
            entity.Property(e => e.IdPhongTap)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_phong_tap");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.IdSanPham);

            entity.ToTable("San_pham");

            entity.Property(e => e.IdSanPham)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_san_pham");
            entity.Property(e => e.AnhSanPham)
                .HasColumnType("image")
                .HasColumnName("anh_san_pham");
            entity.Property(e => e.Gia).HasColumnName("gia");
            entity.Property(e => e.TenSanPham)
                .HasMaxLength(50)
                .HasColumnName("ten_san_pham");
            entity.Property(e => e.ThongTinChiTiet)
                .HasMaxLength(200)
                .HasColumnName("thong_tin_chi_tiet");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
