using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;// su dung thu vien de thuc hien Dependency Injection

class Program
{
    static void Main(string[] args)
    {
        // LSP: Liskov Substitution Principle
        // Một lớp con có thể thay thế cho lớp cha mà không làm thay đổi tính đúng đắn của chương trình.
        // Điều này đảm bảo rằng các đối tượng của lớp con có thể được sử dụng thay cho các đối tượng của

        // S - Single Responsibility Principle
        // GioHang gioHang = new GioHang();
        // DatHang datHang = new DatHang();
        // ThanhToan thanhToan = new ThanhToan();

        // // F - Facade Pattern
        // Facade facade = new Facade();
        // facade.MuaHangOnline();
        
        // QuanLyNhanVien quanLyNhanVien = new QuanLyNhanVien();
        // quanLyNhanVien.HienThiMenu();

        // var quanLyNhanVine = new CRUD<NhanVien>();
        // quanLyNhanVine.Create(new NhanVien("Nguyen Van A", 100000, 8 ));
        // quanLyNhanVine.Show();

        // var hop1 = new CRUD<string>();
        // hop1.Create("Hello");
        // hop1.Create("World");
        // hop1.Show();

        // var hop2 = new CRUD<int>();
        // hop2.Create(1);
        // hop2.Create(2);
        // hop2.Show();
        
    //     var penguin = new Penguin() { Name = "Penguin" };
    //    // penguin.Fly(); // loi

    //     var sparrow = new Sparrow() { Name = "Sparrow" };
    //     sparrow.Fly(); // ok

    //     var zl = new ZaloOA("Hello World");
    //     var sms = new SMS();
    //     var guiThongBao = new GuiThongBao(sms);
    //     guiThongBao.Gui();

        var donHang = new DonHang();
        donHang.ThemSanPham(new SanPham("Áo thun", 200000));
        donHang.ThemSanPham(new SanPham("Quần jeans", 500000));
        donHang.HienThiDonHang();

        double tongTien = donHang.TinhTongTien();
        Console.WriteLine($"Tổng tiền: {tongTien}");

        // var thanhToanTienMat = new ThanhToanTienMat();
        // var datHangService = new DatHangService(thanhToanTienMat);
        // datHangService.DatHang(donHang);



        // // su dung DI container tu thu vien Microsoft.Extensions.DependencyInjection
        // var service = new ServiceCollection(); 

        // // dang ky dich vu
        // service.AddTransient<IThanhToanService, ThanhToanTienMat>();
        // service.AddTransient<DatHangService>();// khoi tao dathangservice ma khong can truyen tham so vao constructor

        // // build service provider
        // var serviceProvider = service.BuildServiceProvider();

        // var datHangServiceFromDI = serviceProvider.GetService<DatHangService>();
        // datHangServiceFromDI.DatHang(donHang);


    // su dung DI container tu viet
        var diContainer = new DIContainer();
        diContainer.Register<IThanhToanService, ThanhToanTienMat>();

        var datHangServiceFromMyDI = diContainer.Resolve<DatHangService>();
        datHangServiceFromMyDI.DatHang(donHang);


    }
}


/* Tổng hợp
- SOLID: 5 nguyên tắc thiết kế phần mềm hướng đối tượng
- S: Single Responsibility Principle - Nguyên tắc đơn trách nhiệm
    mỗi class chỉ làm 1 việc duy nhất
- O: Open/Closed Principle - Nguyên tắc mở/đóng
    đóng khi hoàn chỉnh, mở khi cần mở rộng
- L: Liskov Substitution Principle - Nguyên tắc thay thế Liskov
    class con có thể thay thế cho class cha mà không làm thay đổi tính đúng đắn của chương trình
- I: Interface Segregation Principle - Nguyên tắc phân tách interface
    tách interface thành nhiều interface nhỏ hơn, mỗi interface chỉ có một số phương thức liên quan đến nhau, không nên có một interface lớn với nhiều phương thức không liên quan đến nhau, v.v.
- D: Dependency Inversion Principle - Nguyên tắc đảo ngược phụ thuộc
    code cấp cao không nên phụ thuộc vào code cấp thấp, cả hai nên phụ thuộc vào abstraction (interface), abstraction không nên phụ thuộc vào chi tiết, chi tiết nên phụ thuộc vào abstraction, v.v.


*/