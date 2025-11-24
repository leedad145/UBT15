public class CharString
{
    public static void RunTest()
    {
        char a = 'A';
        char b = 'B';
        Console.WriteLine($"{a}, {b}");
        string s1 = "이재영";
        string s2 = @"
            안녕하세요
            반갑습니다.
            ";                   //@를 붙이면 문자열 자체를 그대로 저장
        Console.WriteLine($"{s1}, {s2}");

        string msg = string.Format($"{s1}, {s2}");
        Console.WriteLine(msg);

    }
}