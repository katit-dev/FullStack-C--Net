// // See https://aka.ms/new-console-template for more information
// // Console.WriteLine("Hello, World!");



// // /*
// // == : so sanh bang vd: so1 == so2
// // != : so sanh khong bang vd: so1 != so2
// // >, >= so sanh lon hon, lon hon hoac bang vd: so1 > so2, so1 >= so2
// // <, <= so sanh nho hon, nho hon hoac bang vd: so1 < so2, so1 <= so2
// // */

// // int so1 = 10;
// // int so2 = 30;

// // // 10 = 30 ==> sai
// // bool ketqua = so1 == so2; // false
// // Console.WriteLine($"Ket qua cua so sanh so1 = so2 la {ketqua}");// tam thoi chi trar ra true/false

// // Console.WriteLine($"Ket qua cua {so1} > {so2} {so1 > so2}");// false
// // Console.WriteLine($"Ket qua cua {so1} < {so2} {so1 < so2}");// true
// // Console.WriteLine($"Ket qua cua {so1} >= {so2} {so1 >= so2}");// false
// // Console.WriteLine($"Ket qua cua {so1} <= {so2} {so1 <= so2}");// true
// // Console.WriteLine($"Ket qua cua {so1} != {so2} {so1 != so2}");// true


// // //---------------------------------------------------------------------------

// // // chuyen doi kieu du lieu
// // // lay du lieu tu input ban phim qua Console.ReadLine() --> trra ve kieu du lieu la string
// // // nguoi ta nhap so 123 ==> kieu du lieu string "123"
// // string chuoiSo = "123";
// // Console.WriteLine(chuoiSo + chuoiSo);
// // // ket qua se la "123123" vi phep cong nay la phep noi chuoi

// // /*
// // int : so nguyen thap hon long
// // long: so nguyen lon hon int
// // double: so thuc (rong hon so nguyen)
// // float: so thuc (nho hon double)
// // decimal: so thuc (chinh xac cao, dung trong tai chinh)
// // */

// // // 3 cach chuyen doi kieu du lieu
// // // Chuyen doi ngam dinh tu nho -> lon (ep kieu)
// // int soNguyenA = 40;
// // // chuyen soNguyenA tu int sang double
// // double soThucA = soNguyenA;
// // // double soThucA = (double)soNguyenA; 

// // // check kieu du lieu typeof, GetType()
// // Console.WriteLine("kieu du lieu cua soNguyen la: " + soNguyenA.GetType());
// // Console.WriteLine("kieu du lieu cu soThucA: " + soThucA.GetType());


// // // chuyen nguoc lai tu lon -> nho (double -> int)
// // double soThucB = 8.49;
// // // chuyen 8.49 (double) sang int
// // int soNguyenB = (int)soThucB; // mat phan thap pha, chi lay phan nguyen
// // Console.WriteLine($"KDL cua {soThucB} la: " + soThucB.GetType());
// // Console.WriteLine($"so nguyen B sau khi chuyen doi la {soNguyenB}");
// // Console.WriteLine($"KDL cua {soNguyenB} la: " + soNguyenB.GetType());

// // // De chuyen doi dung
// // // thu vien co san cua .NET
// // // Math: ho tro lam tron dung
// // Console.WriteLine($"lam tron {soThucB} thanh: " + Math.Round(soThucB)); 
// // Console.WriteLine(Math.Round(2.5));//2
// // Console.WriteLine(Math.Round(3.5));//4
// // Console.WriteLine(Math.Round(4.5));// 4
// // /*.Round thi co 1 so luu y
// // - .5 thi no se lam tron den so chan gan nhat
// // - .9 thi lam trong theo kieu banker la lam tron .lon hon 5 thi lam trong len
// //  be hon .5 thi lam tron xuong
// // */
// // Console.WriteLine(Math.Ceiling(soThucB));// lam tron len 9.0
// // Console.WriteLine(Math.Floor(soThucB));// lam tron xuong 8.0
// // var soNguyenC = (int) Math.Round(8.4999, MidpointRounding.AwayFromZero);
// // Console.WriteLine($"KDL cua {soNguyenC} la: " + soNguyenC.GetType());

