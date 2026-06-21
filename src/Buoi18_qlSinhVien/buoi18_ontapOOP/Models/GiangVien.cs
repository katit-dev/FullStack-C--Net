// giang vien ket thua emntor + ds hoc vien
public class GiangVien : Mentor
{
    public List<SinhVien> DanhSachHocVien { get; set; } = new List<SinhVien>();

    public GiangVien()
    {

    }

    public GiangVien(string ma, string ten, int tuoi, string gioiTinh, double luong, List<SinhVien> danhSachHocVien) : base(ma, ten, tuoi, gioiTinh, luong)
    {
        DanhSachHocVien = danhSachHocVien;
    }

    public void ShowInfoGiangVien()
    {
        Console.WriteLine($"Ma: {Ma} - Ten: {Ten} - Tuoi: {Tuoi} - GioiTinh: {GioiTinh} - Luong: {Luong}");
        Console.WriteLine("Danh sach hoc vien:");
        foreach (var sv in DanhSachHocVien)
        {
            Console.WriteLine($"Ma: {sv.Ma} - Ten: {sv.Ten} - Tuoi: {sv.Tuoi} - GioiTinh: {sv.GioiTinh}");
        }
    }

    // giang vien se dung chung override nhap thong tin cua mentor, khong can phai override nua
}