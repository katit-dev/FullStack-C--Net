/*Interface 
- la 1 cai khuon mau cho cac class khac
- bat buoc class implement interface phai dinh nghia tat ca phuong thuc va thuoc tinh trong interface do
- interface khong the co phan than cua phuong thuc
- interface va abstrac class khong co constructor

- khai bao cac thuoc tinh va phuong thuc ma khong can than, chi khai bao
- khong co phan than ==> khong the khoi tao doi tuong tu interface

- tat ca nhung gi trong interface mac dinh la public
==> co the bo tu khoa public, vd: string Canh { get; set; } 

- tinh da ke thua: 1 class co the implement nhieu interface khac nhau

- ở những version C# mới hơn, interface có thể có phần thân của phương thức (method body) 
  nhưng trong ví dụ này, chúng ta sẽ sử dụng cách khai báo truyền thống không có phần thân.


  - abstract class vs interface
  + abstract class: co the co thuoc tinh, phuong thuc binh thuong, phuong thuc abstract
  + abstract class: huong ve tao ra 1 lop cha de cac lop con ke thua
    + interface: chi co thuoc tinh va phuong thuc (mac dinh la abstract)
    + interface: huong ve tao ra 1 khuon mau(quy dinh) chung cho cac lop khac nhau implement
    

*/
public interface IHinhHoc
{
    // thuoc tinh
    public string Canh { get; set; } //interface chi co khai bao, khong the dinh nghia
    // phuong thuc
    public double TinhChuVi();
    public double TinhDienTich();


}

public interface IHienThi
{
    void HienThiThongTin();
}

public class HinhVuong : IHinhHoc, IHienThi
{
    public string Canh { get; set; }

    public double TinhChuVi()
    {
        double c = double.Parse(Canh);
        return 4 * c;
    }

    public double TinhDienTich()
    {
        double c = double.Parse(Canh);
        return c * c;
    }

    public void HienThiThongTin()
    {
        System.Console.WriteLine("Hinh vuong co canh: " + Canh);
        System.Console.WriteLine("Chu vi: " + TinhChuVi());
        System.Console.WriteLine("Dien tich: " + TinhDienTich());
    }
}