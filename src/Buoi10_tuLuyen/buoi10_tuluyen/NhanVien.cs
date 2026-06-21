public class NhanVien
{
    public string Ten { get; set; }
    public double LuongCoBan { get; set; }
    private ITinhLuongStrategy _tinhLuongStrategy;

    public NhanVien(string ten, double luongCoBan, ITinhLuongStrategy tinhLuongStrategy)
    {
        Ten = ten;
        LuongCoBan = luongCoBan;
        this._tinhLuongStrategy = tinhLuongStrategy;
    }

    public double TinhLuong()
    {
        return _tinhLuongStrategy.TinhLuong(LuongCoBan);
    }

    public void ShowThongTin()
    {
        Console.WriteLine($"Tên: {Ten}, Lương cơ bản: {LuongCoBan}, Lương thực nhận: {TinhLuong()}");
    }
}