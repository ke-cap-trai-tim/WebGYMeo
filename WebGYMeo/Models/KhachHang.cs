using System;
using System.Collections.Generic;

namespace WebGYMeo.Models;

public partial class KhachHang
{
    public string IdKhach { get; set; } = null!;

    public string TenKhach { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    public string Sdt { get; set; } = null!;

    public string TenDangNhap { get; set; } = null!;

    public string Mk { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string IbGioiTinh { get; set; } = null!;

    public string? AnhDaiDien { get; set; }

    public virtual ICollection<HoaDonSanPham> HoaDonSanPhams { get; set; } = new List<HoaDonSanPham>();

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
