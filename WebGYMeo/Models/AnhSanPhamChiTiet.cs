using System;
using System.Collections.Generic;

namespace WebGYMeo.Models;

public partial class AnhSanPhamChiTiet
{
    public string? IdSanPham { get; set; }

    public string TenFileAnh { get; set; } = null!;

    public string? ViTri { get; set; }

    public virtual SanPham? IdSanPhamNavigation { get; set; }
}
