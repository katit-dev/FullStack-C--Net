public class NhanVien
{
    public int MaNhanVien { get; set; }
    public string? Ten { get; set; }
    public double Luong1H { get; set; }
    public int SoGioLam { get; set; }

    public NhanVien()
    {
    }

    public NhanVien(string ten, double luong1H, int soGioLam)
    {
        Ten = ten;
        Luong1H = luong1H;
        SoGioLam = soGioLam;
    }

    public void XemThongTin()
    {
        Console.WriteLine($"MaNhanVien: {MaNhanVien}, Ten: {Ten},  Luong1H: {Luong1H}, SoGioLam: {SoGioLam}");
    }

    public double TinhLuong()
    {
        return Luong1H * SoGioLam;
    }
}