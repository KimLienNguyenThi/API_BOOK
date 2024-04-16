using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;

public partial class DkiMuonSach
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaDk { get; set; }

    public string? Sdt { get; set; }

    public DateTime? NgayDkmuon { get; set; }

    public DateTime? NgayHen { get; set; }

    public int? Tinhtrang { get; set; }

    public virtual ICollection<ChiTietDk> ChiTietDks { get; set; } = new List<ChiTietDk>();

    public virtual LoginDg? SdtNavigation { get; set; }
}
