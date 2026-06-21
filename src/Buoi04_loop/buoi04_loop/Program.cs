// See https://aka.ms/new-console-template for more information




//-------------Bai tap ---------------------
// bai tap 1: nhap n va in ra  tong tu 1 den n
// kiem tra n co phai so nguyen khong, neu khong phai so nguyen thi yeu cau nhap lai
// while (true)
// {
//     Console.Write("Nhap so nguyen duong : ");
//     bool isInt = int.TryParse(Console.ReadLine(), out int n);
//     if(!isInt || n < 1)
//     {
//         Console.Write("Nhap khong hop le!");
//         continue;// continue de quay ve dau vong lap va khong thuc hien cac cau lenh ben duoi
//     }
//     int sum = 0;
//     for(int i = 1; i <= n; i++)
//     {
//         sum += i;
//     }
//     Console.WriteLine($"Tong tu 1 den {n} la: {sum}");
//     break; // thoat vong lap
// }

// // bai tap 2 : nhap n va in ra tong 2 + 4 + ...2n
// while (true)
// {
//    Console.Write("Nhap vao so nguyen duong: ");
//    bool isInt2 = int.TryParse(Console.ReadLine(), out int input);
//    if(!isInt2 || input < 1)
//     {
//         Console.WriteLine("Nhap khong hop le!");
//         continue;
//     } 

//     int sum = 0;
//     for (int i = 1; i <= input; i++)
//     {
//         sum += 2 * i;
//     }
//     Console.WriteLine($"Tong 2 + 4 + ... + {2 * input} la: {sum}");
//     break;
// }

// // bai tap 3: nhap n va in ra giai thua cua n
// while (true)
// {
//     Console.Write("Nhap vao so nguyen duong: ");
//     bool isInt3 = int.TryParse(Console.ReadLine(), out int input3);
//     if(!isInt3 || input3 < 1)
//     {
//         Console.WriteLine("Nhap khong hop le!");
//         continue;
//     } 

//     int giaiThua = 1;
//     for (int i = 1; i <= input3; i++)
//     {
//         giaiThua *= i;
//     }
//     Console.WriteLine($"Giai thua cua {input3} la: {giaiThua}");
//     break;
// }


// chay tu 0 -> 10 va ket thuc
// Console.WriteLine("bat dau dem nguoc");
// for (int i = 10; i >= 0; i--)
// {
//     Console.WriteLine(i);
//     Thread.Sleep(1000); // dung chuong trinh 1 giay
// }
// Console.WriteLine("ket thuc dem nguoc");


// khoi tao bien; thuong la bien de dem i, j, k
// b1 khoi tao bien dem: chay 1 lan dau tien
// b2 kiem tra dieu kien: i <= 3
// b3 than vong lap: in ra dong chu
// b4 buoc lap: i++ => i = 2
// lap lai b2, b3, b4 den khi dieu kien sai thi dung vong lap

// var tenDoanhNghiep = "CyberSoft";
// for (int i = 1; i <= 3; i = i + 1)
// {
//     Console.WriteLine($"{i} Hello {tenDoanhNghiep}");
// }

// /* cac yeu to  tao nen vong lap
// - bien dem : i = 1
// - dieu kien : i<=3
// - than vong lap: xu ly neu dieu kien dung
// - buoc lap: thay doi gia tri bien dem de tranh vo han
// */

// // toan tu tang giam
// // hậu tố
// var number = 10;
// // number++; // number = number + 1
// // number--; // number = number - 1
// // ++number; // tang truoc
// // --number; // giam truoc
// var result = number++; // ++ dung truoc, tang sau
// var result2 = number--; // -- dung sau, giam sau
// Console.WriteLine("Result: " + result);
// Console.WriteLine("Number: " + number);

// Console.WriteLine("Result2: " + result2);
// Console.WriteLine("Number: " + number);

// // tiền tố
// var soTien = 1000;
// var soDu = --soTien; // giam truoc, dung sau
// var soDu2 = ++soTien; // tang truoc, dung sau
// Console.WriteLine("So du: " + soDu);
// Console.WriteLine("so du 2: " + soDu2);

