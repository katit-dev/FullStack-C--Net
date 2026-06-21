class NguoiDung
{
    public string Ma { get; set; }
    public string Ten { get; set; }
    public int Tuoi { get; set; }
    public string GioiTinh { get; set; }

    public NguoiDung()
    {
    }

    public NguoiDung(string ma, string ten, int tuoi, string gioiTinh)
    {
        Ma = ma;
        Ten = ten;
        Tuoi = tuoi;
        GioiTinh = gioiTinh;
    }

    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Mã: {Ma}, Tên: {Ten}, Tuổi: {Tuoi}, Giới tính: {GioiTinh}");
    }

    public virtual void NhapThongTin()
    {
        Console.Write("Nhập mã: ");
        Ma = Console.ReadLine();
        Console.Write("Nhập tên: ");
        Ten = Console.ReadLine();
        Console.Write("Nhập tuổi: ");
        Tuoi = int.Parse(Console.ReadLine());
        Console.Write("Nhập giới tính: ");
        GioiTinh = Console.ReadLine();
    }
    
}