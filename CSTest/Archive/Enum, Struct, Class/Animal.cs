abstract public class Animal
{
    string name;
    public Animal(string name)
    {
        this.name = name;
        Console.WriteLine($"안녕하세요 저는 {name}입니다.");
    }
    abstract public void MakeSound();
}

class Dog : Animal
{
    public Dog(string name) : base(name)
    {
        
    }

    public override void MakeSound()
    {
        Console.WriteLine("멍멍!");
    }
}
class Cat : Animal
{
    public Cat(string name) : base(name)
    {
        
    }

    public override void MakeSound()
    {
        Console.WriteLine("야옹~");
    }
}
class Cow : Animal
{
    public Cow(string name) : base(name)
    {
        
    }

    public override void MakeSound()
    {
        Console.WriteLine("음머~");
    }
}