using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class PhieuNhapSach
{
    public int MaPn { get; set; }

    public DateOnly? NgayNhap { get; set; }

    public int? MaNv { get; set; }

    public int? MaNcc { get; set; }

    public virtual ICollection<Chitietpn> Chitietpns { get; set; } = new List<Chitietpn>();

    public virtual NhaCungCap? MaNccNavigation { get; set; }

    public virtual NhanVien? MaNvNavigation { get; set; }
}
