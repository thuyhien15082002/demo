using System;
using System.Collections.Generic;

namespace StudentAPI.Models;

public partial class TotNghiep
{
    public string SoCccd { get; set; } = null!;

    public string MaTruong { get; set; } = null!;

    public string MaNganh { get; set; } = null!;

    public string HeTn { get; set; } = null!;

    public DateOnly NgayTn { get; set; }

    public string LoaiTn { get; set; } = null!;

    public virtual Nganh MaNganhNavigation { get; set; } = null!;

    public virtual Truong MaTruongNavigation { get; set; } = null!;

    public virtual SinhVien SoCccdNavigation { get; set; } = null!;
}
