public class BurgerService
{
    public List<Ingredient> lstIngredient {get; set;} = new List<Ingredient>()
    {
      new Ingredient(){name = "salad", price = 5, quantity = 1},
      new Ingredient(){name = "beef", price = 20, quantity = 1},
      new Ingredient(){name = "cheese", price = 15, quantity = 1}
    };

    // ============ Logic Method ===================
    public void upateIngredient(string name, int quantity)
    {
        var exisiting = lstIngredient.FirstOrDefault(e => e.name == name);
        if(exisiting != null)
        {
            exisiting.quantity += quantity;
            if(exisiting.quantity <= 0)
            {
                lstIngredient.Remove(exisiting);
            }
        }
        Notify();
    }
    public void removeIngredient(string name)
    {
        var exisiting = lstIngredient.FirstOrDefault(e => e.name == name);
        if(exisiting != null)
        {
            lstIngredient.Remove(exisiting);
        }
         Notify();
    }
    public void AddIngredient(Ingredient newIngredient)
    {
        var eixisting = lstIngredient.FirstOrDefault(e => e.name == newIngredient.name);
        if(eixisting != null)
        {
            eixisting.quantity += 1;
        }
        else
        {

            lstIngredient.Add(newIngredient);
        }
        Notify();
    }




    // ============ Logic Method ===================

    public event Action OnChange;

    public void Notify()
    {
        OnChange?.Invoke();
    }
}