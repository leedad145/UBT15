public class Read
{
    public static void RunTest()
    {
        Console.Write("문자열을 입력 해 주세요.: ");
        string readString = Console.ReadLine();
        Console.WriteLine($"입력 한 문자열: {readString}");
    }
}