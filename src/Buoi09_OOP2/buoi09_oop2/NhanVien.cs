/*Abstract Class
- dinh nghia phuong thuc 
- nhung khong can co phan than
- class ke thua phai override phuong thuc do
- khong the tao doi tuong tu abstract class
- abstract method chi duoc dinh nghia trong abstract class
- abstract class co the co thuoc tinh va phuong thuc binh thuong


- chi co the khoi tao doi tuong ma ke thua tu abstract class

- thuong duoc su dung de dinh nghia lop co nhung phuong thuc chung
ma cac lop con phai co

*/

public abstract class NhanVien
{
    public string Ten;
    public double LuongCoBan;
    public double TongLuong;

    public abstract void TinhLuong();// bat buoc class con phai override method nay
}

// Nhan vien kinh doanh -> ke thua tu NhanVien
public class NhanVienKinhDoanh : NhanVien
{
    public double DoanhSo { get; set; }
    public double HoaHong { get; set; }

    // override method
    public override void TinhLuong()
    {
        TongLuong = LuongCoBan + (DoanhSo * HoaHong / 100);
    }
}

// Nhan vien san xuat -> ke thua tu NhanVien
public class NhanVienSanXuat : NhanVien
{
    public int SanLuong { get; set; }
    public double DonGia { get; set; }

    public override void TinhLuong()
    {
        TongLuong = LuongCoBan + (SanLuong * DonGia);
    }
}
