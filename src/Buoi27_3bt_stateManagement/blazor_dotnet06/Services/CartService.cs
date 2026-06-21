using blazor_dotnet06.ViewModel;

public class CartService
{
    public List<PhoneViewModel> phonesDefault = new List<PhoneViewModel>()
{
    new PhoneViewModel
    {
        Id = 1,
        Image = "https://fdn2.gsmarena.com/vv/pics/apple/apple-iphone-15-1.jpg",
        Name = "iPhone 15",
        Price = 1299
    },
    new PhoneViewModel
    {
        Id = 2,
        Image = "https://fdn2.gsmarena.com/vv/pics/xiaomi/xiaomi-14-1.jpg",
        Name = "Xiaomi 14",
        Price = 1199
    },
    new PhoneViewModel
    {
        Id = 3,
        Image = "https://fdn2.gsmarena.com/vv/pics/apple/apple-iphone-14-1.jpg",
        Name = "iPhone 14",
        Price = 999
    }
};

    // them san pham vao gio hang
    public void AddToCart(PhoneViewModel phoneClick)
    {
        var existingPhone = phonesInCart.FirstOrDefault(i => i.Id == phoneClick.Id);
        if(existingPhone != null)
        {
            existingPhone.Quantity++;
        }
        else
        {
            phoneClick.Quantity = 1;
            phonesInCart.Add(phoneClick);
        }
        Notify();
    }

    // ham xoa san pham khoi gio hang
    public void RemoveFromCart(PhoneViewModel phoneClick)
    {
        var existingPhone = phonesInCart.FirstOrDefault(i => i.Id == phoneClick.Id);
        if(existingPhone != null)
        {
            phonesInCart.Remove(existingPhone);
            Notify();
        }
        
    }

    // ham +- so luong san pham trong gio hang
    public void UpdateQuantity(PhoneViewModel phoneClick, int quantity)
    {
        var existingPhone = phonesInCart.FirstOrDefault(i => i.Id == phoneClick.Id);
        if(existingPhone != null)
        {
            existingPhone.Quantity += quantity;
            if(existingPhone.Quantity <= 0)
            {
                phonesInCart.Remove(existingPhone);
            }
            Notify();
        }
    }

public List<PhoneViewModel> phonesInCart { get; set; } = new List<PhoneViewModel>();

    public event Action? OnChange;

    private void Notify()
    {
        OnChange?.Invoke();
    }
}