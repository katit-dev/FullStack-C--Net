using System.Collections.Generic;


public class ProductDetailViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Alias { get; set; }
    public decimal Price { get; set; }
    public bool Feature { get; set; }
    public string Description { get; set; }
    public List<string> Size { get; set; } = new List<string>();
    public string ShortDescription { get; set; }
    public int Quantity { get; set; }
    public List<string> DetailedImages { get; set; } = new List<string>();
    public string Image { get; set; }
    public string ImgLink { get; set; }
    public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    public List<RelatedProductViewModel> RelatedProducts { get; set; } = new List<RelatedProductViewModel>();
}

public class CategoryViewModel
{
    public string Id { get; set; }
    public string Category { get; set; }
}

public class RelatedProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Alias { get; set; }
    public bool Feature { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public string Image { get; set; }
    public string ImgLink { get; set; }
}