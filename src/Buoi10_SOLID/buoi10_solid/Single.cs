
// Single Responsibility Principle (SRP) - Nguyên tắc đơn trách nhiệm
/*
- Mỗi class chỉ nên có một lý do để thay đổi, tức là chỉ nên có 1 trách nhiệm duy nhất
- Điều này giúp cho code dễ bảo trì, dễ hiểu và dễ mở rộng hơn
- class độc lập chỉ làm nhiệm vụ duy nhất, không phụ thuộc vào các class khác

- Facade Pattern - Mẫu thiết kế Facade
- tạo ra 1 lớp trung gian, nhưng không làm thay đổi các lớp đã có
- gom cac class co liên quan lại với nhau, để kết nối các lớp đã có với nhau, mà không làm thay đổi các lớp đã có


- Design Pattern - Mẫu thiết kế
- la giai phap tong quat da duoc kiem chung

*/

public class ThanhToan
{
   // chỉ nên chứa các phương thức liên quan đến việc thanh toán, không nên chứa các phương thức liên quan đến việc quản lý sản phẩm, quản lý khách hàng, v.v.
    public void ThanhToanOnline()
    {
        // code thanh toán online
        Console.WriteLine("Thanh toan Online");
    }

}


public class GioHang
{
    // chỉ nên chứa các phương thức liên quan đến việc quản lý giỏ hàng, không nên chứa các phương thức liên quan đến việc thanh toán, quản lý sản phẩm, quản lý khách hàng, v.v.
    public void ThemSanPham()
    {
        // code thêm sản phẩm vào giỏ hàng
        Console.WriteLine("Them san pham vao gio hang");
    }

}

public class DatHang
{
    // chỉ nên chứa các phương thức liên quan đến việc đặt hàng, không nên chứa các phương thức liên quan đến việc thanh toán, quản lý sản phẩm, quản lý khách hàng, v.v.
    public void DatHangOnline()
    {
        // code đặt hàng online
        Console.WriteLine("Dat hang Online");
    }

}

// Facade Pattern - Mẫu thiết kế Facade
// - tạo ra 1 lớp trung gian, nhưng không làm thay đổi các lớp đã có
// - để kết nối các lớp đã có với nhau, mà không làm thay đổi các lớp đã có
// - giúp cho code dễ hiểu hơn, dễ bảo trì hơn, dễ mở rộng hơn
public class Facade
{
    private GioHang _gioHang;
    private DatHang _datHang;
    private ThanhToan _thanhToan;

    // khoi tao constructor
    public Facade()
    {
        _gioHang = new GioHang();
        _datHang = new DatHang();
        _thanhToan = new ThanhToan();
    }

    // phương thức để thực hiện đặt hàng online
    public void MuaHangOnline()
    {
        _gioHang.ThemSanPham();
        _datHang.DatHangOnline();
        _thanhToan.ThanhToanOnline();
    }

    
}