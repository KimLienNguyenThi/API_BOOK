using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class NhaCungCap
{
    public int MaNcc { get; set; }

    public string? TenNcc { get; set; }

    public string? DiaChiNcc { get; set; }

    public string? SdtNcc { get; set; }

    public virtual ICollection<PhieuNhapSach> PhieuNhapSaches { get; set; } = new List<PhieuNhapSach>();
}
