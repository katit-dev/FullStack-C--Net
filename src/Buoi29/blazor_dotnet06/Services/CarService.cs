namespace blazor_dotnet06.Services
{
    public class CarService
    {
        public string CarImage { get; set; } = "/img/red-car.jpg";

        public event Action? OnChange;

        public Task ChangeCar(string imagePath)
        {
            CarImage = imagePath;
            Notify();
            return Task.CompletedTask;
        }

        private void Notify()
        {
            OnChange?.Invoke();
        }
    }
}