namespace b19.Models
{

    public  class PhoneCartVM
    {
        public int MaSp { get; set; }
        public string TenSp { get; set; }
        public string ManHinh { get; set; }
        public string HeDieuHanh { get; set; }
        public string CameraTruoc { get; set; }
        public string CameraSau { get; set; }
        public string Ram { get; set; }
        public string Rom { get; set; }
        public long GiaBan { get; set; }
        public string HinhAnh { get; set; }
    }
}

// tạo class ít thông tin hơn đểl lưu giỏ hàng
public class CartItemVM
{
    public int MaSp { get; set; }
    public string TenSp { get; set; }
    public long GiaBan { get; set; }
    public string HinhAnh { get; set; }
    public int SoLuong { get; set; }
}
