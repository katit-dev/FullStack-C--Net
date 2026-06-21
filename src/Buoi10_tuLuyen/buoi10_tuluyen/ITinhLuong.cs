public interface ITinhLuongStrategy
{
    double TinhLuong(double luongCoBan);
}

// tinh luong cho nhan vien fulltime
public class TinhLuongFullTime : ITinhLuongStrategy
{
    public double TinhLuong(double luongCoBan)
    {
        return luongCoBan * 1.5; // Ví dụ: nhân viên full-time được trả 150% lương cơ bản
    }
}

// tinh luong cho nhan vien parttime
public class TinhLuongPartTime : ITinhLuongStrategy
{
    public double TinhLuong(double luongCoBan)
    {
        return luongCoBan; // Ví dụ: nhân viên part-time được trả đúng lương cơ bản
    }
}

// tinh luong cho nhan vien hop dong
public class TinhLuongHopDong : ITinhLuongStrategy
{
    public double TinhLuong(double luongCoBan)
    {
        return luongCoBan * 0.8; // Ví dụ: nhân viên hợp đồng được trả 80% lương cơ bản
    }
}