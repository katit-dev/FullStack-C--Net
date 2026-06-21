using blazor_dotnet06.ViewModel;

public class CartService
{
    public List<ProductCartViewModel> lstProd { get; set;} = new List<ProductCartViewModel>()
    {
        new ProductCartViewModel
        {
            Id = 1,
            image = "https://dummyimage.com/300x300/000/fff&text=iPhone+15",
            name = "iPhone 15",
            price = 1299,
            quantity = 1
        }
    };


    // ham them san pham vao gio hang
     public async Task AddItem(ProductCartViewModel itemClick)
    {
        //Kiểm tra giỏ hàng có item đó chưa nếu có thì tăng số lượng nếu chưa có thì thêm vào lstProd
        ProductCartViewModel? itemCart = lstProd.SingleOrDefault(item => item.Id == itemClick.Id);
        if (itemCart != null)
        {
            itemCart.quantity += 1;
        }
        else
        {
            lstProd.Add(itemClick);
        }

        //Cập nhật lại giao diện 
        await StateHasChanged();
    }


    // ham tang giam so luong san pham trong gio hang
    public async Task UpdateQuantity(int id, int quantity)
    {
       ProductCartViewModel? itemCart = lstProd.SingleOrDefault(item => item.Id == id);
       // neu khong co item trong gio hang
       if(itemCart == null)
       {
        return;
       }
       // neu co item trong gio hang
       itemCart.quantity += quantity;

       // neu quantity <= 0 thi xoa item do khoi gio hang
         if(itemCart.quantity <= 0)
         {
          lstProd.Remove(itemCart);
         }
       await StateHasChanged();
    }
    // ham xoa san pham khoi gio hang
    public async Task RemoveItem(int id)
    {
        ProductCartViewModel? itemCart = lstProd.SingleOrDefault(item => item.Id == id);
        if (itemCart != null)
        {
            lstProd.Remove(itemCart);
        }
        await StateHasChanged();
    }



    public event Action OnChange;

    public async Task StateHasChanged()
    {
        this.OnChange?.Invoke();
    }
}