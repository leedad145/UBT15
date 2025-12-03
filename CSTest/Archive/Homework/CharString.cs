public class CharString
{
    public static void RunTest()
    {
        /*
        char a = 'A';
        char b = 'B';
        Console.WriteLine($"{a}, {b}");
        string s1 = "이재영";
        string s2 = @"
            안녕하세요
            반갑습니다.
            ";                   //@를 붙이면 문자열 자체를 그대로 저장 \도 그대로 저장
        Console.WriteLine($"{s1}, {s2}");

        string msg = string.Format($"{s1}, {s2}");
        Console.WriteLine(msg);
        */
        string someStringWithSpace = "  Hello World!    ";
        Console.WriteLine(someStringWithSpace.Trim());
        Console.WriteLine(someStringWithSpace.TrimStart());
        Console.WriteLine(someStringWithSpace.TrimEnd());
        
        string someString = "Hello World";
        Console.WriteLine(someString.Replace("World", "Prigramming"));
        Console.WriteLine(someString.ToUpper());
        Console.WriteLine(someString.ToLower());
        Console.WriteLine(someString.Substring(3,5));
        //Console.WriteLine(someString.Substring(3,200)); //<<Length를 넘어가면 안됨
        
        string msg = "Hello";
        Console.WriteLine(msg[^1]); // msg.Length - 1과 같다, 만약 ^4라면 msg.Length - 4
    }
}