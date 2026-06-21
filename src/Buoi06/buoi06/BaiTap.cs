using System.ComponentModel;
using System.Diagnostics;

class BaiTap
{

    #region chuyển đổi
    public static void ChuyenDoi()
    {
        // HashSet -> List
        HashSet<int> hashsetSo = new HashSet<int>() {1, 2, 3};
        List<int> listSo = hashsetSo.ToList();// chuyển HashSet sang List chỉ cần ToList

        Console.WriteLine("---------------------------------------------------------------------");
        foreach (var item in listSo)
        {
            Console.WriteLine($"so trong list: {item}");
        }

        // Dictionary<key, value>
        // list key
        // list value
        // -> List<keyvaluePair<key, value>

        Dictionary<int, string> dsSinhVien = new Dictionary<int, string>()
        {
            {1, "Nguyen van a"},
            {2, "tran thi b"},
            {3, "le van c"}
        };
        List<int> lstKey = dsSinhVien.Keys.ToList(); // lấy danh sách key và chuyển thành list
        List<string> lstValue = dsSinhVien.Values.ToList();// lấy danh sách value
        Console.WriteLine("----------------------------------------------------------------------");

        List<KeyValuePair<int, string>> dictToList = dsSinhVien.ToList();// chuyen Dictionary thành List<KeyValuePair<key, value>>

        // keyValuaPair: là kiểu dữ liệu đại diện cho một cặp key-value trong Dictionary, là 1 kiểu dữ liệu cấu trúc 'struct'
    }
    #endregion

    

    #region Dictionary
    public static void LyThuyetDictionary()
    {
        /*
               - dictionary chứa danh sáchc các cặp key - value
               - vd: 
                   key: mã sinh viên, value: Tên sinh viên
                   keu: CCCD, value: thông tin của chủ thẻ (tên, ngày sinh, địa chỉ,...)
               - key phải là duy nhất, không được trùng lặp
               - value có thể trùng lặp
               - cú pháp khai báo:
               Dictionary<kiểu dữ liệu key, kiểu dữ liệu value> tên biến = new Dictionary<kiểu dữ liệu key, kiểu dữ liệu value();

               --> không có thứ tự index như Array, List
               vd sử dụng: list: ds sinh viên dự thi là mã sv
                   Dictionary: sdt trong danh bạ: tên người dùng tương ứng

                - truy cập key không tồn tại sẽ bị lỗi

               */

        // khai báo Dictionary chứa danh sách sinh viên với key là mã sinh viên (int) và value là tên sinh viên (string)
        Dictionary<int, string> dsSinhVien = new Dictionary<int, string>();
        dsSinhVien.Add(1, "Nguyễn Văn a");
        dsSinhVien.Add(2, "Trần thị b");
        dsSinhVien.Add(3, "Lê văn c");

        // truy cập phần tử trong Dictionary thông qua key
        // truy cập sinh viên có key =1
        string tenSv1 = dsSinhVien[1];// lấy tên sinh viên có mã sinh viên là 1
        Console.WriteLine("Tên sinh viên có mã 1 là: " + tenSv1);

        // ds bệnh nhân với key là số bệnh án (string) và value là tên bệnh nhân (string)
        Dictionary<string, string> dsBenhNhan = new Dictionary<string, string>();
        // thêm bệnh nhân vào ds
        dsBenhNhan.Add("BN001", "Phạm Thị D");
        dsBenhNhan.Add("BN002", "Hoàng Thị E");

        // truy cập bệnh nhân có số bệnh án la fBN002
        var tenBenhNhan = dsBenhNhan["BN002"];
        Console.WriteLine($"Tên bệnh nhân có số BN002 là {tenBenhNhan}");

        dsBenhNhan.Remove("BN001"); //xóa bệnh nhân có số bệnh án BN001 khỏi ds
        dsBenhNhan.Where(x => x.Key == "BN002");// tìm kiếm bệnh nhân có số bệnh án BN002, thay đổi dict theo điều kiện

        // duyệt ds bệnh nhân va in ra thông tin bệnh nhân
        foreach (var item in dsBenhNhan)
        {
            Console.WriteLine($"Số bệnh án: {item.Key}, tên bệnh nhân: {item.Value}");
        }

        foreach (var item in dsBenhNhan)
        {
            Console.WriteLine($"[Where] Số bệnh án: {item.Key}, tên bệnh nhân: {item.Value}");
        }

        // var vaf object

        // Dictionary dạng string, object
        Dictionary<string, object> thongTinNguoidung = new Dictionary<string, object>();
        thongTinNguoidung.Add("HoTen", "Nguyễn Văn A");
        thongTinNguoidung.Add("Tuoi", "25");
        thongTinNguoidung.Add("Dia chi", "Ho Chi Minh");

        foreach (var item in thongTinNguoidung)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        // kiem tra key co tồn tại trong Dictionary không
        bool coBN003 = dsBenhNhan.ContainsKey("BN003");// kiểm tra key BN003 có tồn tại không
        if (coBN003)
        {
            // xòa/ in thông tin
        }

    }
    #endregion

