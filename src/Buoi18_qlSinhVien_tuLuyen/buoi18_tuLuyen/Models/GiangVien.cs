class GiangVien : NguoiDung
{
    public double luong { get; set; }

    public List<SinhVien> DanhSachSinhVien { get; set; } = new List<SinhVien>();

    public GiangVien()
    {
    }

    public GiangVien(string ma, string ten, int tuoi, string gioiTinh, double luong) : base(ma, ten, tuoi, gioiTinh)
    {
        this.luong = luong;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Lương: {luong}");
    }

    // co the sai chung voi  mentor, nen chi de nhap luong, khong nhap danh sach sinh vien
    
    // public override void NhapThongTin()
    // {
    //     base.NhapThongTin();
    //     Console.Write("Nhập lương: ");
    //     luong = double.Parse(Console.ReadLine());
    //     Console.Write("Nhập số lượng sinh viên: ");
    //     int soLuongSinhVien = int.Parse(Console.ReadLine());
    //     for (int i = 0; i < soLuongSinhVien; i++)
    //     {
    //         Console.WriteLine($"Nhập thông tin sinh viên thứ {i + 1}:");
    //         SinhVien sv = new SinhVien();
    //         sv.NhapThongTin();
    //         DanhSachSinhVien.Add(sv);
    //     }
    // }
}