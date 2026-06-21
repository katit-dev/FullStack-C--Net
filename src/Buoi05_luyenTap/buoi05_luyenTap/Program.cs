using System.Collections;

public class Program
{
    public static void Main(string[] args)
    {
        // BaiTap.BT_DiemTrungBinh2();
        // B3 : goi ham
        // LamViec(BaoHoanThanh);

        //ProcessData((message) => Console.WriteLine(message));

        #region Chuyển đổi các Collection
        /*Chuyển từ HashSet sang List
        -  chuyển từ HashSet sang List chỉ cần .ToList()
        */
        HashSet<int> hashSetNumbers = new HashSet<int>() {1, 1, 2, 3, 4, 5 };
        // HashSet không cho phép phần tử trùng lặp
        // nhưng khi khởi tạo có thể có phần tử trùng lặp
        // HashSet sẽ tự động loại bỏ phần tử trùng lặp đó
        List<int> listNumbers = hashSetNumbers.ToList();
        Console.WriteLine("Các phần tử trong listNumbers sau khi chuyển từ hashSetNumbers: ");
        foreach (var num in listNumbers)
        {
            Console.WriteLine(num);
        }

        /*Chuyển từ List sang HashSet
        - chuyển từ List sang HashSet chỉ cần .ToHashSet()
        */
        List<int> listNums = new List<int>() { 1, 2, 2, 3, 4, 5, 5 };
        HashSet<int> hashSetNums = listNums.ToHashSet(); 
        // HashSet sẽ tự động loại bỏ phần tử trùng lặp khi chuyển từ List sang HashSet
        Console.WriteLine("Các phần tử trong hashSetNums sau khi chuyển từ listNums: ");
        foreach (var num in hashSetNums)
        {
            Console.WriteLine(num);
        }

        /*Chuyển từ Dictionary sang List
        - chuyển từ Dictionary sang List chỉ cần .ToList()
        */
        Dictionary<int, string> dict = new Dictionary<int, string>()
        {
            {1, "Nguyen Van A" },
            {2, "Tran Thi B" },
            {3, "Le Van C" }
        };
        List<int> listKeys = dict.Keys.ToList();
        List<string> listValues = dict.Values.ToList();
        Console.WriteLine("Các khóa trong dictionary: ");
        foreach (var key in listKeys)
        {
            Console.WriteLine(key);
        }
        Console.WriteLine("Các giá trị trong dictionary: ");
        foreach (var value in listValues)
        {
            Console.WriteLine(value);
        }
        // dùng KeyValuePair để chuyển Dictionary sang List
        // keyValuePair là kiểu dữ liệu đại diện cho một cặp khóa-giá trị trong Dictionary
        // là 1 kiểu dữ liệu tổng hợp (struct) chứa 2 thuộc tính: Key và Value
        List<KeyValuePair<int, string>> listDict = dict.ToList();
        Console.WriteLine("Các phần tử trong listDict sau khi chuyển từ dictionary: "); 
        foreach (var item in listDict)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }
        #endregion

        #region hashSet
        // // Hashset là tập hợp các phần tử duy nhất, không trùng lặp, không có thứ tự index
        // // Cú pháp khai báo:
        // // HashSet<kiểu dữ liệu> tên biến = new HashSet<kiểu dữ liệu>();
        // HashSet<string> thanhPho = new HashSet<string>(); // khai báo HashSet rỗng
        //                                                   // khai báo và khởi tạo HashSet với các phần tử ban đầu
        // HashSet<string> dsMauSac = new HashSet<string>() { "Đỏ", "Xanh", "Vàng", "Trắng" , "Đỏ"};
        // // khi có 2 phần tử trùng nhau, HashSet sẽ tự động loại bỏ phần tử trùng lặp
        
        // // kiem tra co mau den khong
        // bool coMauDen = dsMauSac.Contains("Đen");
        // Console.WriteLine(coMauDen ? "Co Mau den" :"Khong co mau den");

        // // duyệt HashSet và in ra các phần tử
        // // khi hợp nhất SetA với SetB, thì các phần tử của SetA 
        // // sẽ được giữ nguyên, chỉ thêm các phần tử của SetB mà không trùng lặp
        // // với các phần tử đã có trong SetA
        // // Còn SetB sẽ không bị thay đổi

