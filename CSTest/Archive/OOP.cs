using System.Linq.Expressions;

public class OOP
{
    static public void RunTest()
    {
        Test();
    }

    static void Test()
    {
        Car car = new Car();
        car.Repair();
    }
}

class Car
{
    public Engine engine = new Engine();
    public Battery battery = new Battery();

    public void Repair()
    {
        engine.Check();
        battery.Disconectied();
    }
}
class Engine
{
    public void Check()
    {
        Console.WriteLine("점화 플러그 확인");
        Console.WriteLine("연료 공급");
    }
}
class Battery
{
    public void Disconectied()
    {
        Console.WriteLine("베터리 분리");
    }
}