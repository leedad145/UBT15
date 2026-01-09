class Program
{    
    static void Main(string[] args)
    {
        int a = 10;
        MyClass.Func(a);
    }
}
public static class MyClass
{
    public static T Func<T>(T param)
    {
        return param;
    }
}
