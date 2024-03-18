using System;
using System.Collections.Generic;

namespace WebGYMeo.Models;

public partial class ChucVu
{
    public string Id { get; set; } = null!;

    public string TenChucVụ { get; set; } = null!;

    public string QuenHang { get; set; } = null!;

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
