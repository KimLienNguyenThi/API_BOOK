using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class Sach
{
    public int MaSach { get; set; }

    public string? TenSach { get; set; }

    public string? TheLoai { get; set; }

    public string? TacGia { get; set; }

    public string? NgonNgu { get; set; }

    public string? Nxb { get; set; }

    public int? NamXb { get; set; }

    public int? SoLuongHientai { get; set; }

    public virtual ICollection<ChiTietDk> ChiTietDks { get; set; } = new List<ChiTietDk>();

    public virtual ICollection<ChiTietPm> ChiTietPms { get; set; } = new List<ChiTietPm>();

    public virtual ICollection<ChiTietPt> ChiTietPts { get; set; } = new List<ChiTietPt>();

    public virtual ICollection<Chitietpn> Chitietpns { get; set; } = new List<Chitietpn>();

    public virtual ICollection<TtSach> TtSaches { get; set; } = new List<TtSach>();
}