// int a = 126;
// int b = a++; // b = 126, a = 127
// a--; // a = 126
// a+= 10;     // a = 136
// --a; // a = 135
// // b = 
// // a = 

// #region tinh tong cac so tu 1 den 100
// int tong = 0;
// for(int i = 1; i <= 100; i++)
// {
//     tong += i; // tong = tong + i
// }
// Console.WriteLine("Tong tu 1 den 100 la : " + tong);
// #endregion


// // while 
// /*
// cú pháp
// B1: khoi tao bien dem

// while(dieu kien)// B2: kiem tra dieu kien
// {
// // B3: khoi lenh duoc thuc thi trong moi vong lap - than vong lap

// // B4: buoc lap - thay doi gia trij bien dem
// }
// */
// int biendem = 1;
// int tong2 = 0;
// while(biendem <= 100)
// {
//     tong2 += biendem;
//     biendem++;
// }
// Console.WriteLine("Tong2 = " + tong2);

// bai tap 2 : nhap n va in ra tong 2 + 4 + ...2n
// while (true)
// {
//    Console.Write("Nhap vao so nguyen duong: ");
//    bool isInt2 = int.TryParse(Console.ReadLine(), out int input);
//    if(!isInt2 || input < 1)
//     {
//         Console.WriteLine("Nhap khong hop le!");
//         continue;
//     } 

//     int sum = 0;
//     for (int i = 1; i <= input; i++)
//     {
//         sum += 2 * i;
//     }
//     Console.WriteLine($"Tong 2 + 4 + ... + {2 * input} la: {sum}");
//     break;
// }



// // do while
// // chạy thân vong lap it nhat 1 lan
// // ví dụ: nhập mât khẩu
// // do
// // {
// //     // thuc hiện thân vòng lặp
// // } while (điều kiện);

// string matKhau = "";
// do
// {
//     Console.Write("Nhap mat khau: ");
//     matKhau = Console.ReadLine();

//     if (matKhau != "123456")
//     {
//         Console.ForegroundColor = ConsoleColor.Yellow;
//         Console.WriteLine("Mat khau khong dung, vui long thu lai!");
//         Console.ResetColor();
//     }
// } while (matKhau != "123456"); // neu mat khau khac 123456 thi yeu cau nhap lai
// Console.ForegroundColor = ConsoleColor.Red;
// Console.WriteLine("Đăng nhập thành công!");
// Console.ResetColor();

// bai tap 4: nhap so n va in ra tong binh phuong cua cac so tu 1 den n
// while (true)
// {
//    Console.Write("Nhap vao so nguyen duong: ");
//    bool isInt2 = int.TryParse(Console.ReadLine(), out int input);
//    if(!isInt2 || input < 1)
//     {
//         Console.WriteLine("Nhap khong hop le!");
//         continue;
//     } 

//     int sum = 0;
//     for (int i = 1; i <= input; i++)
//     {
//         sum += i * i;
//     }
//     Console.WriteLine($"Tong binh phuong cua cac so tu 1 den {input} la: {sum}");
//     break;
// }

// // bai tap 5 : nhap n va cho biet n co phai so nguyen to khong
// while (true)
// {
//    Console.Write("Nhap vao so nguyen duong: ");
//    bool isInt2 = int.TryParse(Console.ReadLine(), out int input);
//    if(!isInt2 || input < 1)
//     {
//         Console.WriteLine("Nhap khong hop le!");
//         continue;
//     } 

//     bool isPrime = true;
//     for (int i = 2; i <= Math.Sqrt(input); i++)
//     {
//         if (input % i == 0)
//         {
//             isPrime = false;
//             break;
//         }
//     }
//     if (isPrime && input != 1)
//     {
//         Console.WriteLine($"{input} la so nguyen to.");
//     }
//     else
//     {
//         Console.WriteLine($"{input} khong phai la so nguyen to.");
//     }
//     break;
// }

