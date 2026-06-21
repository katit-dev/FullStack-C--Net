public class Program
{
    public static void Main(string[] args)
    {
        // bai tap voi list string
        //BaiTap.LengthOfStringList();


        // // bai tap: tinh tong cac so lon hon 50 trong danh sach
        // BaiTap.TongCaccSoLonHon50();
        // // bai tim so lon nhat trong danh sach
        // BaiTap.TimSoLonNhat();
        // // bai dem so phan tu lon hon 30 trong danh sach
        // BaiTap.DemSoPhanTuLonHon30();
        // // bai tinh trung binh cong cac so le
        // BaiTap.TrungBinhCongCacSoLe();
        // // bai in ra cac so chan trong danh sach
        // BaiTap.InRaCacSoChan();


        //  string input4 = BaiTap.NhapChuoiHeLop4();
        // int length = BaiTap.LengthOfWord(input4);
        // Console.WriteLine("Độ dài của từ cuối cùng: " + length);

        // goi ham hien thi
        // can co 1 con so va 1 ham hien thi
        //BaiTap.XuLyHienThi(7, BaiTap.HienThiKetQua);

        

        #region Collection
        /*
        danh sach hoc vien lop net 06

        them hoc vien: them ban 
        sua hoc vien: sua ban
        xoa hoc vien: xoa ban
        */
        #endregion

        #region kieu du lieu tap hop - Array
        // Mảng array: danh sach cac phan tu cung kieu du lieu, kich thuoc co dinh
        // truy xuat phần tử trong mảng thông qua chỉ số (index) bắt đầu từ 0
        // ds so người trong 5 lớp
        // int[] dsSoNguoiTrong5Lop = new int[5];
        // int[] dsSoNguoiTrong5Lop2 = { 20, 25, 30, 28, 22 };
        // // truy xuat phan tu trong mảng ~ giống với cách truy cập từng ký tự trong chuỗi
        // int soNguoiLop1 = dsSoNguoiTrong5Lop2[0]; // 20

        // Console.WriteLine("so người trong lớp 1 là " + soNguoiLop1);
        // Console.WriteLine("độ dài mảng dsSoNguoiTrongLop2 là " + dsSoNguoiTrong5Lop2.Length);
        // Console.WriteLine("Độ dài mảng dsSoNguoiTrongLop2 là " + dsSoNguoiTrong5Lop2.Count());

        // // thay đổi giá trị trong mảng
        // dsSoNguoiTrong5Lop2[0] = 21;
        // // duyệt mảng và in ra giá trị từng phần tử
        // for (int i = 0; i < dsSoNguoiTrong5Lop2.Length; i++)
        // {
        //     Console.WriteLine("Số người trong lớp " + (i + 1) + " là: " + dsSoNguoiTrong5Lop2[i]);
        // }

        // gán sai kiểu dữ liệu cho mảng
        // dsSoNguoiTrong5Lop2[0] = "abc"; // lỗi

        #endregion

        #region Kieu du lieu danh sach - List
        // Console.ForegroundColor = ConsoleColor.Magenta;
        // Console.WriteLine("List Section");
        // // List<T> : danh sach cac phan tu cung kieu du lieu, kich thuoc co the thay doi
        // // cú pháp: List<T> tenDanhSach = new List<T>();
        // // T: kiểu dữ liệu của phần tử trong danh sách
        // List<string> dsTenHocVien = new List<string>();

        // // ds ten cac tòa nhà chi nhánh cybersoft
        // List<string> dsToaNhaChiNhanhCybersoft = new List<string>()
        // {
        //     "Tòa nhà Cybersoft Nguyễn Xiển",
        //     "Tòa nhà Cybersoft Hồ Tùng Mậu",
        //     "Tòa nhà Cybersoft Lê Văn Lương"
        // };
        // // khai báo và khởi tạo giá trị cho danh sách

        // // CRUD: Create, Read, Update, Delete
        // //  Create - thêm phần tử vào danh sách
        // dsTenHocVien.Add("Nguyễn Văn A");
        // dsTenHocVien.Add("Trần Thị B");
        // dsTenHocVien.Add("Lê Văn C");
        // // THÊM NHIỀU PHẦN TỬ CÙNG LÚC
        // dsTenHocVien.AddRange("Phạm Thị D", "Hoàng Văn E");

        // // dung Insert để chèn phần tử vào vị trí bất kỳ
        // dsTenHocVien.Insert(1, "F"); // chèn "Đỗ Thị F" vào vị trí index 1
        // // chèn nhiều phần tử cùng lúc
        // dsTenHocVien.InsertRange(3, "G", "H");


        // // Update - cập nhật/ sửa phần tử trong danh sách
        // dsTenHocVien[0] = "Nguyễn Văn A - Cập nhật";

        // dsTenHocVien.Add("Lê Văn ");

        // // Delete - xóa phần tử trong danh sách
        // // dsTenHocVien.Remove("Lê Văn C"); // xóa phần tử có giá trị "Lê Văn C"
        // // dsTenHocVien.RemoveAt(1); // xóa phần tử tại vị trí index 2
        // // dsTenHocVien.RemoveRange(3, 4); // xóa 2 phần tử bắt đầu từ vị trí index 0
        // // xoa theo điều kiện
        // // dsTenHocVien.RemoveAll(ten => ten.Contains("Thị")); // xóa tất cả phần tử bắt đầu bằng chữ "H"  

        // //dsTenHocVien.Clear(); // xóa tất cả phần tử trong danh sách

        // // Read - đọc/ truy xuất phần tử trong danh sách
        // Console.WriteLine("Danh sách tên học viên:");
        // // foreach (string ten in dsTenHocVien)
        // // {
        // //     Console.WriteLine(ten);
        // // }

        // dsTenHocVien.ForEach(ten => Console.WriteLine(ten));
        // // in nhanh

        // // find - tìm kiếm phần tử trong danh sách
        // string? hocVienLê = dsTenHocVien.Find(ten => ten.StartsWith("Lê")); // tìm phần tử đầu tiên bắt đầu bằng "Lê"
        // Console.WriteLine("hoc vien dau tien ho Le trong danh sach " + hocVienLê);
        // Console.WriteLine("Học viên bắt đầu bằng 'Lê': " + hocVienLê);

        // List<string> dsHocVienBatDauBangLe = dsTenHocVien.FindAll(ten => ten.StartsWith("Lê")); // tìm tất cả phần tử bắt đầu bằng "Lê"
        // Console.WriteLine("Danh sách học viên bắt đầu bằng 'Lê':");
        // dsHocVienBatDauBangLe.ForEach(ten => Console.WriteLine(ten));




        // Console.ResetColor();
        #endregion

        
    }
}
