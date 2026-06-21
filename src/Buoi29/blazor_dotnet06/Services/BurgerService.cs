
public class BurgerService
{
    // se quan ly 1 mang cac ingredient da duoc chon
    public List<Topping> lstTopping = new List<Topping>()
    {
        new Topping(){name ="salad", price=10,quantity=5 },
        new Topping(){name ="beef", price=30,quantity=1 },
        new Topping(){name ="cheese", price=10,quantity=1 },
    };


    public event Action OnChange;

    public void ChangeQuantity(string name, int quantity)
    {
        // dua vao name de lay ra topping can thay doi
        Topping? topping = lstTopping.SingleOrDefault(t => t.name == name);
        if(topping != null)
        {
            topping.quantity += quantity;
            if(topping.quantity < 0)
            {
                topping.quantity = 0;
            }
            // sau khi thay doi xong thi goi ham OnChange de thong bao cho cac component dang lang nghe biet
            this.OnChange?.Invoke();
        }
    }
    public void RemoveItem(string name)
    {
        Topping? topping = lstTopping.SingleOrDefault(t => t.name == name);
        if (topping != null)
        {
            lstTopping.Remove(topping);
            
        }
        StateHasChange();
    }


    public void StateHasChange()
    {
        this.OnChange?.Invoke();
    }
}