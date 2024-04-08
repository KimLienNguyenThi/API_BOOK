using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class PhieuMuon
{
    public int MaPm { get; set; }

    public DateOnly? NgayMuon { get; set; }

    public DateOnly? HanTra { get; set; }

    public int? MaThe { get; set; }

    public int? MaNv { get; set; }

    public bool? Tinhtrang { get; set; }

    public int? MaDk { get; set; }

    public virtual ICollection<ChiTietPm> ChiTietPms { get; set; } = new List<ChiTietPm>();

    public virtual NhanVien? MaNvNavigation { get; set; }

    public virtual TheDocGium? MaTheNavigation { get; set; }

    public virtual ICollection<PhieuTra> PhieuTras { get; set; } = new List<PhieuTra>();
}
