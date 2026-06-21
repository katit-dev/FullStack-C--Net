class Food
{
    public string Name { get; set; }
    public double Price { get; set; }

    public Food(string name, double price)
    {
        Name = name;
        Price = price;
    }

    // 
    public void DisplayInfo()
    {
        Console.WriteLine($"Food: {Name}, Price: {Price:C}");
    }
}