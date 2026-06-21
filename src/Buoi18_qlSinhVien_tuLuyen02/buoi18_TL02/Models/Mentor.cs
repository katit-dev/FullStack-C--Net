public  class Mentor : NguoiDung
{
    public double Luong { get; set; }

    public Mentor()
    {
    }

    public Mentor(string ma, string ten, int tuoi, string gioiTinh, double luong) : base(ma, ten, tuoi, gioiTinh)
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