using System;
using System.Collections.Generic;

namespace backend_netcore_dotnet06.Models.DBQuanLyNhanVien;

public partial class NhanVienDuan
{
    public int MaNhanVien { get; set; }

    public int MaDuAn { get; set; }

    public DateOnly? NgayThamGia { get; set; }

    public virtual DuAn MaDuAnNavigation { get; set; } = null!;

    public virtual NhanVien MaNhanVienNavigation { get; set; } = null!;
}
