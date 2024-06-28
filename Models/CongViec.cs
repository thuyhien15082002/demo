using System;
using System.Collections.Generic;

namespace StudentAPI.Models;

public partial class CongViec
{
    public string SoCccd { get; set; } = null!;

    public string NgayVaoCongTy { get; set; } = null!;

    public string MaNganh { get; set; } = null!;

    public string TenCongViec { get; set; } = null!;

    public string TenCongTy { get; set; } = null!;

    public string DiaChiCongTy { get; set; } = null!;

    public string ThoiGianLamViec { get; set; } = null!;

    public virtual Nganh MaNganhNavigation { get; set; } = null!;

    public virtual SinhVien SoCccdNavigation { get; set; } = null!;
}
