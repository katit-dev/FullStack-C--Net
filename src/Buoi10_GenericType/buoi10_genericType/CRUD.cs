using System.Reflection;

class CRUD<T> where T : class
{
    public List<T> Items { get; set; } = new List<T>();

    public CRUD()
    {
        // khoi tao mac dinh
        // Items.Add(new T());// khong khoi tao t = new duoc
        Items.Add(Activator.CreateInstance(typeof(T)) as T); // khoi tao doi tuong T bang activator va them vao danh sach items 
        
    }
    // Create
    public void Create(T item)
    {
        Items.Add(item);
        Console.WriteLine("them thanh cong");
    }

    // Read
    public List<T> Read()
    {
        return Items;
    }

    // Update
    public void Update(int index, T newItem)
    {
        if (index >= 0 && index < Items.Count)
        {
            Items[index] = newItem;
        }
        else
        {
            Console.WriteLine("Index không hợp lệ.");
        }
    }

    // Delete
    public void Delete(int index)
    {
        if (index >= 0 && index < Items.Count)
        {
            Items.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Index không hợp lệ.");
        }
    }

    // Hiển thị tất cả items
    public void HienThi()
    {
        Console.WriteLine("Danh sách items:");
        for (int i = 0; i < Items.Count; i++)
        {
            // in ra ten  cua tung item
            Console.WriteLine($"Index: {i}, Item: {Items[i]}");

            // su dung phuong thuc hien thi cua tung item tuong ung: vd: ten, tuoi, ...

        // lay ra ds cac thuoc tinh cua tung item
        // sau do chay vong for de in ra tung thuoc tinh cua tung item
        PropertyInfo[] dsThuocTinh = typeof(T).GetProperties();// lay ra ds thuoc tinh cua kieu du lieu T
        // vd: neu T la class Nguoi thi dsThuocTinh se chua cac thuoc tinh: Ten, Tuoi, DiaChi, ...
        // neu T la animal thi dsThuocTinh se chua cac thuoc tinh: Ten, Loai, CanNang, ...

        foreach (var item in Items)
        {
            Console.WriteLine("Item:");
            foreach (var thuocTinh in dsThuocTinh)
            {
                var giaTri = thuocTinh.GetValue(item); // lay gia tri cua thuoc tinh tuong ung voi item
                Console.WriteLine($"{thuocTinh.Name}: {giaTri}");
            }
            Console.WriteLine();
        }
        }

        
    }   

    // TIM KIEM
    public List<T> TimKiem(Func<T, bool> predicate)
    {
        return Items.Where(predicate).ToList();
    }


}


public class CRUD2<T> where T : class
{
    
}