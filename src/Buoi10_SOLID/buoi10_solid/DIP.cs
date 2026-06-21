/*
DIP - Dependency Inversion Principle
- Nguyên tắc đảo ngược phụ thuộc

*/

// IMessage
public interface IMessage
{
    void SendMessage();
}


public class ZaloOA : IMessage //service: là 1 class cung cấp dịch vụ
{
    public ZaloOA(string message)
    {
        // constructor
    }

    public void SendMessage()
    {
        Console.WriteLine("da gui thong bao zalo");
    }
}

// SMS
public class SMS : IMessage
{
    public void SendMessage()
    {
        Console.WriteLine("đã gửi thông báo SMS");
    }
}


public class GuiThongBao // 
{
    // public ZaloOA _zaloOa = new ZaloOA(); // sử dụng thì khởi tạo bên trong class 
    public IMessage _message;
    public GuiThongBao(IMessage message) // khởi tạo bên ngoài class , có thể truyền vào ZaloOA hoặc SMS , không phụ thuộc vào 1 dịch vụ cụ thể nào
    {
        _message = message;
    }
    public void Gui()
    {
        _message.SendMessage();
    }
}