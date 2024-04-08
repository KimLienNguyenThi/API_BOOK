﻿using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class ChiTietPm
{
    public int MaPm { get; set; }

    public int MaSach { get; set; }

    public int? Soluongmuon { get; set; }

    public virtual PhieuMuon MaPmNavigation { get; set; } = null!;

    public virtual Sach MaSachNavigation { get; set; } = null!;
}
