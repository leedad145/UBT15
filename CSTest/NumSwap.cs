public class NumSwap
{
    public static void RunTest()
    {
        int a = 10;
        int b = 20;
        Console.Write($"{a}, {b} -(Swap)-> ");

        Swap(ref a, ref b);

        Console.WriteLine($"{a}, {b}");
    }
    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}