        // foreach (var mau in dsMauSac)
        // {
        //     Console.WriteLine(mau);
        // }

        // // hợp nhất hai HashSet
        // Console.ForegroundColor = ConsoleColor.Red;
        // HashSet<int> setA = new HashSet<int>() { 1, 2, 3, 4 };
        // HashSet<int> setB = new HashSet<int>() { 5, 6 };
        // setA.UnionWith(setB); // hợp nhất setB vào setA
        // Console.WriteLine("Set A sau khi hợp nhất:");
        // foreach (var num in setA)
        // {
        //     Console.WriteLine(num);
        // }
        // Console.ResetColor();
        // Console.WriteLine("Set B sau khi hợp nhất");
        // foreach (var num in setB)
        // {
        //     Console.WriteLine(num);
        // }


    #endregion

        #region kieu du lieu var - object
        // sự khác nhau giữa var và object:
        // var: kiểu dữ liệu được xác định tại thời điểm biên dịch dựa trên giá trị khởi tạo.
        // object: kiểu dữ liệu cơ sở của tất cả các kiểu trong C#, có thể chứa bất kỳ kiểu dữ liệu nào.
        /* ví dụ:
            var x = 10; // x có kiểu int
            object y = 20; // y có kiểu object, nhưng chứa giá trị int

            // phép gán giữa var và object
            object obj = x; // hợp lệ, vì var có thể được gán cho object
            // var z = y; // lỗi, vì object không thể được gán trực tiếp cho var

            // ép kiểu (casting)
            int a = (int)obj; // ép kiểu từ object về int
            // int b = (int)y; // lỗi, cần ép kiểu từ object về int
        */
        #endregion

        #region  kieu du lieu tap hop -  Dictionary 
        // /* Dictionary<TKey, TValue>: tập hợp các cặp khóa-giá trị,
        // cho phép truy xuất giá trị thông qua khóa.
        // - vd: 
        //       key: mã sinh viên, value: Tên sinh viên
        //         key: mã sản phẩm, value: giá sản phẩm
        //         key: CCCD, value: thông tin cá nhân
        // - value có thể trùng lặp, nhưng key thì không được trùng lặp.
        // - cú pháp:
        //     Dictionary<kiểu dữ liệu key, kiểu dữ liệu value> tên_biến = new Dictionary<kiểu dữ liệu key, kiểu dữ liệu value>();
        // - không truy xuất phần tử qua chỉ số (index) như mảng hay list,
        //   mà truy xuất thông qua key.
        // - truy cập key không tồn tại --> lỗi KeyNotFoundException
        // */
        // // khai báo Dictionary chứa danh sách các sinh viên với key là mã sinh viên (string) và value là tên sinh viên (string)
        // Dictionary<int, string> dsSinhVien = new Dictionary<int, string>();
        // dsSinhVien.Add(1, "Nguyen Van A");
        // dsSinhVien.Add(2, "Tran Thi B");
        // dsSinhVien.Add(3, "Le Van C");
        // // truy xuất phần tử qua key
        // Console.WriteLine("Tên sinh viên có mã 1 là: " + dsSinhVien[1]);

        // // ds bệnh nhân với key là số bệnh án (string) và value là tên bệnh nhân (string)
        // Dictionary<string, string> dsBenhNhan = new Dictionary<string, string>();
        // // thêm bệnh nhân vào ds
        // dsBenhNhan.Add("BN001", "Phạm Thị D");
        // dsBenhNhan.Add("BN002", "Hoàng Thị E");

        // // truy cập bệnh nhân có số bệnh án là BN002
        // var tenBenhNhan = dsBenhNhan["BN002"];
        // Console.WriteLine($"Tên bệnh nhân có số BN002 là {tenBenhNhan}");

        // dsBenhNhan.Remove("BN001"); //xóa bệnh nhân có số bệnh án BN001 khỏi ds
        // dsBenhNhan.Where(x => x.Key == "BN002"); // tìm kiếm bệnh nhân có số bệnh án BN002
        // // duyet va in toan bo danh sach benh nhan
        // foreach (var bn in dsBenhNhan)
        // {
        //     Console.WriteLine($"Số bệnh án: {bn.Key}, Tên bệnh nhân: {bn.Value}");
        // }

