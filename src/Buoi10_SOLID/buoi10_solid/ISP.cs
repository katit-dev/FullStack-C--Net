

public class ISP
{
    // Interface Segregation Principle - Nguyên tắc phân tách interface
    // - Một class không nên bị ép buộc phải thực hiện một interface mà nó không sử dụng
    // - nghĩa là khi thiết kế một interface, chúng ta nên thiết kế sao cho các class chỉ cần implement những phương thức mà nó cần, không cần phải implement những phương thức mà nó không cần, không cần phải implement những phương thức mà nó không sử dụng, v.v.
    /*
    - Lợi ích: giúp giảm phụ thuộc giữa các class, giúp giảm sự phức tạp của code, giúp tăng tính linh hoạt của code, v.v.
    - tập trung vào: giao diện(interface), không tập trung vào: implementation, v.v.

    ***PHân biệt L và I
    - L: Con kế thừa cha, nhưng trong cha có các method không đúng với con
    ===> tách method đó ra khỏi cha, tạo ra 1 interface mới, con sẽ implêmnt interface đó, con sẽ kế thừa cha, con sẽ implement interface đó, con sẽ implement interface đó, v.v.
    - I: Nếu có nhiều hành vi khác nhau trong 1 class, thì nên tách ra thành nhiều interface khác nhau, ai dùng gì thì lấy
    */

}

// HS, Sv sẽ thực thi interface ISinhVien
public interface ISinhVien
{
    void DiHoc();
    // void ThiNghiem();// lab
    // void GDQP();

}

//-------------------------------------------------------------------
// tách ra 2 interface, 1 interface cho GDQP, 1 interface cho ThiNghiem, 1 interface cho DiHoc, v.v.
public interface IThiNghiem
{
    void ThiNghiem();
}
public interface IGDQP
{
    void GDQP();
}

public class TieuHoc : ISinhVien
{
    public void DiHoc()
    {
        Console.WriteLine("Tieu Hoc Di Hoc");
    }

    
}

public class TrungHoc : ISinhVien, IThiNghiem
{
    public void DiHoc()
    {
        Console.WriteLine("Trung Hoc Di Hoc");
    }

    public void ThiNghiem()
    {
        // do nothing, because trung hoc does not need to thi nghiem
        throw new NotImplementedException();// cau nay dung de bao loi, de bao hieu rang trung hoc khong can thi nghiem, khong can implement phuong thuc thi nghiem, khong can implement interface ISinhVien, khong can implement interface ISinhVien, khong can implement interface ISinhVien, v.v.
    }
}