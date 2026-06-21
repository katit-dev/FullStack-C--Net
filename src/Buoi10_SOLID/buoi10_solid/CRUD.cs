using System.Reflection;

public class CRUD<T> where T : class
{
    public List<T> items { get; set; }

    public CRUD()
    {
        items = new List<T>();
    }

    // create
    public void Create(T item)
    {
        items.Add(item);
    }

    // xoa
    public void Delete(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            items.RemoveAt(index);
        }
    }

    // update
    public void Update(int index, T newItem)
    {
        if (index >= 0 && index < items.Count)
        {
            items[index] = newItem;
        }
    }

    // show ds
    public void Show()
    {
        Console.WriteLine("Danh sach: ");
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"Item {i + 1}: {items[i]}");
            PropertyInfo[] dsThuocTinh = typeof(T).GetProperties();
            foreach (var thuocTinh in dsThuocTinh)            {
                Console.WriteLine($"{thuocTinh.Name}: {thuocTinh.GetValue(items[i])}");
            }
        }
    }
}