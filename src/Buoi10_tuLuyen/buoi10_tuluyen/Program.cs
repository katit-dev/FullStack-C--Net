class Program
{
    static void Main(string[] args)
    {
        // NhanVien nv1 = new NhanVien("Nguyen Van A", 5000, new TinhLuongFullTime());
        // NhanVien nv2 = new NhanVien("Tran Thi B", 6000, new TinhLuongPartTime());
        // NhanVien nv3 = new NhanVien("Le Van C", 7000, new TinhLuongHopDong());

        // nv1.ShowThongTin();
        // nv2.ShowThongTin();
        // nv3.ShowThongTin();

        // Sparow sparow1 = new Sparow("Sparrow1");
        // sparow1.Fly(); // Sparrow1 is flying high.
        // penguin penguin = new penguin("Penguin");
        // // penguin.Fly(); // Lỗi vì Penguin không thể bay

        IMessageSender emailSender = new EmailSender();
        IMessageSender smsSender = new SmsSender();
        NotificationService notificationService = new NotificationService(emailSender);
        notificationService.Notify("Hello via Email!"); // Sending email: Hello via Email!
        notificationService = new NotificationService(smsSender);
        notificationService.Notify("Hello via SMS!"); // Sending SMS: Hello via SMS!
    }
}