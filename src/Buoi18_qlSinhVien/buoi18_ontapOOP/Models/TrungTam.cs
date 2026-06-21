public class TrungTam
{
    public string TenTrungTam { get; set; }
    public string MST { get; set; }

    public double DoanhThu { get; set; }
    public List<SinhVien> DanhSachNguoiDung { get; set; }

    public TrungTam()
    {
        DanhSachNguoiDung = new List<SinhVien>();
         DanhSachNguoiDung.Add(new SinhVien(){ Ma = "SV001", Ten = "Nguyen Van A", Tuoi = 20, GioiTinh = "Nam" });
        DanhSachNguoiDung.Add(new SinhVien() { Ma = "SV002", Ten = "Tran Thi B", Tuoi = 22, GioiTinh = "Nu" });
        DanhSachNguoiDung.Add(new Mentor() { Ma = "M001", Ten = "Le Van C", Tuoi = 30, GioiTinh = "Nam", Luong = 5000 });
        DanhSachNguoiDung.Add(new GiangVien() { Ma = "GV001", Ten = "Pham Thi D", Tuoi = 40, GioiTinh = "Nu", Luong = 10000 });
    }

    public TrungTam(string tenTrungTam, string mST, double doanhThu, List<SinhVien> danhSachNguoiDung)
    {
        TenTrungTam = tenTrungTam;
        MST = mST;
        DoanhThu = doanhThu;
        DanhSachNguoiDung = danhSachNguoiDung;
    }

    public List<SinhVien> GetDanhSachNguoiDung()
    {
        return DanhSachNguoiDung;
    }

    public void SetDanhSachNguoiDung(List<SinhVien> danhSachNguoiDung)
    {
        DanhSachNguoiDung = danhSachNguoiDung;
    }

   // hien thi danh sach tat ca nguoi dung
    public void HienThiDanhSachNguoiDung()
    {
        Console.WriteLine("Danh sach nguoi dung:");
        foreach (var nd in DanhSachNguoiDung)
        {
            nd.ShowInfo();
        }
    }

    public void HienThiDanhSachGiangVien()
    {
        Console.WriteLine("Danh sách giảng viên:");
        foreach (var nguoiDung in DanhSachNguoiDung)
        {
            if (nguoiDung is GiangVien)
            // nếu là GV thì mới hiển thị
            {
                Console.WriteLine($"Mã: {nguoiDung.Ma}, Tên: {nguoiDung.Ten}");
            }
        }
    }

        // tim kiem nguoi dung theo ma
    public SinhVien TimKiemNguoiDungTheoMa(string ma)
    {
        SinhVien? nguoiDung = DanhSachNguoiDung.Find(nd => nd.Ma.ToLower() == ma.ToLower());
        if(nguoiDung != null)
        {
            return nguoiDung;
        }
        else
        {
            Console.WriteLine("Không tìm thấy người dùng với mã đã nhập.");
            return null;
        }
    }

}