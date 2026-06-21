public class Bird
{
    public string Name { get; set; }
    public Bird(string name)
    {
        Name = name;
    }
    // public virtual void Fly()
    // {
    //     Console.WriteLine($"{Name} is flying.");
    // }
}

public interface IFlyable
{
    void Fly();
}

public class Sparow : Bird, IFlyable
{
    public Sparow(string name) : base(name) { }

    public void Fly()
    {
        Console.WriteLine($"{Name} is flying high.");
    }
}

public class penguin : Bird
{
    public penguin(string name) : base(name) { }

}