// // // Chuyen doi kieu du lieu tu string --> int
// // // int.Parse() : neu chuyen doi duoc thi ok, khong duoc thi bao loi
// // // khi nao khong duoc: neu chuoi khong phai la so
// // // var soNuyenChuoiSo = (int)chuoiSo; // loi cannot convert 
// // int soNuyenChuoiSo = int.Parse(chuoiSo); // chuyen doi chuoi "123" sang so nguyen 123
// // Console.WriteLine($"KDL cua {soNuyenChuoiSo} la: " + soNuyenChuoiSo.GetType());

// // string chuoiChu = "mot hai ba";
// // // int soNguyenChuoiChu = int.Parse(chuoiChu); // loi neu chuoi khong phai la so

// // // chuyen an hon dung int.TryParse(): co gang chuyen doi
// // var chuyeDoi = int.TryParse(chuoiChu, out int soNguyenChuoiChu2);
// // // nhan duoc 2 thu: bien chuyeDoi (bool)  co kieu boolean
// // // va bien soNguyenChuoiChu2 (int) gia tri mac dinh 0 (default la 0)
// // Console.WriteLine($"Gia tri va Type cua bien chu soNguyenChuoiChu2 {soNguyenChuoiChu2} la: {soNguyenChuoiChu2.GetType()}. Ket qua cua chuyenDoi la {chuyeDoi}");


// // // chuyen doi kieu du lieu dung convert 
// // string chuoiSo2 = "456";
// // int soNguyenChuoiSo2 = Convert.ToInt32(chuoiSo2);
// // Console.WriteLine($"KDL cua {soNguyenChuoiSo2} la: " + soNguyenChuoiSo2.GetType());

// #region 
// // dung de gom nhom vung nhom khong duoc bien dich
// #endregion

// // // bai 1: chuyen doi do C sang do F
// // Console.Write("Nhập vào độ C: ");
// // double doC = double.Parse(Console.ReadLine());
// // double doF = (doC * 9 / 5) + 32;
// // Console.WriteLine($"{doC} do C = {doF} do F");

// // string strDoC = Console.ReadLine();
// // bool kiemtra = double.TryParse(strDoC, out double doC2);
// // var ketQua = doC2 * 9 / 5 + 32;
// // Console.WriteLine($"{doC2} do C = {ketQua} do F");

// // // bai 2: 
// // Console.Write("Nhap ban kinh cua hinh tron: ");
// // double banKinh = double.Parse(Console.ReadLine());
// // double chuVi = (2 * Math.PI * banKinh);
// // double dienTich = Math.PI * banKinh * banKinh;
// // Console.WriteLine($"Chu vi hinh tron la: {chuVi}");
// // Console.WriteLine($"Dien tich hinh tron la: {dienTich:N2}");

// // // bai 3:
// // Console.Write("Nhap can nang: ");
// // double canNang = double.Parse(Console.ReadLine());
// // Console.Write("Nhap chieu cao: ");
// // double chieuCao = double.Parse(Console.ReadLine());
// // double bmi = canNang / (chieuCao * chieuCao);
// // Console.WriteLine($"Chi so BMI cua ban la: {bmi:N2}");// N2: lam 2 so thap phan va co dau phay ngan cach hang nghin
// //                                                       // F2: lam 2 so thap phan khong co dau phay ngan cach hang nghin


// // // bai tap them 1
// // Console.Write("Nhap so ngay: ");
// // int soNgay = int.Parse(Console.ReadLine());
// // int soTuan = soNgay / 7;
// // int soNgayConLai = soNgay % 7;
// // Console.WriteLine($"{soNgay} ngay = {soTuan} tuan va {soNgayConLai} ngay");