// bai 4 dung do while
// int soB4;
// bool isIntB4;
// do
// {
//    Console.Write("Nhap vao so nguyen duong: ");
//    isIntB4 = int.TryParse(Console.ReadLine(), out soB4);
//    Console.WriteLine("Nhap khong hop le");


// } while (!isIntB4 || soB4 < 1);

#region xử lý chuỗi
// string chuoi = "Tháng một";
// // từng ký tự sẽ dược đánh số từ 0 trở đi
// // được tạo thành từ nhiều ký tự char
// // T H á n g   m ộ t
// // lay ra 1 ky tu
// Console.WriteLine(chuoi[0]);
// // lay ky tu cuoi cung
// Console.WriteLine(chuoi[chuoi.Length - 1]);

// Console.WriteLine("_________________________________________");
// // chay vong lap qua tung ky tu trong chuoi
// string ketQua = "";
// for (int i = 0; i < chuoi.Length; i++)
// {
//     ketQua += chuoi[i] + " ";
// }    
// Console.WriteLine(ketQua);

// bai tap: nhap vao 1 chuoi va in ra chuoi dao nguoc
// Console.Write("Nhap vao 1 chuoi: ");
// string? inputChuoi = Console.ReadLine();
// string chuoiDaoNguoc = "";
// for (int i = inputChuoi.Length -1; i >=0; i--)
// {
//     chuoiDaoNguoc += inputChuoi[i];
// }
// Console.WriteLine("Chuoi dao nguoc la: " + chuoiDaoNguoc);

// string chuoiDaoNguoc = "";
// do
// {
//     Console.Write("Nhap vao 1 chuoi: ");
//     chuoiDaoNguoc = Console.ReadLine();
// } while (string.IsNullOrEmpty(chuoiDaoNguoc));
// for (int i = chuoiDaoNguoc.Length - 1; i >= 0; i--)
// {
//     Console.Write(chuoiDaoNguoc[i]);
// }
// #endregion

// // foreach : cũng là vòng lặp nhưng chuyên dùng để duyệt qua các tập hợp (array, list, ...)
// // không có biến đếm
// var ketQuaForeach = "";
// foreach (char c in chuoiDaoNguoc)
// {
//     if(c == ' ')
//     {
//         // return ; // ket thuc chuong trinh
//         // break; // thoat vong lap
//         continue; // bo qua lan lap nay va tiep tuc vong lap
//     }
//     ketQuaForeach = c + ketQuaForeach;
// }// trong () cần biết duyệt qua tập hợp nào
// Console.WriteLine("\nChuoi dao nguoc dung foreach: " + ketQuaForeach);

#endregion
#region reindex
// // reindex : tái chỉ mục
// bai tap dao nguoc chuoi dung reindex
/*
reindex
vd: string chuoi = 'thang';
muon lay 'g' thi dung chuoi[^1]
                'a' thi dung chuoi[^2]
                'h' thi dung chuoi[^3]
                'n' thi dung chuoi[^4]
                't' thi dung chuoi[^5]            
*/
//  string chuoiDaoNguoc = "";
//     string chuoi2;
// do
// {
//     Console.Write("Nhap vao 1 chuoi: ");
//     chuoi2 = Console.ReadLine();
// } while (string.IsNullOrEmpty(chuoi2));
// for (int i = 1; i < chuoi2.Length; i++)
// {
//     chuoiDaoNguoc += chuoi2[^i];
// }
// Console.WriteLine("Chuoi dao nguoc la: " + chuoiDaoNguoc);
#endregion

#region bai tap chuoi dao nguoc
// nhap 1 chuoi va in ra chuoi dao nguoc dung reindex
// string chuoiNhap;
// string chuoiDaoNguoc2 = "";
// // xử lý nếu nhập chuỗi rỗng thì yêu cầu nhập lại
// do
// {
//     Console.Write("Nhap vao 1 chuoi: ");
//     chuoiNhap = Console.ReadLine();    
// } while (string.IsNullOrEmpty(chuoiNhap));
// // thực hiện đảo ngược chuỗi sử dụng reindex
// for(int i = 1; i <= chuoiNhap.Length; i++)
// {
//     chuoiDaoNguoc2 += chuoiNhap[^i];
// }
// Console.WriteLine($"Chuoi dao nguoc của '{chuoiNhap}' là: {chuoiDaoNguoc2}");

