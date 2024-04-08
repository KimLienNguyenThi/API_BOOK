using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class ChiTietPtl
{
    public int MaPtl { get; set; }

    public int MaSachkho { get; set; }

    public int? Soluongtl { get; set; }

    public decimal? GiaTl { get; set; }

    public virtual PhieuThanhLy MaPtlNavigation { get; set; } = null!;

    public virtual KhoSachThanhLy MaSachkhoNavigation { get; set; } = null!;
}
