using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class DkiMuonSach
{
    public int MaDk { get; set; }

    public string? Sdt { get; set; }

    public DateOnly? NgayDkmuon { get; set; }

    public DateOnly? NgayHen { get; set; }

    public int? Tinhtrang { get; set; }

    public virtual ICollection<ChiTietDk> ChiTietDks { get; set; } = new List<ChiTietDk>();

    public virtual LoginDg? SdtNavigation { get; set; }
}
