public class Open_Close
{
    // Open/Closed Principle - Nguyên tắc mở/đóng
    // - class nên mở để mở rộng, nhưng đóng để sửa đổi
    // - nghĩa là khi cần thêm tính năng mới, không nên sửa đổi code đã có, mà nên mở rộng code đã có bằng cách thêm code mới vào, hoặc kế thừa class đã có để tạo ra class mới
    // - Điều này giúp cho code dễ bảo trì, dễ hiểu và dễ mở rộng hơn
    // - class độc lập chỉ làm nhiệm vụ duy nhất, không phụ thuộc vào các class khác

    /*
    Dong: khong thay doi ma nguon cua class da ton tai


    Mở: cho phép mở rộng chức năng mà không cần sửa đổi mã nguồn hiện có
    */

}

public class GiamGia
{
    // method giam gia theo loai khach hang
    // khach bth giam 1%, thanh vien giam 5%, vip giam 10%
    public double PhanTramGiamGia(string loaiKH)
    {
        if (loaiKH == "BTH")
        {
            return 0.01;
        }
        else if (loaiKH == "TV")
        {
            return 0.05;
        }
        else if (loaiKH == "VIP")
        {
            return 0.1;
        }
        else
        {
            return 0;
        }
    }
}
// them 1 loai kh : Svip
// viết lại phù hợp với nguyên tắc OCP
// -> strategy pattern - mẫu thiết kế chiến lược
// tạo ra các class riêng cho từng loại khach hang, và kế thừa từ 1 interface chung, để mở rộng tính năng mà không cần sửa đổi code đã có
// tạo ra các Interface
// Interface là bản thiết kế, không chứa code thực thi, chỉ chứa các phương thức trừu tượng, các thuộc tính trừu tượng, các sự kiện trừu tượng, v.v.

// moi khac hang la 1 class riêng

public interface IGiamGia
{
    double PhanTramGiamGia();
}


public class KHVipGiamGia : IGiamGia // mot khi implement interface thì bat buoc phải override tất cả các phương thức trong interface đó
{
    public double PhanTramGiamGia()
    {
        return 0.1;
    }
}

public class KHSvipGiamGia : IGiamGia
{
    public double PhanTramGiamGia()
    {
        return 0.15;
    }
}
