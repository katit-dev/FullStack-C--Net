class Mentor : NguoiDung
{
    public double luong { get; set; }

    public Mentor()
    {
    }

    public Mentor(string ma, string ten, int tuoi, string gioiTinh, double luong) : base(ma, ten, tuoi, gioiTinh)
    {
        this.luong = luong;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Lương: {luong}");
    }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Nhập lương: ");
        luong = double.Parse(Console.ReadLine());
    }
}