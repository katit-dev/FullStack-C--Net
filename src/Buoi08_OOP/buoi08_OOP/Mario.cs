// Name, Health, Power, IsAlive
// Jump, Run, Attack
// khi bi tan cong thi giam mau
// shot -> giam 1 mang 
// an mushroom -> tang mang, tang suc mang

class Mario
{
    // static properties
    // thuoc tinh thuoc ve clas, thuoc ve cai "khuong"
    public static int TongSoMario = 0;
    // instance properties (thuoc tinh binh thuong)
    // constructor
    // methods

    public string Name { get; set; }
    public int Health { get; set; }
    public int Power { get; set; }
    public bool IsAlive { get; set; }
    public int Lives { get; private set; } = 3; // số mạng ban đầu
    // khong cho gan gia tri ben ngoai class

    // static constructor
    static Mario()
    {
        // chi lam việc với các thuộc tính static
        // chỉ được gọi 1 lần duy nhất khi lần đầu tiên truy cập vào lớp
        // nó sẽ chạy trước constructor instance
        Console.WriteLine("lần khởi tạo static đầu tiên của class Mario");
        Console.WriteLine("tong nguoi choi: " + TongSoMario);
    }

    public Mario()
    {
        Name = "Mario";
        Health = 100;
        Power = 10;
        IsAlive = true;
        Lives = 3;
        // mỗi khi tạo ra 1 Mario, thì tăng tổng số Mario lên 1
        TongSoMario++;
    }
    public Mario(string name, int health, int power)
    {
        Name = name;
        Health = health;
        Power = power;
        IsAlive = true;
        Lives = 3;
        TongSoMario++;
    }
    // ham tang giam mang
    public void ChangeLives(int change)
    {
        Lives += change;
        if (Lives < 0)
        {
            Lives = 0;
        }
        System.Console.WriteLine($"{Name} hiện có {Lives} mạng.");
    }

    // phương thức static
    public static void DisplayTotalMarios()
    {
        // System.Console.WriteLine($"Tổng số Mario hiện có: {TongSoMario}");
        // show ten Mario
       // Console.WriteLine("ten mario: " + Name); lỗi vì Name không phải static
       Console.WriteLine($"Tổng số Mario hiện tại là : {TongSoMario}");
    }

    public void CurrentStatus()
    {
        System.Console.WriteLine($"Tên: {Name}, Máu: {Health}, Sức mạnh: {Power}, Trạng thái: {(IsAlive ? "Sống" : "Chết")}");
    }
    public void Jump()
    {
        System.Console.WriteLine($"{Name} nhảy lên!");
    }

    public void Run()
    {
        System.Console.WriteLine($"{Name} chạy nhanh!");
    }

    public void Attack()
    {
        System.Console.WriteLine($"{Name} tấn công!");
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        System.Console.WriteLine($"{Name} bị tấn công và mất {damage} máu. Máu còn lại: {Health}");
        if (Health <= 0)
        {
            IsAlive = false;
            System.Console.WriteLine($"{Name} đã chết.");
        }
    }
    public void EatMushroom()
    {
        if(!IsAlive)
        {
            System.Console.WriteLine($"{Name} đã chết và không thể ăn mushroom.");
            return;
        }
        Power += 5;
        System.Console.WriteLine($"{Name} ăn mushroom và tăng sức mạnh lên {Power}.");
        CurrentStatus();
    }

}