using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class TtSach
{
    public int MaTtSach { get; set; }

    public string? UrlImage { get; set; }

    public string? Mota { get; set; }

    public int? Masach { get; set; }

    public virtual Sach? MasachNavigation { get; set; }
}
