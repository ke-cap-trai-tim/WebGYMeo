using System;
using System.Collections.Generic;

namespace WebGYMeo.Models;

public partial class GoiDichVu
{
    public string IdGoi { get; set; } = null!;

    public string TenGoi { get; set; } = null!;

    public double Gia { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
