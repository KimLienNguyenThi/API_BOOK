using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class PhieuThanhLy
{
    public int MaPtl { get; set; }

    public DateOnly? NgayTl { get; set; }

    public int? MaDv { get; set; }

    public int? MaNv { get; set; }

    public virtual ICollection<ChiTietPtl> ChiTietPtls { get; set; } = new List<ChiTietPtl>();

    public virtual DonViTl? MaDvNavigation { get; set; }

    public virtual NhanVien? MaNvNavigation { get; set; }
}
