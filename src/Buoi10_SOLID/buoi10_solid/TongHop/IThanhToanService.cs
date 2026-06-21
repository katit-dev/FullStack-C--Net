public interface IThanhToanService
{
    void ThanhToan(double tongTien);
}

public class ThanhToanTienMat : IThanhToanService
{
    public void ThanhToan(double tongTien)
    {
        Console.WriteLine($"Thanh toán tiền mặt với tổng tiền: {tongTien}");
    }
}

public class CreaditCardPayment : IThanhToanService
{
    public void ThanhToan(double tongTien)
    {
        Console.WriteLine($"Thanh toán bằng thẻ tín dụng với tổng tiền: {tongTien}");
    }
}

// thanh toan bang vi dien tu
public class EWalletPayment : IThanhToanService
{
    public void ThanhToan(double tongTien)
    {
        Console.WriteLine($"Thanh toán bằng ví điện tử với tổng tiền: {tongTien}");
    }
}


