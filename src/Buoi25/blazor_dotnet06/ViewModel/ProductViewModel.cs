using System.Collections.Generic;
namespace blazor_dotnet06.ViewModel;

public class ProductViewModel
{
    public List<int> sizes { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string alias { get; set; }
    public decimal price { get; set; }
    public string description { get; set; }
    public string size { get; set; }
    public string shortDescription { get; set; }
    public int quantity { get; set; }
    public bool deleted { get; set; }
    public string categories { get; set; }
    public string relatedProducts { get; set; }
    public bool feature { get; set; }
    public string image { get; set; }
    public string imgLink { get; set; }
}

public class CategoryViewModel
{
    public string id { get; set; }
    public string category { get; set; }
}