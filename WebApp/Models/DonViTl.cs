using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class DonViTl
{
    public int MaDv { get; set; }

    public string? TenDv { get; set; }

    public string? DiaChiDv { get; set; }

    public string? Sdtdv { get; set; }

    public virtual ICollection<PhieuThanhLy> PhieuThanhLies { get; set; } = new List<PhieuThanhLy>();
}
