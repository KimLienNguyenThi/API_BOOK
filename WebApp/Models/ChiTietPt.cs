using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class ChiTietPt
{
    public int MaPt { get; set; }

    public int MaSach { get; set; }

    public int? Soluongtra { get; set; }

    public int? Soluongloi { get; set; }

    public int? Soluongmat { get; set; }

    public decimal? PhuThu { get; set; }

    public virtual PhieuTra MaPtNavigation { get; set; } = null!;

    public virtual Sach MaSachNavigation { get; set; } = null!;
}
