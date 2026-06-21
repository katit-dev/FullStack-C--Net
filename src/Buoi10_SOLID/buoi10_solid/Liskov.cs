/*
Liskov Substitution Principle - Nguyên tắc thay thế Liskov
- class con kế thừa class cha không được lỗi logic, không được làm thay đổi tính đúng đắn của chương trình
- nghĩa là khi kế thừa class cha,
 class con phải tuân theo các quy tắc của class cha, không được làm thay đổi các quy tắc đó, không được làm thay đổi các thuộc tính, các phương thức của class cha, không được làm thay đổi các hành vi của class cha, v.v.

- Tập trung vào: class con, không tập trung vào: class cha, v.v.
- tập trung vào : kế thừa ( inheritance ) và khả năng thay thế (substitution), không tập trung vào : interface


*/

public class Bird
{
    public string Name { get; set; }
    
    // eat
    public virtual void Eat()
    {
        Console.WriteLine($"{Name} is eating");
    }
    // sleep
    public virtual void Sleep()
    {
        Console.WriteLine($"{Name} is sleeping");
    }
}

public interface IFly
    {
        void Fly();
    }

public class Sparrow : Bird, IFly
{
    
    public void Fly()
    {
        Console.WriteLine($"{Name} is flying");
    }

}

public class Penguin : Bird
{
    // public override void Fly()
    // {
    //     // do nothing, because penguin cannot fly
    //     Console.WriteLine($"{Name} cannot fly");
    // }
}


