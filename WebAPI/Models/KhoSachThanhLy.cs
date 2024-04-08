using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class KhoSachThanhLy
{
    public int Masachkho { get; set; }

    public int? Soluongkhotl { get; set; }

    public virtual ICollection<ChiTietPtl> ChiTietPtls { get; set; } = new List<ChiTietPtl>();
}
