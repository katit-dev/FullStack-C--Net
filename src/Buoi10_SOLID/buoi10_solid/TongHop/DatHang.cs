public class DatHangService
{
    public IThanhToanService _thanhToanService;
    public DatHangService(IThanhToanService thanhToanService) // DIP: nguyen ly thiet ke tron vao interface thay vi class cu the, de co the thay doi linh hoat khi can thiet
    {
        _thanhToanService = thanhToanService; // Dependency Injection: thiet ke de co the inject duoc service vao class, khong phu thuoc vao 1 service cu the nao, de co the thay doi linh hoat khi can thiet
    }
    public void DatHang(DonHang donHang)
    {
        double tongTien = donHang.TinhTongTien();
        _thanhToanService.ThanhToan(tongTien);
    }

}

/*
DIP: Dependency Inversion Principle - Nguyên tắc đảo ngược phụ thuộc
- các module cấp cao không nên phụ thuộc vào các module cấp thấp. Cả hai nên phụ thuộc vào các abstraction (giao diện) / interface

DI: Dependency Injection - Kỹ thuật để thực hiện nguyên tắc DIP, cho phép chúng ta inject (tiêm) các phụ thuộc vào một class thông qua constructor, setter hoặc interface, thay vì để class tự tạo ra các phụ thuộc của nó. Điều này giúp giảm sự phụ thuộc giữa các class và tăng tính linh hoạt của code.
- hiện thực hóa DIP

Desgin pattern: là các giải pháp đã được kiểm chứng để giải quyết các vấn đề thiết kế phần mềm phổ biến, giúp tăng tính tái sử dụng, mở rộng và bảo trì của code.
- vd: Factory pattern, Singleton pattern, Observer pattern, Strategy pattern, v.v.


*/