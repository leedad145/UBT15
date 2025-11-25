public class StarTree
{
    public static void RunTest()
    {
        for (int i = 5; i >= -5; i--)
        {
            int absi = Math.Abs(i);
            for (int j = absi; j > 0; j--)//절대값 i 
            {
                if (j == 1)Console.Write("*");
                else if(j == absi)Console.Write("1");
                else Console.Write("0");
            }
            Console.WriteLine();
        }
    }
}