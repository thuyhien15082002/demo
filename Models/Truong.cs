using System;
using System.Collections.Generic;

namespace StudentAPI.Models;

public partial class Truong
{
    public string MaTruong { get; set; } = null!;

    public string TenTruong { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string SoDt { get; set; } = null!;

    public virtual ICollection<TotNghiep> TotNghieps { get; set; } = new List<TotNghiep>();
}
