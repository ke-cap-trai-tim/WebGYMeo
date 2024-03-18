using System;
using System.Collections.Generic;

namespace WebGYMeo.Models;

public partial class HoaDon
{
    public string IdHoaDon { get; set; } = null!;

    public DateOnly ThoiGian { get; set; }

    public string IdKhach { get; set; } = null!;

    public string IdNhanVien { get; set; } = null!;

    public double Gia { get; set; }

    public string IdGoi { get; set; } = null!;

    public virtual GoiDichVu IdGoiNavigation { get; set; } = null!;

    public virtual KhachHang IdKhachNavigation { get; set; } = null!;

    public virtual NhanVien IdNhanVienNavigation { get; set; } = null!;
}