// // bai tap : kiem tra chuoi nhap vao co đối xứng không
// string chuoiCanKiemTra;
// // xu ly neu chuoi rong thi yeu cau nhap lai
// do
// {
//     Console.WriteLine("Nhap vao 1 chuoi de kiem tra co đối xứng không: ");
//     chuoiCanKiemTra = Console.ReadLine();
// } while (string.IsNullOrEmpty(chuoiCanKiemTra));
// // kiem tra doi xung
// bool doiXung = true;
// for (int i = 0; i < chuoiCanKiemTra.Length / 2; i++)
// {
//     if(chuoiCanKiemTra[i] != chuoiCanKiemTra[^(i + 1)])
//     {
//         doiXung = false;
//         break;
//     }
// }
// // in ket qua
// if(doiXung)
// {
//     Console.WriteLine($"Chuoi '{chuoiCanKiemTra}' la chuoi doi xung");
// }
// else
// {
//     Console.WriteLine($"Chuoi '{chuoiCanKiemTra}' khong phai chuoi doi xung");
// }

// bai tap : dem so luong tu trong cau 
// nhap vao cau
// string cauNhap;
// do
// {
//     Console.Write("Nhap vao 1 cau: ");
//     cauNhap = Console.ReadLine();
// } while (string.IsNullOrEmpty(cauNhap));
// // dem so luong tu
// int soLuongTu = 0;
// bool trongTu = true; // bien kiem tra dang o trong tu hay ngoai tu
// for (int i = 0; i < cauNhap.Length; i++)
// {
//     if(cauNhap[i] == ' ')
//     {
//         // neu dang o trong tu thi bo qua
//         if(trongTu)
//         {
//             continue;
//         }
//         // neu dang o ngoai tu thi tang so luong tu len 1
//         soLuongTu++;
//         trongTu = true; // chuyen ve trang thai dang o trong tu
//     }
//     else
//     {
//         // neu la ky tu khac khoang trang thi dang o ngoai tu
//         trongTu = false;
//     }
// }
// // neu cau khong ket thuc bang khoang trang thi tang so luong tu len 1
// if(!trongTu)
// {
//     soLuongTu++;
// }
// Console.WriteLine($"So luong tu trong cau la: {soLuongTu}");

#endregion

#region bai tap vong lap long nha
// nhap vao so dong va so cot de in ra hinh chu nhat sao
// int soDong, soCot;
// do
// {
//     Console.Write("Nhap vao so dong: ");
//     soDong = int.Parse(Console.ReadLine());
//     Console.Write("Nhap vao so cot: ");
//     soCot = int.Parse(Console.ReadLine());
// } while (soDong < 0 || soCot < 0);
// for (int i = 1; i <= soDong; i++)
// {
//     for (int j = 1; j <= soCot; j++)
//     {
//         Console.Write("* ");
//     }
//     Console.WriteLine();
// }

// // nhap vao so nguyen n va in ra tam giac vuong tuong ung
// int n;
// do
// {
//     Console.Write("Nhap vao so nguyen duong n: ");
//     n = int.Parse(Console.ReadLine());
//     Console.ForegroundColor = ConsoleColor.Red;
//     Console.WriteLine("vui long nhap so nguyen duong!");
//     Console.ResetColor();
// } while (n < 1);
// for (int i = 1; i <= n; i++)
// {
//     for (int j = 1; j <= i; j++)
//     {
//         Console.Write("* ");
//     }
//     Console.WriteLine();
// }

