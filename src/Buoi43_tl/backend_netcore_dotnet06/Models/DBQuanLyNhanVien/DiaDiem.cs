using System;
using System.Collections.Generic;

namespace backend_netcore_dotnet06.Models.DBQuanLyNhanVien;

public partial class DiaDiem
{
    public int Id { get; set; }

    public string TenDiaDiem { get; set; } = null!;

    public string? DiaChi { get; set; }

    public virtual ICollection<DuAn> DuAns { get; set; } = new List<DuAn>();
}
