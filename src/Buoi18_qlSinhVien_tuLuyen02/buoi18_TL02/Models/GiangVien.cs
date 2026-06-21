public class GiangVien : NguoiDung
{
   public double Luong { get; set; }
   public List<SinhVien> DanhSachSinhVien { get; set; } = new List<SinhVien>();

    public GiangVien()
    {
    }

    public GiangVien(string ma, string ten, int tuoi, string gioiTinh, double luong) : base(ma, ten, tuoi, gioiTinh)
    {
        Luong = luong;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Lương: {Luong}");
    }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Nhập lương: ");
        Luong = double.Parse(Console.ReadLine());
    }
}