// // nhap vao so nguyen n va in ra tam giac can tuong ung
// int n;
// bool isInt;
// do
// {
//     Console.Write("Nhap vao so nguyen duong n: ");
//     isInt = int.TryParse(Console.ReadLine(), out n);
//     if (!isInt || n < 1)
//     {
//         Console.ForegroundColor = ConsoleColor.Red;
//         Console.WriteLine("Nhap khong hop le, vui long thu lai!");
//         Console.ResetColor();
//     }
// } while (!isInt || n < 1);
// for (int i = 1; i <= n; i++)
// {
//     // in khoang trang
//     for (int j = 1; j <= n - i; j++)
//     {
//         Console.Write("  ");
//     }
//     // in sao
//     for (int k = 1; k <= 2 * i - 1; k++)
//     {
//         Console.Write("* ");
//     }
//     Console.WriteLine();
// }

#endregion

#region 

#endregion


#region giai bai tap in ra *
// int dong, cot;
// while (true)
// {
//     Console.Write("Nhap vao so dong: ");
//     bool isIntDong = int.TryParse(Console.ReadLine(), out dong);
//     if (isIntDong)
//     {
//         break;
//     }
//     Console.WriteLine("Vui long nhap so nguyen hop le ch so dong");
// }

// while (true)
// {
//     Console.Write("Nhap vao so cot: ");
//     bool isIntCot = int.TryParse(Console.ReadLine(), out cot);
//     if (isIntCot)
//     {
//         break;
//     }
//     Console.WriteLine("Vui long nhap so nguyen hop le cho so cot");
// }

// // in ra dong
// for (int i = 1; i <= dong; i++)
// {
//     // in ra cot
//     for (int j = 1; j <= cot; j++)
//     {
//         Console.Write("* ");
//     }
//     Console.WriteLine();
// }
#endregion


#region bai tap tong hop
// bai 1: nhap vao 1 so nguyen n va in ra bang cuu chuong n

//     int n;
//     bool isInt;
//     do
//     {
//         Console.Write("Nhap vao so nguyen duong n: ");
//         isInt = int.TryParse(Console.ReadLine(), out n);
//         if(!isInt || n < 1)
//         {
//             Console.ForegroundColor = ConsoleColor.Red;
//             Console.WriteLine("Nhap khong hop le, vui long thu lai!");
//             Console.ResetColor();
//         }
//     } while (n < 1);
//     for (int i = 1; i <= 10; i++)
//     {
//         Console.WriteLine($"{n} x {i} = {n * i}");
//     }

// // Bai tap 2: tim so nguyen to tu 1 den n
int soN;
bool isInt;
do
{
    Console.Write("Nhap vao so nguyen duong n: ");
    isInt = int.TryParse(Console.ReadLine(), out soN);
    if (!isInt || soN < 1)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Nhap khong hop le, vui long thu lai!");
        Console.ResetColor();
    }
} while (soN < 1);
// tim so nguyen to
Console.WriteLine($"Cac so nguyen to tu 1 den {soN} la: ");
for (int i = 2; i <= soN; i++)
{
    bool isPrime = true;
    for (int j = 2; j <= Math.Sqrt(i); j++)
    {
        if (i % j == 0)
        {
            isPrime = false;
            break;
        }
    }
    if (isPrime)
    {
        Console.Write(i + " ");
    }
}
Console.WriteLine();

// // bai tap 3: dao nguoc chuoi
// string chuoiNhap;
// string chuoiDaoNguoc2 = "";
// // xử lý nếu nhập chuỗi rỗng thì yêu cầu nhập lại
// do
// {
//     Console.Write("Nhap vao 1 chuoi: ");
//     chuoiNhap = Console.ReadLine();    
// } while (string.IsNullOrEmpty(chuoiNhap));
// // thực hiện đảo ngược chuỗi sử dụng reindex
// for(int i = 1; i <= chuoiNhap.Length; i++)
// {
//     chuoiDaoNguoc2 += chuoiNhap[^i];
// }
// Console.WriteLine($"Chuoi dao nguoc của '{chuoiNhap}' là: {chuoiDaoNguoc2}");


#endregion
