namespace blazor_dotnet06.ViewModel
{
    
public class ProductCartViewModel
{
    public int Id { get; set; }
    public string image { get; set; }
    public string name { get; set; }
    public decimal price { get; set; }
    public int quantity { get; set; }
}
//Lưu ý: Giá trị tính toán được tuyệt đối không được lưu trữ 

public static class ArrProductDefault
{
    public static List<ProductCartViewModel> arrProduct = new List<ProductCartViewModel>()
    {
        new ProductCartViewModel
        {
            Id = 1,
            image = "https://dummyimage.com/300x300/000/fff&text=iPhone+15",
            name = "iPhone 15",
            price = 1299,
            quantity = 1
        },
        new ProductCartViewModel
        {
            Id = 2,
            image = "https://dummyimage.com/300x300/000/fff&text=Samsung+S24",
            name = "Samsung Galaxy S24",
            price = 1499,
            quantity = 1
        },
        new ProductCartViewModel
        {
            Id = 3,
            image = "https://dummyimage.com/300x300/000/fff&text=Xiaomi+14",
            name = "Xiaomi 14",
            price = 1199,
            quantity = 1
        }
    };
}
}