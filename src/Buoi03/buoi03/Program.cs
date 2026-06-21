// --  buoi 3

// BT van dung else if

/*
if(dieu kien 1)
{
    thuc thi dieu kien 1 dung}
}
else if(dieu kien 2)
{
    thuc thi khi dk1 sai va dieu kien 2 dung
}
else
{
    thuc thi khi  tat ca dieu kien deu sai
}
*/
// Neu cod thuc thi chi co 1 dong lenh thi co the viet tren 1 dong

// int so = 2;
// if (so == 1)  Console.WriteLine("ao mat");
// else if (so == 2) Console.WriteLine("quan dai");
// else Console.WriteLine("giay the thao");

// BT so 5
// input : nhap vao 1 so nguyen co 3 chu so
// process: tach ra tung chu so va cong lai
// output: in ra tong 3 chu so

// Console.Write("Nhap vao 1 so Nguyen co 3 chu so: ");
// int soNguyen = int.Parse(Console.ReadLine());

// if (soNguyen < 100 || soNguyen > 999)
// {
//     Console.WriteLine("So ban nhap khong phai la so co 3 chu so.");
// }
// else
// {//
//     int chuSoHangTram = soNguyen / 100;
//     int chuSoHangChuc = (soNguyen / 10) % 10;
//     int chuSoHangDonVi = soNguyen % 10;

//     Console.WriteLine("Chu so hang tram: " + chuSoHangTram);
//     Console.WriteLine("Chu so hang chuc: " + chuSoHangChuc);
//     Console.WriteLine("Chu so hang don vi: " + chuSoHangDonVi);
//     Console.WriteLine("Tong 3 chua so la: "+ (chuSoHangTram + chuSoHangChuc + chuSoHangDonVi));
// }

// // Cach 2: 
// Console.Write("Nhap vao 1 so Nguyen co 3 chu so: ");
// bool checkedNumber = int.TryParse(Console.ReadLine(), out int soNguyen2);



// Toan tu logic
/*
&& : AND (va)
|| : OR (hoac)
!  : NOT (phu dinh)
VD: troi mua + benh => o nha
    troi mua + khong benh => di hoc

*/

#region Switch Case
// Cau truc switch case
// khi nao dung switch case, khi nao dung if else?
// Dung switch case khi biet truoc so luong dieu kien can kiem tra


/*
switch (bienCanKiemTra)
{
    case giaTri1:
        // thuc thi khi bienCanKiemTra == giaTri1
        break;
    case giaTri2:
        // thuc thi khi bienCanKiemTra == giaTri2
        break;
    ...
    default:
        // thuc thi khi tat ca cac gia tri deu khong dung
        break;
}
*/
// VD: Nhap vao 1 so tu 1 den 7, in ra thu trong tuan
// Console.Write("Nhap vao 1 so tu 1 den 7: ");
// bool checkDay = int.TryParse(Console.ReadLine(), out int day);

// if (!checkDay)
// {
//     Console.WriteLine("Gia tri ban nhap khong hop le.");
// }
// else
// {
//     switch (day)
//     {
//         case 1:
//             Console.WriteLine("Chu Nhat");
//             break;
//         case 2:
//             Console.WriteLine("Thu Hai");
//             break;
//         case 3:
//             Console.WriteLine("Thu Ba");
//             break;
//         case 4:
//             Console.WriteLine("Thu Tu");
//             break;
//         case 5:
//             Console.WriteLine("Thu Nam");
//             break;
//         case 6:
//             Console.WriteLine("Thu Sau");
//             break;
//         case 7:
//         case 9: // co the dung nhieu case lien tiep nhau, 2 case nay deu in ra "Thu Bay"
//             Console.WriteLine("Thu Bay");
//             break;
//         default:
//             Console.WriteLine("So ban nhap khong phai tu 1 den 7.");
//             break;
//     }
// }

// // bai tap diem trung binh
// // >=8 la gioi
// // >=6.5 la kha
// // >=5 la trung binh
// // <5 la yeu


