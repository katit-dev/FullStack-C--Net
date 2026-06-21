// mentor ke thua sinh vien + luong
public class Mentor : SinhVien
{
    public double Luong { get; set; }

    public Mentor()
    {

    }

    public Mentor(string ma, string ten, int tuoi, string gioiTinh, double luong) : base(ma, ten, tuoi, gioiTinh)
    {
        Luong = luong;
    }

    public void ShowInfoMentor()
    {
        Console.WriteLine($"Ma: {Ma} - Ten: {Ten} - Tuoi: {Tuoi} - GioiTinh: {GioiTinh} - Luong: {Luong}");
    }

    public override void NhapThongTin()
    {
        base.NhapThongTin(); // goi ham nhap thong tin cua lop cha (sinh vien)
        Console.Write("Nhap luong: ");
        Luong = double.Parse(Console.ReadLine());
    }

    
}