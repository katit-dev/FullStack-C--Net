public class QuanLyTrungTam
{
    // khai bao trung tam
    // Denpendency Injection
    private TrungTam trungTam;
    public QuanLyTrungTam(TrungTam trungTam)
    {
        this.trungTam = trungTam;
    }

    // method show menu
    public void ShowMenu()
    {
        int choice;
        do
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n===== MENU QUẢN =====");
            Console.WriteLine("1. Thêm nguời dùng");
            Console.WriteLine("2. Hiển thị danh sách nguời dùng");
            Console.WriteLine("3. Nạp sinh viên vào cho giảng viên");
            Console.WriteLine("4. Hiển thị danh sách học viên của Giảng viên");
            Console.WriteLine("5. Tìm kiếm nguời dùng theo mã");
            Console.WriteLine("6. Xóa nguời dùng");
            Console.WriteLine("7. Thoát");
            Console.WriteLine("=======================");
            choice = InputHandler.CheckIntInput("Please enter a number: ", 1, 7);
            Console.ResetColor();

            switch (choice)
            {
                case 1:
                    // them nguoi dung
                    ThemNguoiDung();
                    break;
                case 2:
                    // hien thi nguoi dung
                    HienThiNguoiDung();
                    break;
                case 3:
                    // nap sinh vien vao giang vien
                    NapSinhVienVaoGiangVien();
                    break;
                case 4:
                    // hien thi danh sach hoc vien cua giang vien
                    HienThiDanhSachHocVienCuaGiangVien();
                    break;
                case 5:
                    // tim kiem nguoi dung theo ma
                    TimKiemNguoiDungTheoMa();
                    break;
                case 6:
                    // xoa nguoi dung
                    XoaNguoiDung();
                    break;
                case 7:
                    Console.WriteLine("Thoát chương trình. Tạm biệt!");
                    return; // thoát khỏi phương thức ShowMenu
            }
        } while (true);
    }


    // ---------------------------------------------------
    // ---------------------------------------------------  
    // ---------------------------------------------------

    // method xoa nguoi dung
    public void XoaNguoiDung()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        string? ma = InputHandler.CheckStringInput("Nhập mã người dùng cần xóa");
        Console.ResetColor();
        NguoiDung? nguoiDung = TimKiemNguoiDungTheoMa(ma);
        if (nguoiDung != null)
        {
            trungTam.GetNguoiDungs().Remove(nguoiDung);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nĐã xóa người dùng có mã {ma}.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Không tìm thấy người dùng với mã đã nhập.");
            Console.ResetColor();
        }
    }

    // method tim kiem nguoi dung theo ma
    public void TimKiemNguoiDungTheoMa()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        string? ma = InputHandler.CheckStringInput("Nhập mã người dùng cần tìm");
        Console.ResetColor();

        NguoiDung? nguoiDung = TimKiemNguoiDungTheoMa(ma);
        if (nguoiDung != null)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nThông tin người dùng:");
            nguoiDung.HienThiThongTin();
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Không tìm thấy người dùng với mã đã nhập.");
            Console.ResetColor();
        }

    }

    // method tim kiem nguoi dung theo ma va tra ve nguoi dung
    // helper
    public NguoiDung? TimKiemNguoiDungTheoMa(string ma)
    {
        NguoiDung? nguoiDung = trungTam.GetNguoiDungs().Find(x => x.Ma.ToLower() == ma.ToLower());
        if (nguoiDung == null)
        {
           return null;
        }
        return nguoiDung;
    }


    // method hien thi danh sach hoc vien cua giang vien
    public void HienThiDanhSachHocVienCuaGiangVien()
    {
        // hien thi danh sach giang vien
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Danh sach các giảng viên: ");
        Console.ResetColor();
        trungTam.HienThiNguoiDungTheoLoai<GiangVien>();

        // chon giang vien
        Console.ForegroundColor = ConsoleColor.Cyan;
        string maGiangVien = InputHandler.CheckStringInput("Nhập mã giảng viên: ");
        Console.ResetColor();

        // tim kiem giang vien theo ma
        NguoiDung? giangVien = TimKiemNguoiDungTheoMa(maGiangVien);

        if (giangVien != null && giangVien is GiangVien gv)
        {
            if (gv.DanhSachSinhVien.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Giảng viên này chưa có học viên nào.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Danh sách học viên của giảng viên {gv.Ten}:");
                foreach (var sinhVien in gv.DanhSachSinhVien)
                {
                    sinhVien.HienThiThongTin();
                }
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Không tìm thấy giảng viên với mã đã nhập.");
            Console.ResetColor();
        }
    }

    // method nap sinh vien vao giang vien
    public void NapSinhVienVaoGiangVien()
    {
        // hien thi danh sach giang vien
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Danh sach các giảng viên: ");
        Console.ResetColor();
        trungTam.HienThiNguoiDungTheoLoai<GiangVien>();

        // chon giang vien
        string maGiangVien = InputHandler.CheckStringInput("\nNhập mã giảng viên: ");


        // tim kiem giang vien theo ma
        NguoiDung? giangVien = TimKiemNguoiDungTheoMa(maGiangVien);

        if (giangVien != null && giangVien is GiangVien gv)
        {

            // hien thi danh sach sinh vien
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nDanh sach các sinh viên cua {gv.Ten}: ");
            Console.ResetColor();
            trungTam.HienThiNguoiDungTheoLoai<SinhVien>();

            // chon sinh vien
            Console.ForegroundColor = ConsoleColor.Cyan;
            string maSinhVien = InputHandler.CheckStringInput("\nNhập mã sinh viên: ");
            Console.ResetColor();
            // tim kiem sinh vien theo ma
            NguoiDung? sinhVien = TimKiemNguoiDungTheoMa(maSinhVien);
            if (sinhVien != null && sinhVien is SinhVien sv)
            {
                // nap sinh vien vao giang vien
                gv.DanhSachSinhVien.Add(sv);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Đã nạp sinh viên {sv.Ten} vào giảng viên {gv.Ten}.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Không tìm thấy sinh viên với mã đã nhập.");
                Console.ResetColor();
            }
        }else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Không tìm thấy giảng viên với mã đã nhập.");
            Console.ResetColor();
        }

    }

    // method hien thi nguoi dung
    public void HienThiNguoiDung()
    {
        List<NguoiDung> nguoiDungs = trungTam.GetNguoiDungs();
        if (nguoiDungs.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Danh sách người dùng trống.");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n===== DANH SÁCH GIẢNG VIÊN =====");
        Console.ResetColor();
        trungTam.HienThiNguoiDungTheoLoai<GiangVien>();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n===== DANH SÁCH MENTOR =====");
        Console.ResetColor();
        trungTam.HienThiNguoiDungTheoLoai<Mentor>();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n===== DANH SÁCH SINH VIÊN =====");
        Console.ResetColor();
        trungTam.HienThiNguoiDungTheoLoai<SinhVien>();
    }


    // method them hoc vien
    public void ThemNguoiDung()
    {
        // choose type of user
        Console.WriteLine(@"Enter type of user:
        1. Sinh viên
        2. Mentor
        3. Giảng viên");
        int userType = InputHandler.CheckIntInput("", 1, 3);

        // switch case
        switch (userType)
        {
            case 1:
                //nhap thong tin nguoi dung
                NguoiDung sinhVien = new SinhVien();
                sinhVien.NhapThongTin();
                // them nguoi dung
                trungTam.GetNguoiDungs().Add(sinhVien);
                // in thong bao
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Thêm sinh viên thành công!");
                Console.ResetColor();

                break;
            case 2:
                Mentor mentor = new Mentor();
                mentor.NhapThongTin();
                trungTam.GetNguoiDungs().Add(mentor);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Thêm mentor thành công!");
                Console.ResetColor();
                break;
            case 3:
                GiangVien giangVien = new GiangVien();
                giangVien.NhapThongTin();
                trungTam.GetNguoiDungs().Add(giangVien);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Thêm giảng viên thành công!");
                Console.ResetColor();
                break;
            case 4:
                Console.WriteLine("Thoát chương trình. Tạm biệt!");
                return; // thoát khỏi phương thức ShowMenu
        }

    }

}