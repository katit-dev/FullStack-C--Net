
using Newtonsoft.Json;
public class QuanLyNhanVien
{
    public List<NhanVien> _danhSachNhanVien;
    string filePath = "danhSachNhanVien.json";
    private static int _maHienTai = 0;

    // khoi tao constructor
    public QuanLyNhanVien()
    {
        DocFile();
        if (_danhSachNhanVien == null)
        {
            _danhSachNhanVien = new List<NhanVien>();
        }
    }

    // phương thức để thêm nhân viên vào danh sách
    public void ThemNhanVien(NhanVien nhanVien)
    {
        
        if (_danhSachNhanVien == null)
        {
            _maHienTai++;
            nhanVien.MaNhanVien = _maHienTai;
            _danhSachNhanVien.Add(nhanVien);
        }
        
        // neu danh sach khong null
        // thi ma nha vien moi phai tu dong lon hon ma nhan vien lon nhat trong danh sach
        else
        {
            int maNhanVienLonNhat = _danhSachNhanVien.Max(nv => nv.MaNhanVien);
            nhanVien.MaNhanVien = maNhanVienLonNhat + 1;
            _danhSachNhanVien.Add(nhanVien);
        }


        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Them nhan vien thanh cong");
        Console.ResetColor();
    }

    // phương thức để xem danh sách nhân viên
    public void XemDanhSachNhanVien()
    {
        if (_danhSachNhanVien == null || _danhSachNhanVien.Count == 0)
        {
            Console.WriteLine("Danh sach nhan vien trong");
            return;
        }
        Console.ForegroundColor = ConsoleColor.Blue;
        foreach (var nhanVien in _danhSachNhanVien)
        {
            nhanVien.XemThongTin();
        }
        Console.ResetColor();

    }

    // tim kiem theo ten
    public void TimKiemTheoTen(string ten)
    {
        bool isFound = false;
        // kiem tra input string co rong hay khong
        if (!KiemTraInputString(ten))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ten khong hop le");
            Console.ResetColor();
            return;
        }

