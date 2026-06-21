public class Program
{
    public static void Main(string[] args)
    {
        // BaiTap.BTDiemTrungBinh();
        // BaiTap.HienThiThongTin("Nguyen Van A", 20);
        // BaiTap.HienThiThoiGian(10);
        // BaiTap.HienThiThoiGian(10, 30);
        // BaiTap.HienThiThoiGian(10, 30, 45);
        // // giu gio va phut mac dinh, chi thay doi giay
        // BaiTap.HienThiThoiGian(giay: 15);

        // bai 2
        int n = BaiTap.NhapSo();
        BaiTap.InSoNguyenTo(n);
        // bai 3
        string input = BaiTap.NhapChuoiHopLe();
        BaiTap.InSoNguyenToTuChuoi(input);
        // bai 4
        string input4 = BaiTap.NhapChuoiHopLe4();
        int length = BaiTap.LengthOfLastWord(input4);
        Console.WriteLine("Độ dài của từ cuối cùng: " + length);
        // bai 5
        string input5 = BaiTap.NhapChuoiHopLe4();
        string result = BaiTap.ReverseWords(input5);
        Console.WriteLine("Chuoi sau khi dao nguoc tu: " + result);

        // bai 6
        string input6 = BaiTap.NhapChuoiHopLe4();
        string result6 = BaiTap.FindLongestWord(input6);
        Console.WriteLine("Tu dai nhat trong chuoi: " + result6);

        // bai 7
        string input7 = BaiTap.NhapChuoiHopLe4();
        string result7 = BaiTap.RemoveSpecialChars(input7);
        Console.WriteLine("Chuoi sau khi loai bo ky tu dac biet: " + result7);

        // bai 8
        string input8 = BaiTap.NhapChuoiHopLe4();
        string result8 = BaiTap.FindLongestWordWithNumber(input8);
        Console.WriteLine("Tu dai nhat chua so trong chuoi: " + result8);
   

        // #region Lamda Expression
        // // bieu thuc lambda (Lamda Expression)
        // // (thamso) => bieu thuchoac cauLenh
        // // Lamda la ham khong ten
        // // func la ham co gia tri tra ve

        // Func<int, int> binhPhuong = (a) => a * a;
        // // int dau tien la kieu du lieu tham so truyen vao
        // // int thu hai la kieu du lieu gia tri tra ve
        // // a la tham so truyen vao
        // // a * a la bieu thuc tra ve
        // int kqBinhPhuong = binhPhuong(5);
        // Console.WriteLine("Binh phuong cua 5 la: " + kqBinhPhuong);

        // // co the tra ve string
        // Func<int, string> xepLoai = (diem) =>
        // {
        //     if (diem >= 8)
        //         return "Gioi";
        //     else if (diem >= 6.5)
        //         return "Kha";
        //     else if (diem >= 5)
        //         return "Trung Binh";
        //     else
        //         return "Yeu";
        // };
        // string hocLuc = xepLoai(7);
        // Console.WriteLine("Hoc luc: " + hocLuc);

        // // Action la ham khong co gia tri tra ve
        // Action<string> inThongBao = (thongBao) => Console.WriteLine("Thong bao: " + thongBao);
        // inThongBao("Chao mung ban den voi Bootcamp .NET");
        // Action<int, int> inTong = (a, b) =>
        // {
        //     int tong = a + b;
        //     Console.WriteLine("Tong: " + tong);
        // };
        // inTong(5, 10);

        // Func<int, int, int, double> tinhDiemTB = (toan, ly, hoa) => (toan + ly + hoa) / 3.0;
        // double diemTB = tinhDiemTB(7, 8, 9);
        // Console.WriteLine("Diem trung binh: " + diemTB);

        // #endregion

        // #region Function
        // // ham la dong goi 1 doan ma co the su dung lai nhieu lan trong chuong trinh
        // // ham giup chuong trinh co cau truc ro rang hon, de doc hon, de bao tri hon
        // // ham giup tranh lap lai code
        // // cu phap dinh nghia ham:
        // /*
        // void tenHam(thamSo1, thamSo2,...)
        // {
        //     // body ham
        //     // cau lenh
        //     // cau lenh
        //     // cau lenh
        //     // ...
        //     // cau lenh
        //     // return ketQua;  // neu co gia tri tra ve
        // }
        // */
        // // void HelloWorld()
        // // {
        // //     Console.WriteLine("Hello World");
        // // }
        // // // goi ham
        // // HelloWorld();

        // // for (int i = 0; i < 3; i++)
        // // {
        // //     HelloWorld();
        // // }

        // // cach dung ham co tham so(Parameter)
        // // co cac dang functiion:
        // /*
        // - Ham void khong tham so
        // - Ham void co tham so
        // - Ham co gia tri tra ve khong tham so
        // - Ham co gia tri tra ve co tham so
        // ==> ham co gia tri tra ve khi goi ham can 1 bien de hung gia tri tra ve

        // */
        // // ham tinh trung binh cong cua 3 so, sau do lay gia tri tra ve de xet hoc luc
        // // float tinhTrungBinhCong(float a, float b, float c)
        // // {

        // //     float tb = (a + b + c) / 3;
        // // }
        // // dung expression bodied function de viet ngan gon hon

        // // float tinhTrungBinhCong(float a, float b, float c) => (a + b + c) / 3;
        // // // goi ham
        // // float kq = tinhTrungBinhCong(7, 8, 9);
        // // Console.WriteLine("Trung binh cong 3 so la: " + kq);



        // #endregion

        // #region bai 4 ham

        // // viet ham cho phep nguoi dung nhap 1 chuoi so, va in ra cac so nguyen to trog do
        // // void inSoNguyenToTuChuoi(string chuoiSo)
        // // {
        // //     Console.WriteLine("Cac so nguyen to trong chuoi la: ");
        // //     foreach (char c in chuoiSo)
        // //     {
        // //         if (char.IsDigit(c))
        // //         {
        // //             int so = int.Parse(c.ToString());
        // //             if (so >= 2)
        // //             {
        // //                 bool isPrime = true;
        // //                 for (int i = 2; i <= Math.Sqrt(so); i++)
        // //                 {
        // //                     if (so % i == 0)
        // //                     {
        // //                         isPrime = false;
        // //                         break;
        // //                     }
        // //                 }
        // //                 if (isPrime)
        // //                 {
        // //                     Console.Write(so + " ");
        // //                 }
        // //             }
        // //         }
        // //     }
        // //     Console.WriteLine();
        // // }
        // #endregion

        // #region bai 4 ham su dung
        // // string n;
        // // Console.WriteLine("nhap n:");
        // // n = Console.ReadLine();
        // // inSoNguyenToTuChuoi(n);


        // // nhap vao 1 chuoi chua cac tu cach nhau boi khoang trang
        // // viet ham tra ve do dai cua tu cuoi cung trong chuoi
        // // B1: kiem tra chuoi rong ==> return 0
        // // B2: bo khoang trang o dau va cuoi chuoi
        // // B3: int length + duyet tu cuoi chuoi ve dau chuoi de dem 

        // #endregion

    }
}
