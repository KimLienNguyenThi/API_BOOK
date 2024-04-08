using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class DocGium
{
    public int MaDg { get; set; }

    public string? HoTenDg { get; set; }

    public string? GioiTinh { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? Sdt { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<TheDocGium> TheDocGia { get; set; } = new List<TheDocGium>();
}