        foreach (var nhanVien in _danhSachNhanVien)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            if (nhanVien.Ten == ten)
            {
                nhanVien.XemThongTin();
                isFound = true;
            }
            Console.ResetColor();


        }
        // neu nhu khong tim thay nhan vien nao co ten trung voi ten can tim
        if (!isFound)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Khong tim thay nhan vien nao co ten trung voi ten can tim");
            Console.ResetColor();
        }
    }

    // kiem tra input string co rong hay khong
    public bool KiemTraInputString(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }
        return true;
    }

    // xoa
    public void XoaNhanVien(int maNhanVien)
    {
        bool isFound = false;
        // kiem tra input int co rong hay khong
        if (KiemTraMaNhanVien(maNhanVien) == -1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ma nhan vien khong hop le");
            Console.ResetColor();
            return;
        }

        foreach (var nhanVien in _danhSachNhanVien)
        {
            if (nhanVien.MaNhanVien == maNhanVien)
            {
                _danhSachNhanVien.Remove(nhanVien);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Xoa nhan vien thanh cong");
                Console.ResetColor();
                isFound = true;
                break;
            }
        }

        // neu nhu khong tim thay nhan vien nao co ma nhan vien trung voi ma nhan vien can xoa
        if (!isFound)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Khong tim thay nhan vien nao co ma nhan vien trung voi ma nhan vien can xoa");
            Console.ResetColor();
        }
    }

    // sua ten
    public void SuaTenNhanVien(int maNhanVien, string tenMoi)
    {
        bool isFound = false;
        // kiem tra input int co rong hay khong
        if (KiemTraMaNhanVien(maNhanVien) == -1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ma nhan vien khong hop le");
            Console.ResetColor();
            return;
        }

        // kiem tra input string co rong hay khong
        if (!KiemTraInputString(tenMoi))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ten moi khong duoc de trong");
            Console.ResetColor();
            return;
        }

        foreach (var nhanVien in _danhSachNhanVien)
        {
            if (nhanVien.MaNhanVien == maNhanVien)
            {
                nhanVien.Ten = tenMoi;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sua ten nhan vien thanh cong");
                Console.ResetColor();
                isFound = true;
                break;
            }
        }
        if (!isFound)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Khong tim thay nhan vien co ma nhan vien trung voi ma nhan vien can sua");
            Console.ResetColor();
        }
    }

    // ham kiem tra ma nhan vien co rong hay khong
    public int KiemTraMaNhanVien(int maNhanVien)
    {
        int result;
        bool isInt = int.TryParse(maNhanVien.ToString(), out result);
        if (!isInt || result <= 0)
        {
            return -1;
        }
        return result;
    }

    // luu file
    public void LuuFile()
    {
        string jsong = JsonConvert.SerializeObject(_danhSachNhanVien, Formatting.Indented, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });// chuyen 1 doi tuong thanh 1 chuoi json, Formatting.Indented de format lai chuoi json de de doc hon, ReferenceLoopHandling.Ignore de tranh loi khi co vong lap tham chieu giua cac doi tuong
        File.WriteAllText(filePath, jsong);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Luu file thanh cong");
        Console.ResetColor();


    }

    // doc file
    public void DocFile()
    {
        if (File.Exists(filePath))
        {
            // neu nhu file tồn tại thì đọc
            string json = File.ReadAllText(filePath);
            // json chuyen ve list food dung ham DeserializeObject
            _danhSachNhanVien = JsonConvert.DeserializeObject<List<NhanVien>>(json, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });// nhan vao 1 chuoi json va tra ve 1 di tuong da duoc chuyen doi
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Da load danh sach nhan vien tu file.");
            Console.ResetColor();

        }
    }

    // hien thi danh sach thong tin nhan vien
    public void HienThiDanhSachNhanVien()
    {
        if (_danhSachNhanVien == null || _danhSachNhanVien.Count == 0)
        {
            Console.WriteLine("Danh sach nhan vien trong");
            return;
        }

        Console.WriteLine("Danh sach nhan vien:");
        foreach (var nhanVien in _danhSachNhanVien)
        {
            Console.WriteLine($"MaNhanVien: {nhanVien.MaNhanVien}, Ten: {nhanVien.Ten}, Luong: {nhanVien.TinhLuong()}");
        }
    }


    // hien thi menu chuc nang
    public void HienThiMenu()
    {
        do
        {
            int choice;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nChon chuc nang:");
            Console.WriteLine("1. Them nhan vien");
            Console.WriteLine("2. Xem danh sach nhan vien");
            Console.WriteLine("3. Tim kiem nhan vien theo ten");
            Console.WriteLine("4. Xoa nhan vien");
            Console.WriteLine("5. Sua ten nhan vien");
            Console.WriteLine("6. Luu file");
            Console.WriteLine("7. Hien thi danh sach nhan vien");
            Console.WriteLine("0. Thoat");
            Console.Write("Nhap lua chon: "); Console.ResetColor();

            bool isInt = int.TryParse(Console.ReadLine(), out choice);
            if (!isInt)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Lua chon khong hop le, vui long nhap lai.");
                Console.ResetColor();
                continue;
            }
            switch (choice)
            {
                case 1:
                    NhanVien nhanVien = new NhanVien();
                    Console.Write("Nhap ten nhan vien: ");
                    nhanVien.Ten = Console.ReadLine();
                    Console.Write("Nhap luong 1 gio: ");
                    nhanVien.Luong1H = double.Parse(Console.ReadLine());
                    Console.Write("Nhap so gio lam: ");
                    nhanVien.SoGioLam = int.Parse(Console.ReadLine());
                    ThemNhanVien(nhanVien);
                    LuuFile();
                    break;
                case 2:
                    XemDanhSachNhanVien();
                    break;
                case 3:
                    Console.Write("Nhap ten nhan vien can tim: ");
                    string? ten = Console.ReadLine();
                    TimKiemTheoTen(ten);
                    break;
                case 4:
                    Console.Write("Nhap ma nhan vien can xoa: ");
                    int maNhanVienXoa = int.Parse(Console.ReadLine());
                    XoaNhanVien(maNhanVienXoa);
                    LuuFile();
                    break;
                case 5:
                    Console.Write("Nhap ma nhan vien can sua: ");
                    int maNhanVienSua = int.Parse(Console.ReadLine());
                    Console.Write("Nhap ten moi: ");
                    string tenMoi = Console.ReadLine();
                    SuaTenNhanVien(maNhanVienSua, tenMoi);
                    LuuFile();
                    break;
                case 6:
                    LuuFile();
                    break;
                case 7:
                    HienThiDanhSachNhanVien();
                    break;
                case 0:
                    Console.WriteLine("Thoat chuong trinh.");
                    return;
                default:
                    Console.WriteLine("Lua chon khong hop le, vui long chon lai.");
                    break;
            }
        } while (true);


    }

}