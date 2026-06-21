public class BaiTap
{

    #region Ham co ban
    // Ham nhap vao diem 3 mon 
    // in ra diem trung binh va hoc luc
    // public static void BT_DiemTrungBinh()
    // {
    //     double toan, ly, hoa;
    //     toan = NhapDiem("Toan");
    //     ly = NhapDiem("Ly");
    //     hoa = NhapDiem("Hoa");
    //     double dtb = TinhDiemTrungBinh(toan, ly, hoa);
    //     Console.WriteLine("diem trung binh la " + dtb);
    //     XepLoai(dtb);
    // }

    // // Ham de nhap diem
    // public static double NhapDiem(string monHoc)
    // {
    //     double diem;
    //     while (true)
    //     {
    //         Console.WriteLine("Hay nhap diem mon " + monHoc);
    //         bool checkDouble = double.TryParse(Console.ReadLine(), out diem);
    //         if(checkDouble && diem > 0 && diem <= 10)
    //         {
    //             return diem;
    //         }
    //         Console.WriteLine("Diem khong hop le. vui long nhap lai!");
    //     }

    // }
    // // Ham tinh diem trung binh
    // public static double TinhDiemTrungBinh(double toan, double ly, double hoa)
    // => (toan + ly + hoa)/3;

    // // Ham xep loai dua tren diem trung binh
    // public static void XepLoai(double diemTB)
    // {
    //      if (diemTB >= 8)
    //     {
    //         Console.WriteLine("Hoc luc Gioi");
    //     }
    //     else if (diemTB >= 6.5)
    //     {
    //         Console.WriteLine("Hoc luc Kha");
    //     }
    //     else if (diemTB >= 5)
    //     {
    //         Console.WriteLine("Hoc luc Trung Binh");
    //     }
    //     else
    //     {
    //         Console.WriteLine("Hoc luc Yeu");
    //     }
    // }
    #endregion

    /// <summary>
    /// /////////////////////------------------------------------------Luyen Tap Lamda Expression------------------------------/////////////////////
    /// </summary>

    #region Lamda Expression
//     public static void BT_DiemTrungBinh2()
//     {
//         double toan, ly, hoa;
//         toan = NhapDiem2("Toan");
//         ly = NhapDiem2("Ly");
//         hoa = NhapDiem2("Hoa");
//         double dtb = tinhDiemTrungBinh(toan, ly, hoa);
//         Console.WriteLine("diem trung binh la " + dtb);
//         xepLoai2(dtb);
//     }

//     // Ham de nhap diem
//     public static double NhapDiem2(string monHoc)
//     {
//         double diem;
//         while (true)
//         {
//             Console.WriteLine("Hay nhap diem mon " + monHoc);
//             bool checkDouble = double.TryParse(Console.ReadLine(), out diem);
//             if (checkDouble && diem > 0 && diem <= 10)
//             {
//                 return diem;
//             }
//             Console.WriteLine("Diem khong hop le. vui long nhap lai!");
//         }

//     }

//     // tinh diem trung binh
//     static Func<double, double, double, double> tinhDiemTrungBinh = (a, b, c) => (a + b + c) / 3;

//     // xep loai
//     // C1:
//    static Action<double> xepLoai1 = x =>
//     {
//       if (x >= 8)
//         {
//             Console.WriteLine("Gioi");
//         }  else if(x >= 6.5)
//         {
//             Console.WriteLine("Kha");
//         }else if(x >= 5)
//         {
//             Console.WriteLine("Trung Binh");
//         }else
//         {
//             Console.WriteLine("Yeu");
//         }
//     };

//     // C2:
//     static Action<double> xepLoai2 = x =>
//     Console.WriteLine( x >= 8 ? "Gioi" : x >= 6.5 ? "Kha" : x >= 5 ? "Trung Binh" : "Yeu");
        
//     // C3: 
//     Func<double, string> xepLoai3 = x =>
//     x >= 8 ? "Gioi" : x >= 6.5 ? "Kha" : x >= 5 ? "Trung Binh" : "Yeu";

//     // C4:
//     Func<double, string> xepLoai4 = x =>
//     {
//         if (x >= 8)
//         {
//             return "Gioi";
//         }
//         else if (x >= 6.5)
//         {
//             return "Kha";
//         }
//         else if (x >= 5)
//         {
//             return "Trung Binh";
//         }
//         else
//         {
//             return "Yeu";
//         }
//     };

//     // c5:
//     static Action<double> xepLoai5 = x =>
//     {
//         string hocLuc = x >= 8 ? "Gioi" : x >= 6.5 ? "Kha" : x >= 5 ? "Trung Binh" : "Yeu";
//         Console.WriteLine(hocLuc);
//     };


    #endregion


}