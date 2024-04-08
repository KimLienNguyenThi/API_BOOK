using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class Chitietpn
{
    public int MaPn { get; set; }

    public int MaSach { get; set; }

    public decimal? GiaSach { get; set; }

    public int? SoLuongNhap { get; set; }

    public virtual PhieuNhapSach MaPnNavigation { get; set; } = null!;

    public virtual Sach MaSachNavigation { get; set; } = null!;
}