// double dtb = 6;
// string xeploai = "";
// switch (dtb)
// {
//     case >= 8 and <= 10:
//         xeploai = "Gioi";
//         break;
//     case >= 6.5 and < 8:
//         xeploai = "Kha";
//         break;
//     case >= 5 and < 6.5:
//         xeploai = "Trung binh";
//         break;
//     case < 5:
//         xeploai = "Yeu";
//         break;
//     default:
//         Console.WriteLine("Default case");
//         break;
// }
 #endregion

 #region  switch expession (C# 8.0 tro len)

// double dtb2 = 6;
// string xeploai2 = dtb switch
// {
//     >= 8 and <= 10 => "Gioi",
//     >= 6.5 and < 8 => "Kha",
//     >= 5 and < 6.5 => "Trung binh",
//     < 5 => "Yeu",
//     _ => "Khong hop le"
// };

// int so2 = 3;
// string ngay = so2 switch
// {
//     1 => "Chu Nhat",
//     2 => "Thu Hai",
//     3 => "Thu Ba",
//     4 => "Thu Tu",
//     5 => "Thu Nam",
//     6 => "Thu Sau",
//     7 => "Thu Bay",
//     _ => "So khong hop le"
// };

// Console.Write("Nhap diem mon Toan: ");
// bool checkDiemToan = double.TryParse(Console.ReadLine(), out double diemToan);
// Console.Write("Nhap diem mon Ly: ");
// bool checkDiemLy = double.TryParse(Console.ReadLine(), out double diemLy);
// Console.Write("Nhap diem mon Hoa: ");
// bool checkDiemHoa = double.TryParse(Console.ReadLine(), out double diemHoa);

// if(!checkDiemToan || !checkDiemLy || !checkDiemHoa)
// {
//     Console.WriteLine("Diem ban nhap khong hop le.");
// }
// else
// {
//     double diemTrungBinh = (diemToan + diemLy + diemHoa) / 3;
//     string xeploai = diemTrungBinh switch
//     {
//         >= 8 and <= 10 => "Gioi",
//         >= 6.5 and < 8 => "Kha",
//         >= 5 and < 6.5 => "Trung binh",
//         < 5            => "Yeu",
//         _              => "Khong hop le"
//     };

//     Console.WriteLine($"Diem trung binh: {diemTrungBinh:F2}, Xep loai: {xeploai}");
// }
#endregion

#region Toan tu 3 ngoi
// Cau truc toan tu 3 ngoi
// dieu kien ? gia tri neu dung : gia tri neu sai
// mo rong toan tu 3 ngoi
// bien = dieu kien1 ? gia tri neu dung : (dieu kien2 ? gia tri neu dung : gia tri neu sai)



#endregion

#region Toan tu null coalescing
// Cau truc toan tu null coalescing
// bien = gia tri1 ?? gia tri2

string ten = null;
string hienThiTen = ten ?? "chua co ten";
// neu ten == null thi hienThiTen = "chua co ten",
// nguoc lai hienThiTen = ten

Console.WriteLine($"Ten : {ten}");
Console.WriteLine($"Hien thi ten: {hienThiTen}");

// toan tu ??= : 
string soThich = null;
soThich ??= "chua co so thich";
// neu soThich == null thi gan gia tri "chua co so thich" cho soThich
Console.WriteLine($"So thich: {soThich}");

//--------------------------------------------so sanh ?? va ??=----------------------------
string email = null;

// ?? dùng để hiện thị
Console.WriteLine(email ?? "Chưa có email");
// --> ket qua: Chưa có email

// ??= dùng để gán giá trị
email ??= "abc@gmail.com";
Console.WriteLine($"email hien tai la: {email}");
// --> ket qua: email hien tai la: abc@gmail.com
#endregion



#region Kieu du lieu Nullable
// 
string? namSinh = Console.ReadLine();
string? a = null;
// string? bien nay co the nhan gia tri null
// nullable
#endregion