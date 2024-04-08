using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class TheDocGium
{
    public int MaThe { get; set; }

    public DateOnly? NgayDk { get; set; }

    public DateOnly? NgayHh { get; set; }

    public int? TienThe { get; set; }

    public int? MaNv { get; set; }

    public int? MaDg { get; set; }

    public virtual DocGium? MaDgNavigation { get; set; }

    public virtual NhanVien? MaNvNavigation { get; set; }

    public virtual ICollection<PhieuMuon> PhieuMuons { get; set; } = new List<PhieuMuon>();

    public virtual ICollection<PhieuTra> PhieuTras { get; set; } = new List<PhieuTra>();
}
