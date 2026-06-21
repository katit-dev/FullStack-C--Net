using Newtonsoft.Json;

class FoodManage
{
    public List<Food> FoodList { get; set; } = new List<Food>();
    // duong dan den file menu.txt : se la 1 bien static de toan bo class co the truy cap
    public static string MenuFilePath = "menu.json";

    // constructor mac dinh de khoi tao menu mau
    public FoodManage()
    {
        // Khởi tạo với một số món ăn mẫu
        // FoodList.Add(new Food("Pho", 50000));
        // FoodList.Add(new Food("Banh Mi", 30000));
        // FoodList.Add(new Food("Com Tam", 40000));
        LoadMenuFromFile(); // Load menu từ file khi khởi tạo
    }

    // Thêm món
    public void AddFood()
    {
        string name;
        double price;

        // Nhập tên (bắt nhập lại nếu sai)
        while (true)
        {
            Console.Write("Nhập tên món ăn: ");
            name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
                break;

            Console.WriteLine("Tên món ăn không được để trống.");
        }

        // Nhập giá (bắt nhập lại nếu sai)
        while (true)
        {
            Console.Write("Nhập giá món ăn: ");
            bool isValidPrice = double.TryParse(Console.ReadLine(), out price);

            if (isValidPrice && price >= 50)
                break;

            Console.WriteLine("Giá món ăn phải là số và >= 50.");
        }

        // Tạo object và thêm vào list
        Food newFood = new Food(name, price);
        FoodList.Add(newFood);

        Console.WriteLine("Đã thêm món ăn thành công!");
    }


    // Hiển thị menu
    public void DisplayMenu()
    {
        if (FoodList.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Menu đang trống.");
            Console.ResetColor();
            return;
        }

        Console.WriteLine("----- Menu -----");

        for (int i = 0; i < FoodList.Count; i++)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{i + 1}. ");
            FoodList[i].DisplayInfo(); Console.ResetColor();

        }
    }

    // xoa món
    public void RemoveFood(string name)
    {
        var foodToRemove = FoodList.FirstOrDefault(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (foodToRemove != null)
        {
            FoodList.Remove(foodToRemove);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Da xoa mon an thanh cong.");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("Khong tim thay mon an.");
        }
    }

    // hien thi menu chuc nang
    public void ShowMenuOptions()
    {
        do
        {
            int choice;
            Console.WriteLine("1. Them mon an");
            Console.WriteLine("2. Hien thi menu");
            Console.WriteLine("3. Xoa mon an");
            Console.WriteLine("4. Luu file");
            Console.WriteLine("5. Thoat");
            Console.Write("Chon chuc nang (1-5): ");
            bool isValid = int.TryParse(Console.ReadLine(), out choice);
            if (!isValid)
            {
                Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddFood();
                    SaveMenuToFile(); // Lưu menu sau khi thêm món ăn
                    break;
                case 2:
                    DisplayMenu();
                    break;
                case 3:
                    Console.Write("Nhap ten mon an can xoa: ");
                    string nameToRemove = Console.ReadLine();
                    RemoveFood(nameToRemove);
                    SaveMenuToFile(); // Lưu menu sau khi xóa món ăn
                    break;
                case 4:
                    SaveMenuToFile();
                    break;
                case 5:
                    Console.WriteLine("Thoat chuong trinh.");
                    return;
                default:
                    Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
                    break;
            }
        } while (true);
    }

    /*
        Khi nao can luu menu vao file?
    - khi co thao tac chinh sua menu: them, xoa mon an
    - khi thoat chuong trinh: truoc khi thoat, luu menu vao file de lan sau mo len van co du lieu cu
    */

    // luu lai du lieu menu vao file
    public void SaveMenuToFile()
    {
        // luu file json se luu dang string
        // du lieu dang co dang list food --> chuyen ve string
        // dung thu vien ho tro chuyen doi: Newtonsoft.Json

        // chuyen doi list food ve string dang json dung ham SerializeObject
        string json = JsonConvert.SerializeObject(FoodList);

        // luu string json vao file
        File.WriteAllText(MenuFilePath, json);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Da luu menu vao file.");
        Console.ResetColor();
    }

    // doc du lieu tu file va load vao menu
    // khong can lay data cung tu constructor nữa
    public void LoadMenuFromFile()
    {
        if (File.Exists(MenuFilePath))
        {
            // neu nhu file tồn tại thì đọc
            string json = File.ReadAllText(MenuFilePath);
            // json chuyen ve list food dung ham DeserializeObject
            FoodList = JsonConvert.DeserializeObject<List<Food>>(json);// nhan vao 1 chuoi json va tra ve 1 di tuong da duoc chuyen doi
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Da load menu tu file.");
            Console.ResetColor();

        }
    }

}
