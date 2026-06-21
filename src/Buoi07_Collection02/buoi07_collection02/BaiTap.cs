class BaiTap
{

    #region Bai tap Dict list 2
    // bai tap tim chuoi con lien tuc dai nhat
    public static void TimSanhDaiNhat()
    {
        
    }

    #endregion

    #region Bai tap Dict list
    public static void BaiTap_Dict_List()
    {
        int[] prices = { 7, 1, 2, 5, 3, 6, 4 };

        int minPrice = prices[0];
        int maxProfit = 0;

        foreach (int price in prices)
        {
            if (price < minPrice)
                minPrice = price;
            else
                maxProfit = Math.Max(maxProfit, price - minPrice);
        }

        Console.WriteLine(maxProfit); // 5

    }
    #endregion

    #region ThamChieuThamTri
    public static void ThamChieuThamTri()
    {
        // tham tri 
        // tham trị là khi giá trị thực của biến được lưu trữ trực tiếp trong vùng nhớ của biến đó
        // tham trị là copy giá trị, không tham chiếu vào
        int a = 5; // a được lưu trong stack với giá trị 5, có địa chỉ là 0x01
        int b = a; // b được lưu trong stack với giá trị 5, có địa chỉ là 0x02 (khác với a)
        b = 10;    // thay doi gia tri cua b khong anh huong den a
        Console.WriteLine($"a = {a}, b = {b}"); // a = 5, b = 10

        // tham chieu
        List<int> ints1 = new List<int> { 1, 2, 3 }; // ints1 được lưu trong stack với địa chỉ 0x03,
        //  tham chiếu đến vùng nhớ heap chứa danh sách {1, 2, 3}
        List<int> ints2 = ints1; // ints2 được lưu trong stack với địa chỉ 0x04, tham chiếu đến cùng vùng nhớ heap với ints1
        ints2.Add(4); // thay doi gia tri cua ints2 anh huong den ints1 vi ca hai cung tham chieu den vung nho heap
        Console.WriteLine($"ints1: {string.Join(", ", ints1)}"); // ints
        Console.WriteLine($"ints2: {string.Join(", ", ints2)}"); // ints2: 1, 2, 3, 4

        // string cũng là reference type nhưng có tính bất biến (immutable)
        string str1 = "Hello"; // str1 được lưu trong stack với địa chỉ 0x05, tham chiếu đến vùng nhớ heap chứa chuỗi "Hello"
        string str2 = str1;   // str2 được lưu trong stack với địa chỉ 0x06, tham chiếu đến cùng vùng nhớ heap với str1 
        str2 += ", World!";   // str2 bây giờ tham chiếu đến một vùng nhớ heap mới chứa chuỗi "Hello, World!"
        Console.WriteLine($"str1: {str1}"); // str1: Hello
        Console.WriteLine($"str2: {str2}"); // str2: Hello,
    }
    #endregion

    #region Bai tap 2 Collection 02
    public static void BaiTap2_Collection02()
    {
        // nhap so luong sinh vien
        int n = NhapSoLuongSinhVien();

        // nhap diem cua n sinh vien
        List<float> diemSinhVien = NhapDiemSinhVien(n);

        // tinh diem trung binh
        float diemTrungBinh = TinhDiemTrungBinh(diemSinhVien);

        // in ket qua
        Console.WriteLine($"Diem trung binh cua {n} sinh vien la: {diemTrungBinh:F2}");

        Console.WriteLine("Diem cao nhat la: " + diemSinhVien.Max());
        Console.WriteLine("Diem thap nhat la: " + diemSinhVien.Min());
    }

    // ham nhap so luong sinh vien
    public static int NhapSoLuongSinhVien()
    {
        int n;
        bool isValid;
        do
        {
            Console.Write("Nhap so luong sinh vien (n > 0): ");
            isValid = int.TryParse(Console.ReadLine(), out n);
            if (!isValid || n <= 0)
                Console.WriteLine("Nhap khong hop le. Vui long nhap lai!");
        } while (!isValid || n <= 0);
        return n;
    }
    // ham cho phep nhap diem cua n sinh vien
    public static List<float> NhapDiemSinhVien(int n)
    {
        List<float> diemSinhVien = new List<float>();
        for (int i = 0; i < n; i++)
        {
            float diem;
            bool isValid;
            do
            {
                Console.Write($"Nhap diem sinh vien thu {i + 1} (0.0 - 10.0): ");
                isValid = float.TryParse(Console.ReadLine(), out diem);
                if (!isValid || diem < 0.0f || diem > 10.0f)
                    Console.WriteLine("Nhap khong hop le. Vui long nhap lai!");
            } while (!isValid || diem < 0.0f || diem > 10.0f);
            diemSinhVien.Add(diem);
        }
        return diemSinhVien;
    }
    // ham tinh diem trung binh cua n sinh vien
    public static float TinhDiemTrungBinh(List<float> diemSinhVien)
    {
        float tongDiem = 0.0f;
        foreach (float diem in diemSinhVien)
        {
            tongDiem += diem;
        }
        return tongDiem / diemSinhVien.Count;
    }

    #endregion

    #region Bài Tập1 Collection 02
    // cach 1: 
    public static void TwoSum(int target)
    {


        // bai tap 1
        List<int> nums = new List<int> { 2, 7, 11, 15 };
        bool found = false;
        // lan 1: so can tim la 9-2=7
        for (int i = 0; i < nums.Count; i++)
        {
            int complement = target - nums[i];

            for (int j = i; j < nums.Count; j++)
            {
                if (nums[j] == complement)
                {
                    Console.WriteLine($"{i}, {j}");
                    found = true;
                    break;
                }
            }

            if (found)
                break;
        }
        if (!found)
            Console.WriteLine("No two sum solution");

    }

    // cach 2: su dung dictionary
    public static void TwoSum_Dictionary(int target)
    {
        List<int> nums = new List<int> { 2, 7, 11, 15 };
        Dictionary<int, int> numDict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Count; i++)
        {
            int complement = target - nums[i];

            if (numDict.ContainsKey(complement))
            {
                Console.WriteLine($"{numDict[complement]}, {i}");
                return;
            }

            if (!numDict.ContainsKey(nums[i]))
                numDict.Add(nums[i], i);
        }

        Console.WriteLine("No two sum solution");
    }

    #endregion


}