
namespace blazor_dotnet06.Services
{
    public class NumberService
{
    public int number { get; set; } = 1;

    public NumberService()
    {
    }

    public async Task changeNumber(int quantity)
        {
            number += quantity;
            await Notify(); // goi ham notify de cap nhat giao dien

        }

    public event Action OnChange;// ket noi voi giao dien de chu dong goi component render lai giao dien

    public async Task Notify()
    {
        OnChange?.Invoke(); // goi giao dien component dang ket noi voi service chu dong render lai giao dien
    }
}
}
