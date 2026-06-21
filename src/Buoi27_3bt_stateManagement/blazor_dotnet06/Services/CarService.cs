namespace blazor_dotnet06.Services;
public class CarService
{
    public string currentColor {get; set;} = "red";

    public event Action? OnChange;

    private void Notify()
    {
        OnChange?.Invoke();
    }

// car color change method
public void changeColor(string newColor)
    {
        currentColor = newColor;
        Notify();
    }


}

