using System;
using System.Collections.Generic;

namespace backend_netcore_dotnet06.Models.DBQuanLyNhanVien;

public partial class DuAn
{
    public int Id { get; set; }

    public string TenDuAn { get; set; } = null!;

    public string? MoTa { get; set; }

    public DateOnly? NgayBatDau { get; set; }

    public DateOnly? NgayKetThuc { get; set; }

    public int? MaDiaDiem { get; set; }

    public virtual DiaDiem? MaDiaDiemNavigation { get; set; }

    public virtual ICollection<NhanVien> MaNhanViens { get; set; } = new List<NhanVien>();
}