        // Console.ForegroundColor = ConsoleColor.Red;
        // foreach (var bn in dsBenhNhan)
        // {
        //     Console.WriteLine($"[Where] Số bệnh án: {bn.Key}, Tên bệnh nhân: {bn.Value}");
        // }
        // Console.ResetColor();

        // // Dictionary dạng string, object
        // Dictionary<string, object> thongTinNguoiDung = new Dictionary<string, object>();
        // thongTinNguoiDung.Add("Name", "Nguyen Van F");
        // thongTinNguoiDung.Add("Age", 30);
        // thongTinNguoiDung.Add("IsMember", true);

        // foreach (var item in thongTinNguoiDung)
        // {
        //     Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        // }

        #endregion

        #region collection example
        // // collection ArrayList - non generic
        // ArrayList list1 = new ArrayList();
        // list1.Add(1);
        // list1.Add("hello");
        // list1.Add(3.14);
        // // duyet va in list1
        // foreach (var item in list1)
        // {
        //     Console.WriteLine(item);
        // }

        // // collection List<T> - generic
        // List<int> list2 = new List<int>();
        // list2.Add(1);
        // list2.Add(9);
        // // list2.Add("hello"); // bao loi
        // // list2.Add(3.14); // bao loi

        // foreach (var item in list2)
        // {
        //     Console.WriteLine(item);
        // }
        #endregion

        #region kieu du lieu tap hop - array
        // // Mảng Array: danh sách các phần tử có cùng kiểu dữ liệu,
        // // kich thước cố định.
        // // truy xuất phần tử qua chỉ số (index)
        // int[] numbers = new int[5]; // khai báo mảng số nguyên có 5 phần tử
        // int[] primes = { 2, 3, 5, 7, 11 }; // khai báo và khởi tạo mảng
        // // truy xuất phần tử mảng
        // Console.WriteLine("Phan tu dau tien: " + primes[0]); // in ra 2
        // Console.WriteLine("Phan tu thu ba: " + primes[2]); // in
        #endregion

        #region kieu du lieu tap hop - list
        // // List<T>: danh sách các phần tử có cùng kiểu dữ liệu,
        // // kích thước động (có thể thay đổi).
        // // truy xuất phần tử qua chỉ số (index)
        // List<string> fruits = new List<string>();
        // fruits.Add("Apple");
        // // chen nhieu phan tu cung luc
        // fruits.AddRange("Banana", "Orange", "Mango");
        // // truy xuất phần tử list
        // Console.WriteLine("Phan tu dau tien: " + fruits[0]); // in ra Apple

        // foreach (var fruit in fruits)
        // {
        //     Console.WriteLine(fruit);
        // }
        // Console.ForegroundColor = ConsoleColor.Red;
        // fruits.RemoveAll(f => f.StartsWith("M")); // xoa cac phan tu bat dau bang chu M
        // fruits.RemoveAll(f => f.Contains("a")); // xoa cac phan tu chua chu 'a'
        // Console.WriteLine("Sau khi xoa:");
        // foreach (var fruit in fruits)
        // {
        //     Console.WriteLine(fruit);
        // }
        // Console.ResetColor();

        #endregion

        #region Callback function example
        // // B1: ham chinh
        // public static void LamViec(Action callback)
        // {
        //     Console.WriteLine("Bat dau lam viec...");
        //     // thuc hien cong viec
        //     System.Threading.Thread.Sleep(2000); // gia lap thoi gian lam viec
        //     // goi ham callback
        //     callback();
        // }
        // // B2: ham callback
        // public static void BaoHoanThanh()
        // {
        //     Console.WriteLine("Da lam xong cong viec.");
        // }

        // B1: ham callback
        // public delegate void NotifyCallback(string message);
        // // B2: ham chinh
        // public static void ProcessData(NotifyCallback callback)
        // {
        //     Console.WriteLine("Bat dau xu ly du lieu...");
        //     // thuc hien cong viec
        //     System.Threading.Thread.Sleep(2000); // gia lap thoi gian lam viec
        //     // goi ham callback
        //     callback("Da xu ly xong du lieu.");
        // }


        #endregion


    }


}