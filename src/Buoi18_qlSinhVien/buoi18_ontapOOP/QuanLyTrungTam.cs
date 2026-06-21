public class QuanLyTrungTam
{
        TrungTam trungTam = new TrungTam();

    // viet menu
    public void HienThiMenu()
    {
            // khoi tao trung tam
        int choice;
        bool checkValid;
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

            choice = InputHandler.NhapSoNguyen(1, 7);
            switch (choice)
            {
                case 1:
                    ThemNguoiDung();
                    break;
                case 2:
                    trungTam.HienThiDanhSachNguoiDung();
                    break;
                case 3:
                    trungTam.HienThiDanhSachGiangVien();
                    Console.Write("Hãy chọn giảng viên cần thao tác: ");
                        /*
                        GV01 - Nga
                        GV02 - An
                        */
                        string maGVCHon = Console.ReadLine();
                        // từ mã lấy re Gianrg viên tương ứng
                        GiangVien gvChon = (GiangVien)trungTam.GetDanhSachNguoiDung().Find(g => g.Ma == maGVCHon);

                        // show danh sach tat ca sinh vien trong trung tam
                        Console.WriteLine("Danh sách sinh viên trong trung tâm:");
                        foreach (var nguoiDung in trungTam.GetDanhSachNguoiDung())
                        {
                            // neu ma bat dau bang sv thi moi hien thi
                            if (nguoiDung.Ma.StartsWith("sv", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine($"Mã: {nguoiDung.Ma}, Tên: {nguoiDung.Ten}");
                            }
                        }

                         Console.Write("Hãy chọn học viên cần thêm vào giảng viên: ");


                        // chọn sinh viên

                        // mã chọn
                        string maSVCheon = Console.ReadLine();

                        // tìm sinh viên chọn
                        SinhVien? svChon = trungTam.GetDanhSachNguoiDung().Find(a => a.Ma == maSVCheon);




                        // b3 : khi chọn sv rồi ,  lấy thông tin SV mình thêm vào DanhSachHocVien của GV
                        if (gvChon != null && svChon != null)
                        {
                            gvChon.DanhSachHocVien.Add(svChon);
                            Console.WriteLine($"✅ Thêm thành công sinh viên {svChon.Ten} vào giảng viên {gvChon.Ten}");
                        }
                        else{
                            Console.WriteLine("Mã giảng viên hoặc mã sinh viên không hợp lệ");
                        }

                    break;
                case 4:
                    HienThiDanhSachHocVienCuaGiangVien();
                    break;
                case 5: 
                    Console.WriteLine("Nhập mã người cần tìm: ");
                    string maCanTim = Console.ReadLine();
                    if(string.IsNullOrEmpty(maCanTim))
                    {
                        Console.WriteLine("Mã không được để trống.");
                        break;
                    }
                    SinhVien? nguoiDungTimDuoc = trungTam.TimKiemNguoiDungTheoMa(maCanTim);
                    if(nguoiDungTimDuoc != null)
                    {
                        Console.WriteLine("Thông tin người dùng tìm được:");
                        nguoiDungTimDuoc.ShowInfo();
                    }
                    else
                    {
                        Console.WriteLine("Không tìm thấy người dùng với mã đã nhập.");
                    }
                    break;
                    case 6:
                    removeNguoiDung();
                    break;
                case 7:
                    Console.WriteLine("Thoát chương trình.");
                    return; // thoat khoi ham hien thi menu
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    Console.ResetColor();
                    break;

            }
        }
        while (true);
    }

    // xoa nguoi dung theo ma
    private void removeNguoiDung()
    {
        // hiển thị danh sách người dùng để chọn
        trungTam.HienThiDanhSachNguoiDung();
        Console.Write("Nhập mã người dùng cần xóa: ");
        string maCanXoa = Console.ReadLine();
        SinhVien? nguoiDungCanXoa = trungTam.TimKiemNguoiDungTheoMa(maCanXoa);
        if (nguoiDungCanXoa != null)
        {
            trungTam.GetDanhSachNguoiDung().Remove(nguoiDungCanXoa);
            Console.WriteLine($"✅ Đã xóa người dùng có mã {maCanXoa} thành công.");
        }
        else
        {
            Console.WriteLine("Không tìm thấy người dùng với mã đã nhập.");
        }
    }

// Hiển thị danh sách học viên của Giảng viên
public void HienThiDanhSachHocVienCuaGiangVien()
    {
        trungTam.HienThiDanhSachGiangVien();
        Console.Write("Hãy chọn giảng viên cần thao tác: ");
        string maGVCHon = Console.ReadLine();
        // từ mã lấy re Gianrg viên tương ứng
        GiangVien gvChon = (GiangVien)trungTam.GetDanhSachNguoiDung().Find(g => g.Ma == maGVCHon);

        if (gvChon != null)
        {
            Console.WriteLine($"Danh sách học viên của giảng viên {gvChon.Ten}:");
            foreach (var sv in gvChon.DanhSachHocVien)
            {
                Console.WriteLine($"Mã: {sv.Ma}, Tên: {sv.Ten}, Tuổi: {sv.Tuoi}, Giới tính: {sv.GioiTinh}");
            }
        }
        else
        {
            Console.WriteLine("Mã giảng viên không hợp lệ");
        }
    }


    // them nguoi dung vao trung tam
    public void ThemNguoiDung()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1.Thêm sản phẩm mới \n");
        Console.ResetColor();
        int loai;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Chon loai san pham:");
        Console.WriteLine("1. Thêm Sinh Vien");
        Console.WriteLine("2. Them Mentor");
        Console.WriteLine("3. Them Giang Vien"); Console.ResetColor();
        loai = InputHandler.NhapSoNguyen(1, 3);

        // Nhap thong tin de khoi tao

        switch (loai)
        {
            case 1:
                SinhVien sv = new SinhVien();
                sv.NhapThongTin();
                // them vao danh sach sinh vien
                    trungTam.DanhSachNguoiDung.Add(sv);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Successfully added new student to the center.");
                    Console.ResetColor();
                
                break;
            case 2:
                Mentor mentor = new Mentor();
                mentor.NhapThongTin();
                // them vao danh sach mentor
                if (mentor != null)
                    trungTam.DanhSachNguoiDung.Add(mentor);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully added new mentor to the center.");
                Console.ResetColor();
                break;
            case 3:
                GiangVien gv = new GiangVien();
                gv.NhapThongTin();
                // them vao danh sach giang vien
                if (gv != null)
                    trungTam.DanhSachNguoiDung.Add(gv);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully added new lecturer to the center.");
                Console.ResetColor();
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                Console.ResetColor();
                break;
        }

    }


    // tim kiem nguoi theo ma
    public void TimKiemNguoiDungTheoMa()
    {
        Console.Write("Nhập mã người dùng cần tìm: ");
        string maCanTim = Console.ReadLine();

        var nguoiDung = trungTam.GetDanhSachNguoiDung().Find(nd => nd.Ma.Equals(maCanTim, StringComparison.OrdinalIgnoreCase));

        if (nguoiDung != null)
        {
            Console.WriteLine("Thông tin người dùng:");
            nguoiDung.ShowInfo();
        }
        else
        {
            Console.WriteLine("Không tìm thấy người dùng với mã đã nhập.");
        }
    }

    // xoa theo ma 




}