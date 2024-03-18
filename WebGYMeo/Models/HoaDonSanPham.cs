using System;
using System.Collections.Generic;

namespace WebGYMeo.Models;

public partial class HoaDonSanPham
{
    public string IdHoaDon { get; set; } = null!;

    public DateOnly ThoiGian { get; set; }

    public string IdKhac { get; set; } = null!;

    public string IdNhanVien { get; set; } = null!;

    public double TongTien { get; set; }

    public string IdSabPham { get; set; } = null!;

    public virtual KhachHang IdKhacNavigation { get; set; } = null!;

    public virtual NhanVien IdNhanVienNavigation { get; set; } = null!;

    public virtual SanPham IdSabPhamNavigation { get; set; } = null!;
}
