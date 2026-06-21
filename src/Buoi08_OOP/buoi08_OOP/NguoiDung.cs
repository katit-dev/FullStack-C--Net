public class NguoiDung
{
    /*
    - public: có thể truy cập từ bất kỳ đâu
    - private: chỉ có thể truy cập từ bên trong lớp
    - protected: chỉ có thể truy cập từ bên trong lớp và các lớp kế thừa
    - internal: chỉ có thể truy cập từ cùng một assembly (dự án)
    - protected internal: kết hợp giữa protected và internal
    */
    // người dùng
    // properties: tên, tuổi, email, số điện thoại
    public string TenDangNhap = "Nguoi dung 01";
    private string MatKhau = "123456";
    public string Email = "email@example.com";
    public string SoDienThoai = "0123456789";

    // constructor : là một phương thức đặc biệt để khởi tạo đối tượng. Trùng tên với lớp, không có kiểu trả về.
    // constructor default:
    // làm hàm tạo không tham số, luôn được định nghĩa ngầm trong class, nhưng 
    

    // constructor có tham số:
    // nhận tham số 
    public NguoiDung(string TenDangNhap, string matKhau, string email, string soDienThoai)
    {
        this.TenDangNhap = TenDangNhap;
        MatKhau = matKhau;
        Email = email;
        SoDienThoai = soDienThoai;
    }
    // constructor không tham số:
    // constructor mặc định được hỗ trợ ngầm định nếu không có constructor nào được định nghĩa trong lớp
    // nhưng nếu đã định nghĩa constructor có tham số, thì constructor mặc định sẽ không còn nữa
    // nên ta cần định nghĩa lại constructor không tham số nếu cần
    // overload constructor
    public NguoiDung()  
    {
       
    }

    // methods: đăng nhập, đăng xuất, cập nhật thông tin
    // methods hien thị thông tin người dùng
    public void HienThiThongTin()
    {
        System.Console.WriteLine($"Tên đăng nhập: {TenDangNhap}, Email: {Email}, Số điện thoại: {SoDienThoai}");
    }
    public void DangNhap(string tenDangNhap, string matKhau)
    {
        if (tenDangNhap == TenDangNhap && matKhau == MatKhau)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Đăng nhập thành công.");
            Console.ResetColor();

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Đăng nhập thất bại. Sai tên đăng nhập hoặc mật khẩu.");
             Console.ResetColor();

        }
    }

    public void DangXuat()
    {
        System.Console.WriteLine($"{TenDangNhap} đã đăng xuất.");
    }
}