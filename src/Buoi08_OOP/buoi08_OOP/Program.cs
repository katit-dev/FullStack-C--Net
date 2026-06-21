class Program
{
    static void Main(string[] args)
    {
        // // tạo ra instance (thể hiện) của lớp NhanVat
        // var conan = new NhanVat();
        // conan.Ten = "Conan";
        // conan.GioiTinh = "Nam";
        // conan.Tuoi = 7;
        // conan.GioiThieu();

        // var doraemon = new NhanVat();
        // doraemon.Ten = "Doraemon";
        // doraemon.GioiTinh = "Nam";
        // doraemon.Tuoi = 10;
        // doraemon.GioiThieu();

        // NguoiDung user1 = new NguoiDung(); // khởi tạo đối tượng NguoiDung và sử dụng giá trị mặc định của thuộc tính

        // user1.TenDangNhap = "admin";
        // //user1.MatKhau = "admin123";
        // user1.Email = "admin@example.com";
        // user1.SoDienThoai = "0987654321";
        // user1.HienThiThongTin();

        // NguoiDung user2 = new NguoiDung()
        // {
        //     TenDangNhap = "user02",
        //     //MatKhau = "userpass",
        //     Email = "user02@example.com",
        //     SoDienThoai = "0123456789"
        // };
        // user2.HienThiThongTin();

        // user1.DangNhap("admin", "admin123");
        // user1.DangNhap("admin", "123456");

        // var user3 = new NguoiDung("user03", "pass03", "user03@example.com", "0981234567");
        // user3.HienThiThongTin();

        // var mario = new Mario();
        // mario.CurrentStatus();
        // mario.Jump();
        // mario.Run();
        // mario.Attack();
        // mario.EatMushroom();
        // mario.TakeDamage(100);
        // mario.EatMushroom();
        // // mario.Lives = 5; // lỗi vì Lives là private
        // mario.ChangeLives(2); // tăng 2 mạng
        // Console.WriteLine("so mang la " + mario.Lives); // lỗi vì Lives là private

        // // static thuoc ve class
        // // dung ten class.
        // System.Console.WriteLine($"Tổng số Mario hiện có: {Mario.TongSoMario}");
        // // gọi phương thức static
        // Mario.DisplayTotalMarios();

        var quanLy = new QuanLyTasks();
        quanLy.HienThiMenu();
        

    }
}