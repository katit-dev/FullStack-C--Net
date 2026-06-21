class Program
{
    static void Main(string[] args)
    {
    //     // Tạo đối tượng của lớp ConNguoi
    //    var nd = new NguoiDung();
    //     nd.Name = "Nguyen Van A";
    //     nd.Age = 30;
    //     nd.Role = "Hoc Vien";
    //     nd.ShowInfo();
    //     Console.WriteLine("----------------------------");

    //     // tao doi tuong cua lop Mentor
    //     var mentor = new Mentor();
    //     mentor.Name = "Tran Thi B";
    //     mentor.Age = 28;
    //     mentor.Role = "Mentor";
    //     mentor.HeSoLuong = 10;
    //     mentor.ShowInfo();
    //     mentor.ChamBaiTap();


    // NhanVien nv1 = new NhanVien(); // loi vi NhanVien la abstract class, khong the tao doi tuong tu no  
    
    
    }
}

// OOP co 4 tinh chat
/*
- 1: tinh dong goi (encapsulation): dong goi du lieu va hanh dong lien quan vao cung 1 doi tuong, bao ve du lieu va hanh dong do khong bi anh huong boi cac doi tuong khac
- 2: tinh ke thua (inheritance): cho phep tao ra lop moi tu lop da co san, lop moi se ke thua cac thuoc tinh va phuong thuc cua lop cha, dong thoi co the them cac thuoc tinh va phuong thuc rieng
- 3: tinh da hinh (polymorphism): 1 phuong thuc co nhieu cach the hien khac nhau
===> the hien qua virtual method va override method
- 4: tinh truu tuong (abstraction): chi hien thi nhung thu can thiet, an di nhung thu khong can thiet
===> the hien qua abstract class va interface

*/

//constructor
/*
- khi 1 class khong dinh nghia constructor, thi se co 1 constructor mac dinh duoc tao ra tu dong, va constructor nay khong co tham so
- tu khoa base: 
- tu khoa virtual: cho phep phuong thuc co the duoc ghi de (override) trong lop con
- tu khoa override: ghi de phuong thuc cua lop cha trong lop con
- tu khoa abstract: cho phep phuong thuc khong co than (method body), phuong thuc nay se duoc dinh nghia trong lop con, va lop chua phuong thuc abstract se la lop abstract class
- tu khoa interface: chi co khai bao, khong the dinh nghia, khong the khoi tao doi tuong tu interface, tat ca nhung gi trong interface mac dinh la public



// static: tu khoa static duoc su dung de khai bao cac thanh phan tinh(thuoc ve lop, khong thuoc ve doi tuong)
co the truy cap ma khong can toaj doi  duong cua lop, vd Console.WriteLine(Math.PI); // truy cap den hang so PI trong lop Math ma khong can tao doi tuong Math

pulbic class NhanVien
{
    public static int count = 0;
    
    ....

}


// sealed: chan ke thua, chan ghi de phuong thuc
*/