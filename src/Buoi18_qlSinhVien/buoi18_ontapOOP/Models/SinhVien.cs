public class SinhVien
{
    public string Ma { get; set; }
    public string Ten { get; set; }
    public int Tuoi { get; set; }
    public string GioiTinh { get; set; }
    // protected: con co the lay duoc, ben ngoai thi khong

    public SinhVien()
    {

    }
    public SinhVien(string ma, string ten, int tuoi, string gioiTinh)
    {
        Ma = ma;
        Ten = ten;
        Tuoi = tuoi;
        GioiTinh = gioiTinh;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Ma: {Ma} - Ten: {Ten} - Tuoi: {Tuoi} - GioiTinh: {GioiTinh}");
    }

    public virtual void NhapThongTin()
    {
        Console.Write("Nhap ma: ");
        Ma = Console.ReadLine();
        Console.Write("Nhap ten: ");
        Ten = Console.ReadLine();
        Console.Write("Nhap tuoi: ");
        Tuoi = int.Parse(Console.ReadLine());
        Console.Write("Nhap gioi tinh: ");
        GioiTinh = Console.ReadLine();
    }
}