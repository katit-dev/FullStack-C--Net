class BaiTap
{

    #region Bai tap ham callback
    // bai 6 : tim tu dai nhat
    public static string FindLongestWord(string s)
    {
        // Tách chuỗi thành mảng các từ
        string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Biến để lưu từ dài nhất
        string longestWord = "";

        // Duyệt qua từng từ trong mảng
        foreach (string word in words)
        {
            // Cập nhật từ dài nhất nếu từ hiện tại dài hơn
            if (word.Length > longestWord.Length)
            {
                longestWord = word;
            }
        }

        return longestWord;  // Trả về từ dài nhất tìm được
    }
    // bai 7:  loai bo cac ky tu dac biet trong chuoi
    public static string RemoveSpecialChars(string s)
    {
        // Xây dựng chuỗi mới chỉ chứa các ký tự hợp lệ
        string result = "";
        
        foreach (var ch in s)
        {
            // Kiểm tra nếu ký tự là chữ cái hoặc khoảng trắng
            if (Char.IsLetter(ch) || Char.IsWhiteSpace(ch))
            {
                result += ch;
            }
        }
        
        return result;
    }
    // bai 8: tach tu va tra ve tu dai nhat chua so
     public static string FindLongestWordWithNumber(string s)
    {
        string[] words = s.Split(' ');
        string longestWordWithNumber = "";
        
        foreach (var word in words)
        {
            // Kiểm tra nếu từ có chứa số
            if (word.Any(char.IsDigit))
            {
                // Kiểm tra nếu từ này dài hơn từ trước đó
                if (word.Length > longestWordWithNumber.Length)
                {
                    longestWordWithNumber = word;
                }
            }
        }

        return longestWordWithNumber;
    }
    #endregion

    #region Bai tap ham
    // bai tap 5
    // Hàm đảo ngược từng từ trong chuỗi
    public static string ReverseWords(string s)
    {
        // Tách chuỗi thành mảng các từ
        string[] words = s.Split(' ');

        // Đảo ngược từng từ trong mảng
        for (int i = 0; i < words.Length; i++)
        {
            char[] wordArray = words[i].ToCharArray();  // Chuyển từ thành mảng ký tự
            Array.Reverse(wordArray);  // Đảo ngược mảng ký tự
            words[i] = new string(wordArray);  // Chuyển lại thành chuỗi
        }

        // Kết hợp các từ lại thành một chuỗi với khoảng trắng giữa các từ
        return string.Join(" ", words);
    }


    // bai tap 4
    // Hàm kiểm tra độ dài từ cuối cùng trong chuỗi
    public static int LengthOfLastWord(string s)
    {
        // Loại bỏ khoảng trắng ở đầu và cuối chuỗi
        s = s.Trim();

        // Kiểm tra nếu chuỗi rỗng sau khi đã loại bỏ khoảng trắng
        if (s.Length == 0)
        {
            return 0;
        }

        // Tìm vị trí của khoảng trắng cuối cùng
        int lastSpaceIndex = s.LastIndexOf(' ');

        // Nếu không có khoảng trắng, tức là chuỗi chỉ có một từ
        if (lastSpaceIndex == -1)
        {
            return s.Length;
        }

        // Nếu có khoảng trắng, độ dài của từ cuối cùng là chiều dài của chuỗi trừ đi vị trí của khoảng trắng cuối cùng
        return s.Length - lastSpaceIndex - 1;
    }

    // Hàm yêu cầu người dùng nhập chuỗi không rỗng và không chứa khoảng trắng
    public static string NhapChuoiHopLe4()
    {
        string input;
        while (true)
        {
            Console.Write("Nhập vào một chuỗi: ");
            input = Console.ReadLine();  // Nhập chuỗi từ người dùng

            // Loại bỏ khoảng trắng ở đầu và cuối chuỗi
            input = input.Trim();

            // Kiểm tra chuỗi có rỗng không sau khi đã loại bỏ khoảng trắng
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Chuỗi không hợp lệ! Vui lòng nhập lại (chuỗi không được rỗng).");
            }
            else
            {
                return input;  // Trả về chuỗi hợp lệ
            }
        }
    }

    // bai tap 3
    // Hàm in các số nguyên tố trong chuỗi
    public static void InSoNguyenToTuChuoi(string input)
    {
        bool hasPrime = false;  // Biến để kiểm tra xem có số nguyên tố nào không
        
        // Kiểm tra chuỗi nhập vào có phải là số không
        foreach (char c in input)
        {
            if (!char.IsDigit(c))  // Nếu có ký tự không phải là số
            {
                Console.WriteLine("Chuỗi nhập vào không hợp lệ. Vui lòng chỉ nhập các số.");
                return;  // Thoát khỏi hàm nếu chuỗi không hợp lệ
            }
        }

        Console.Write("Các số nguyên tố trong chuỗi là: ");
        
        // Duyệt qua từng ký tự trong chuỗi
        foreach (char c in input)
        {
            int num = int.Parse(c.ToString());  // Chuyển ký tự thành số
            if (IsPrime(num))  // Nếu là số nguyên tố
            {
                Console.Write(num + " ");  // In số nguyên tố
                hasPrime = true;  // Đã có số nguyên tố
            }
        }

        if (!hasPrime)
        {
            Console.WriteLine("Không có số nguyên tố nào.");
        }
        else
        {
            Console.WriteLine();  // Xuống dòng sau khi in xong
        }
    }

    // Hàm nhập chuỗi số hợp lệ
    public static string NhapChuoiHopLe()
    {
        string input;
        while (true)
        {
            Console.Write("Nhập vào một chuỗi số: ");
            input = Console.ReadLine();  // Nhập chuỗi số từ người dùng
            
            // Kiểm tra tính hợp lệ của chuỗi
            bool isValid = true;
            foreach (char c in input)
            {
                if (!char.IsDigit(c))  // Nếu có ký tự không phải là số
                {
                    isValid = false;
                    break;  // Dừng vòng lặp khi gặp ký tự không phải số
                }
            }

            if (isValid)
            {
                return input;  // Trả về chuỗi hợp lệ
            }
            else
            {
                Console.WriteLine("Chuỗi nhập vào không hợp lệ. Vui lòng chỉ nhập các số.");
            }
        }
    }

    // Bai tap 2
    // ham nhap vao 1 so nguyen
    // Hàm in các số nguyên tố từ 2 đến n
    public static void InSoNguyenTo(int n)
    {
        Console.Write("Các số nguyên tố từ 2 đến " + n + " là: ");
        for (int i = 2; i <= n; i++)  // Duyệt qua các số từ 2 đến n
        {
            if (IsPrime(i))  // Nếu i là số nguyên tố
            {
                Console.Write(i + " ");  // In ra số nguyên tố
            }
        }
        Console.WriteLine();  // In xuống dòng sau khi in xong
    }
    public static int NhapSo()
    {
        while (true)
        {
            Console.WriteLine("Nhap vao 1 so nguyen duong lon hon 2: ");
            bool isInt = int.TryParse(Console.ReadLine(), out int input);
            if (isInt && input > 2)
            {
                return input;
            }
            Console.WriteLine("Nhap khong hop le. vui long nhap so nguyen duong lon hon 2!");
        }
    }

    // Hàm kiểm tra số nguyên tố
    public static bool IsPrime(int num)
    {
        if (num < 2) return false;  // Số nhỏ hơn 2 không phải số nguyên tố
        for (int i = 2; i <= Math.Sqrt(num); i++)  // Kiểm tra từ 2 đến căn bậc 2 của num
        {
            if (num % i == 0)  // Nếu num chia hết cho i thì không phải số nguyên tố
                return false;
        }
        return true;
    }

    #endregion


    // Ham tinh trung binh cong cua 3 so
    public static void BTDiemTrungBinh()
    {
        double toan, ly, hoa;
        toan = NhapDiem("Toan");
        ly = NhapDiem("Ly");
        hoa = NhapDiem("Hoa");
        double diemTB = TinhDiemTrungBinh(toan, ly, hoa);
        Console.WriteLine("Diem trung binh: " + diemTB);
        XetDiemHocLuc(diemTB);
    }

    public static double NhapDiem(string monHoc)
    {
        double diem;
        while (true)
        {
            Console.Write($"Nhap diem {monHoc}: ");
            if (double.TryParse(Console.ReadLine(), out diem) && diem >= 0 && diem <= 10)
            {
                return diem;
            }
            else
            {
                Console.WriteLine("Diem khong hop le. Vui long nhap lai.");
            }
        }
    }

    public static double TinhDiemTrungBinh(double toan, double ly, double hoa) => (toan + ly + hoa) / 3;

    public static void XetDiemHocLuc(double diemTB)
    {
        if (diemTB >= 8)
        {
            Console.WriteLine("Hoc luc Gioi");
        }
        else if (diemTB >= 6.5)
        {
            Console.WriteLine("Hoc luc Kha");
        }
        else if (diemTB >= 5)
        {
            Console.WriteLine("Hoc luc Trung Binh");
        }
        else
        {
            Console.WriteLine("Hoc luc Yeu");
        }
    }

    /// <summary>
    /// Hien thi thong tin cua 1 nguoi
    /// </summary>
    /// <param name="ten"></param>
    /// <param name="tuoi"></param>
    public static void HienThiThongTin(string ten, int tuoi) => Console.WriteLine($"Ten: {ten}, Tuoi: {tuoi}");

    //overloading
    // nap chong tham so nghe nghiep
    // trung ten ham, khac ve so luong tham so hoặc kiểu dữ liệu tham số
    public static void HienThiThongTin(string ten, int tuoi, string ngheNghiep) => Console.WriteLine($"Ten: {ten}, Tuoi: {tuoi}, Nghe nghiep: {ngheNghiep}");


    // khai bao gia tri mac dinh
    // neu gan gia tri mac dinh cho phut , ma khong gan cho giay
    //==> bi bao loi
    // phai gan gia tri mac dinh tu vi tri do tro ve sau
    public static void HienThiThoiGian(int gio = 0, int phut = 0, int giay = 0)
    {
        Console.WriteLine($"Thoi gian: {gio}:{phut}:{giay}");
    }


}