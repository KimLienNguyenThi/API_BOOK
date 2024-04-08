using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class PhieuTra
{
    public int MaPt { get; set; }

    public DateOnly? NgayTra { get; set; }

    public int? MaNv { get; set; }

    public int? MaThe { get; set; }

    public int? MaPm { get; set; }

    public virtual ICollection<ChiTietPt> ChiTietPts { get; set; } = new List<ChiTietPt>();

    public virtual NhanVien? MaNvNavigation { get; set; }

    public virtual PhieuMuon? MaPmNavigation { get; set; }

    public virtual TheDocGium? MaTheNavigation { get; set; }
}
