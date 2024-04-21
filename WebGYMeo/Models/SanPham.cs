using System;
using System.Collections.Generic;

namespace WebGYMeo.Models;

public partial class SanPham
{
    public string IdSanPham { get; set; } = null!;

    public string TenSanPham { get; set; } = null!;

    public string? ThongTinChiTiet { get; set; }

    public double Gia { get; set; }

    public string? AnhSanPham { get; set; }

    public string? DongGioiThieuSanPham { get; set; }

    public virtual ICollection<AnhSanPhamChiTiet> AnhSanPhamChiTiets { get; set; } = new List<AnhSanPhamChiTiet>();

    public virtual ICollection<HoaDonSanPham> HoaDonSanPhams { get; set; } = new List<HoaDonSanPham>();
}