// // // bai tap them 2
// // Console.Write("Nhap gia tri don hang: ");
// // double giaTriDonHang = double.Parse(Console.ReadLine());
// // Console.Write("Nhap phan tram giam gia: ");
// // double phanTramGiamGia = double.Parse(Console.ReadLine());
// // double soTienSauGiamGia = giaTriDonHang - (giaTriDonHang * phanTramGiamGia / 100);
// // Console.WriteLine($"So tien phai tra sau giam gia la: {soTienSauGiamGia:N2}");

// // -------------------------------------------------------------------------------------------------------
// #region Cau truc re nhanh
// // // dua ra quyet dinh dua tren dieu kien dung sai
// // // dieu kien dung --> thuc hien hanh dong A
// // // dieu kien sai --> thuc hien hanh dong B
// // // Toan tu so sanh
// // /*
// // Neu dieu kien dung thi thuc hien hanh dong A
// // Dieu kien se co dang la boolean
// // if(dung)
// // {
// //     // hanh dong A
// // }
// // else
// // {
// //     // hanh dong B
// // }
// // */
// // if(10 > 5) // co the chua dieu kien(10 > 5, so1 == so2, ...)
// // {
// //     Console.WriteLine("Dieu kien dung");
// // }else // neu dieu kien sai thi thuc hien else
// // {
// //     Console.WriteLine("Dieu kien sai");
// // }

// // var nhietDo = 26;
// // if(nhietDo < 25)
// // {
// //     Console.WriteLine("Khong bat may lanh");
// // }else
// // {
// //     Console.WriteLine("Bat may lanh");
// // }
// // Console.WriteLine("Chay tiep va bo qua phan con lai cua else");


// #endregion

// // bai tap kiem tra so chan le
// Console.Write("Nhap mot so nguyen: ");
// int soNguyenNhapVao = int.Parse(Console.ReadLine());
// if(soNguyenNhapVao % 2 == 0)
// {
//     Console.WriteLine($"{soNguyenNhapVao} la so chan");
// }
// else
// {
//     Console.WriteLine($"{soNguyenNhapVao} la so le");
// }

// // ! phu dinh
// // kiem tra = true => !kiemtra = false

// ---------------------------- buoi 2 phan 2
// Console.Write("Nhap so (1-4): ");
// Console.Write(@"Nhap so (1-4): 
// 1 - Nang
// 2 - Mua
// 3 - Lanh
// 4 - Tuyet
// ");

// int soNhapVao = int.Parse(Console.ReadLine());
// if(soNhapVao == 1)
// {
//     Console.WriteLine("Mac ao ba lo");
// }
// else if(soNhapVao == 2)
// {
//     Console.WriteLine("Mac ao mua");
// }
// else if(soNhapVao == 3)
// {
//     Console.WriteLine("Mac ao khoac");
// }
// else if(soNhapVao == 4)
// {
//     Console.WriteLine("Mac ao phao");
// }
// else
// {
//     Console.WriteLine("Hay chon so tu 1 den 4");
// }

// BT chon trang phục 

// input : con số
Console.WriteLine(@"Hãy nhập số theo tình hình thời tiết:
1. Nắng nóng\
2. Mưa
3. Lạnh
4. Tuyết
");
int.TryParse(Console.ReadLine(), out int tinhHinhThoiTiet);

if(tinhHinhThoiTiet == 1)
{
    Console.WriteLine("Áo thun, quần short, dép xăng đan");
}
else
{
    // có phải là 2 hay không
    if(tinhHinhThoiTiet == 2)
    {
        Console.WriteLine("áo mưa");
    }
    else
    {
        // có phải là 3 hay không 
        if(tinhHinhThoiTiet ==3)
        {
            Console.WriteLine("áo ấm");
        }
        else
        {
            if(tinhHinhThoiTiet == 4)
            {
                Console.WriteLine("áo phao");
            }
            else
            {
                Console.WriteLine("Hãy chọn số từ 1 đến 4");
            }
        }
        
    }
}