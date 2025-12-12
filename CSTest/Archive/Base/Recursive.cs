public class Recursive
{
    static Recursive()
    {
        Console.WriteLine(Sum(1,6));
    }
    static int Sum(int start, int end)
    {
        if ( start <= end)
            return Sum(start + 1, end) + start;
        return 0;
    }
}