using System;
using System.Collections.Generic;

namespace StudentAPI.Models;

public partial class Nganh
{
    public string MaNganh { get; set; } = null!;

    public string TenNganh { get; set; } = null!;

    public string LoaiNganh { get; set; } = null!;

    public virtual ICollection<CongViec> CongViecs { get; set; } = new List<CongViec>();

    public virtual ICollection<TotNghiep> TotNghieps { get; set; } = new List<TotNghiep>();
}
