class QuanLyTrungTam
{
    // khai bao trung tam
    TrungTam trungTam = new TrungTam();

    // viet menu
    public void HienThiMenu()
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
            Console.Write("Vui lòng chọn chức năng (1-7): ");
            Console.ResetColor();

            choice = InputHandler.NhapSoNguyen("Chọn chức năng", 1, 7);
            switch (choice)
            {
                case 1:
                    ThemNguoiDung();
                    break;
                case 2:
                    HienThiDanhSachNguoiDung();
                    break;
                case 3:
                    NapSinhVienChoGiangVien();
                    break;
                case 4:
                    HienThiDanhSachHocVienCuaGiangVien();
                    break;
                case 5:
                    TimKiemNguoiDungTheoMa();
                    break;
                case 6:
                    XoaNguoiDung();
                    break;
                case 7:
                    Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình. Tạm biệt!");
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    Console.ResetColor();
                    break;
            }
        } while (true); // Vòng lặp vô hạn, sẽ thoát khi chọn 7
    }


    // Them nguoi dung
    public void ThemNguoiDung()
    {
        // hien thi title
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("1. Thêm người dùng");
        Console.ResetColor();

        // nhap loai nguoi dung
        Console.WriteLine(@"Nhap loai nguoi dung: 
        1. Them Sinh Vien
        2. Them Mentor
        3. Them Giang vien");
        int loaiNguoiDung = InputHandler.NhapSoNguyen("", 1, 3);


        // them nguoi dung vao danh sach
        switch (loaiNguoiDung)
        {
            case 1:
                NguoiDung sinhVien = new SinhVien();
                sinhVien.NhapThongTin();
                trungTam.ThemNguoiDung(sinhVien);
                // in thong bao
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Thêm học viên thành công!");
                Console.ResetColor();
                break;
            case 2:
                NguoiDung mentor = new Mentor();
                mentor.NhapThongTin();
                trungTam.ThemNguoiDung(mentor);
                // in thong bao
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Thêm mentor thành công!");
                Console.ResetColor();
                break;
            case 3:
                NguoiDung giangVien = new GiangVien();
                giangVien.NhapThongTin();
                trungTam.ThemNguoiDung(giangVien);
                // in thong bao
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Thêm giảng viên thành công!");
                Console.ResetColor();
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                Console.ResetColor();
                break;
        }


    }

    // Hien thi danh sach nguoi dung
    public void HienThiDanhSachNguoiDung()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Danh sách giảng viên:");
        trungTam.HienThiGiangVien();
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Danh sách mentor:");
        trungTam.HienThiMentor();
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Danh sách học viên:");
        trungTam.HienThiHocVien();
        Console.ResetColor();


    }

    // Nap sinh vien vao cho giang vien
    private void NapSinhVienChoGiangVien()
    {
        // hien thi danh sach giang vien
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Danh sách giảng viên:");
        trungTam.HienThiGiangVien();
        Console.ResetColor();

        // nhap ma giang vien can nap sinh vien
        string maGiangVien = InputHandler.NhapChuoi("Nhập mã giảng viên cần nạp sinh viên");

        // tim giang vien theo ma
        NguoiDung? giangVien = TimKiemNguoiDungTheoMa(maGiangVien);

        // neu tim thay thi nap sinh vien vao giang vien
        // neu khong tim thay thi in thong bao khong tim thay giang vien
        if (maGiangVien != null && giangVien is GiangVien gv)
        {
            // hien thi danh sach sinh vien
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Danh sách học viên:");
            trungTam.HienThiHocVien();
            Console.ResetColor();

            // nhap ma sinh vien can nap vao giang vien
            string maSinhVien = InputHandler.NhapChuoi("Nhập mã sinh viên cần nạp vào giảng viên");

            // tim sinh vien theo ma
            NguoiDung? sinhVien = TimKiemNguoiDungTheoMa(maSinhVien);

            // neu tim thay thi nap sinh vien vao giang vien
            // neu khong tim thay thi in thong bao khong tim thay sinh vien
            if(sinhVien != null && sinhVien is SinhVien sv)
            {
                gv.DanhSachSinhVien.Add(sv);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Nạp sinh viên {sv.Ten} vào giảng viên {gv.Ten} thành công!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Không tìm thấy sinh viên với mã: {maSinhVien}");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Không tìm thấy giảng viên với mã: {maGiangVien}");
            Console.ResetColor();
        }


    }

    // Hien thi danh sach hoc vien cua giang vien
    public void HienThiDanhSachHocVienCuaGiangVien()
    {
        // hien thi danh sach giang vien
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Danh sách giảng viên:");
        trungTam.HienThiGiangVien();
        Console.ResetColor();

        // nhap ma giang vien can hien thi danh sach hoc vien
        string maGiangVien = InputHandler.NhapChuoi("Nhập mã giảng viên cần hiển thị danh sách học viên");

        // tim giang vien theo ma
        NguoiDung? giangVien = TimKiemNguoiDungTheoMa(maGiangVien);

        // neu tim thay
        if(giangVien != null && giangVien is GiangVien gv)
        {
            if(gv.DanhSachSinhVien.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Danh sách học viên của giảng viên {gv.Ma}:");
                Console.ResetColor();
                foreach (var sv in gv.DanhSachSinhVien)
                {
                    Console.WriteLine($"- {sv.Ten} (Mã: {sv.Ma} Tuổi: {sv.Tuoi} Giới tính: {sv.GioiTinh})");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Giảng viên {gv.Ten} chưa có học viên nào.");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Không tìm thấy giảng viên với mã: {maGiangVien}");
            Console.ResetColor();
        }
    }

    // Tim kiem nguoi dung theo ma
    // tra ve object
    public NguoiDung? TimKiemNguoiDungTheoMa(string ma)
    {
        NguoiDung? nguoiDung = trungTam.GetNguoiDungs().Find(nd => nd.Ma.ToLower() == ma.ToLower());
        if (nguoiDung != null)
        {
            return nguoiDung;
        }
        else
        {
            return null;
        }
    }

    // tra ve void
    public void TimKiemNguoiDungTheoMa()
    {
        string maInput = InputHandler.NhapChuoi("Nhập mã người dùng cần tìm");
        NguoiDung? nguoiDung = TimKiemNguoiDungTheoMa(maInput);
        if (nguoiDung != null)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Thông tin người dùng:");
            nguoiDung.HienThiThongTin();
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Không tìm thấy người dùng với mã: {maInput}");
            Console.ResetColor();
        }

    }

    // Xoa nguoi dung
    public void XoaNguoiDung()
    {
        // hien thi danh sach nguoi dung
        HienThiDanhSachNguoiDung();
        // nhap ma nguoi dung can xoa
        string maInput = InputHandler.NhapChuoi("Nhập mã người dùng cần xóa");

        // tim nguoi dung theo ma
        NguoiDung? nguoiDung = TimKiemNguoiDungTheoMa(maInput);

        // neu tim thay thi xoa nguoi dung
        if (nguoiDung != null)
        {
            trungTam.GetNguoiDungs().Remove(nguoiDung);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Xóa người dùng với mã: {maInput} thành công!");
            Console.ResetColor();
        }

        // neu khong tim thay thi in thong bao khong tim thay nguoi dung
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Không tìm thấy người dùng với mã: {maInput}");
            Console.ResetColor();
        }

    }
}