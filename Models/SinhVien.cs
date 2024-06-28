using System;
using System.Collections.Generic;

namespace StudentAPI.Models;

public partial class SinhVien
{
    public string SoCccd { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string SoDt { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public virtual ICollection<CongViec> CongViecs { get; set; } = new List<CongViec>();

    public virtual ICollection<TotNghiep> TotNghieps { get; set; } = new List<TotNghiep>();
}