    #region bai tap List collection
    // bai tap: tinh tong cac so lon hon 50 trong danh sach
    // public static void TongCaccSoLonHon50()
    // {
    //     List<int> dsSo = new List<int>() { 20, 81, 97, 63, 72, 11, 20, 15, 41, 20 };

    //     int tong = 0;
    //     var dsSoLonHon50 = dsSo.FindAll(so => so > 50);
    //     // cach 1
    //     // tong = dsSoLonHon50.Sum();

    //     // cach 2
    //     foreach (var so in dsSoLonHon50)
    //     {
    //         tong += so;
    //     }
    //     Console.WriteLine("Tổng các số lớn hơn 50 là: " + tong);
    // }

    // //tim so lon nhat trong danh sach
    // public static void TimSoLonNhat()
    // {
    //     List<int> dsSo = new List<int>() { 20, 81, 97, 63, 72, 11, 20, 15, 41, 20 };

    //     int soLonNhat = dsSo.Max();
    //     Console.WriteLine("Số lớn nhất trong danh sách là: " + soLonNhat);
    // }

    // // dem so phan tu lon hon 30 trong danh sach
    // public static void DemSoPhanTuLonHon30()
    // {
    //     List<int> dsSo = new List<int>() { 20, 81, 97, 63, 72, 11, 20, 15, 41, 20 };

    //     int count = dsSo.Count(so => so > 30);
    //     Console.WriteLine("Số phần tử lớn hơn 30 trong danh sách là: " + count);
    // }

    // // tinh trung binh cong cac so le
    // public static void TrungBinhCongCacSoLe()
    // {
    //     List<int> dsSo = new List<int>() { 20, 81, 97, 63, 72, 11, 20, 15, 41, 20 };

    //     var dsSoLe = dsSo.FindAll(so => so % 2 != 0);
    //     double trungBinhCong = dsSoLe.Average();

    //     Console.WriteLine("Trung bình cộng các số lẻ trong danh sách là: " + trungBinhCong);
    // }
    // //in ra cac so chan trong danh sach
    // public static void InRaCacSoChan()
    // {
    //     List<int> dsSo = new List<int>() { 20, 81, 97, 63, 72, 11, 20, 15, 41, 20 };

    //     var dsSoChan = dsSo.FindAll(so => so % 2 == 0);

    //     Console.WriteLine("Các số chẵn trong danh sách là: ");
    //     foreach (var so in dsSoChan)
    //     {
    //         Console.WriteLine(so);
    //     }
    // }
    #endregion

    #region bai tap List - string
    // tinh do dai cua mang
    public static void LengthOfStringList()
    {
        List<string> dsChuoi = new List<string>() { "apple", "banana", "orange", "kiwi", "mango", "pineapple", "grape", "melon" };
        Console.WriteLine("Length of List " + dsChuoi.Count);
    }

    // in ra chuoi dai hon 5 ky tu


    #endregion

    #region Callback function
    // la ham duoc truyen qua lam tham so cho ham khac
    // public static void XuLyHienThi(int so, Action<int> hienThi)
    // {
    //     // tinh binh phuong va goi ham hien thi
    //     int binhPhuong = so * so;
    //     hienThi(binhPhuong);
    // }

    // public static void HienThiKetQua(int ketQua)
    // {
    //     Console.WriteLine("Ket qua: " + ketQua);
    // }
    #endregion

    #region Bai tap cũ
    // SUA BAI TAP 4 TAI DAY
    // public static int DoDaiTuCuoiCung(string str)
    // {
    //    str = str.Trim();
    //    if (str.Length == 0)
    //     {
    //         return 0; // neu chuoi rong, tra ve 0
    //     }
    //    // tim vi tri khoang trang cuoi cung
    //      int lastSpaceIndex = str.LastIndexOf(' ');
    //     if (lastSpaceIndex == -1)
    //     {
    //         return str.Length; // neu khong co khoang trang, tra ve do dai chuoi
    //     }
    //     else
    //     {
    //         return str.Length - lastSpaceIndex - 1; // tinh do dai tu cuoi cung
    //     }
    // }

    // // bai tap 4: tinh do dai cua tu cuoi cung trong chuoi
    // public static int LengthOfWord(string s)
    // {
    //     s = s.Trim();

    //     if (s.Length == 0)
    //     {
    //         return 0;
    //     }

    //     int lastSpaceIndex = s.LastIndexOf(' ');

    //     if (lastSpaceIndex == -1)
    //     {
    //         return s.Length;
    //     }

    //     return s.Length - lastSpaceIndex - 1;

    // }

    // // Ham nhap chuoi he lop
    // public static string NhapChuoiHeLop4()
    // {
    //     string input;
    //     while (true)
    //     {
    //         Console.Write("Nhap vao 1 chuoi: ");
    //         input = Console.ReadLine();
    //         input = input.Trim();
    //         if (string.IsNullOrEmpty(input))
    //         {
    //             Console.WriteLine("Chuoi khong duoc de trong. Vui long nhap lai.");
    //             continue;
    //         }
    //         else
    //         {
    //             return input;
    //         }
    //     }
    // }
    #endregion

}