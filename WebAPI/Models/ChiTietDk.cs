using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class ChiTietDk
{
    public int MaDk { get; set; }

    public int MaSach { get; set; }

    public int? Soluongmuon { get; set; }

    public virtual DkiMuonSach MaDkNavigation { get; set; } = null!;

    public virtual Sach MaSachNavigation { get; set; } = null!;
}
