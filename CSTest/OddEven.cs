public class OddEven
{
    public static void RunTest()
    {
        /*
        1~10 까지 출력하는데
        1 은 홀수 입니다.
        2 는 짝수 입니다.
        3 은 홀수 입니다.
        ...
        10은 짝수 입니다. 
        */
        for (int i = 1; i <= 10; i++)
        {
            string oddOrEven = i%2 != 0 ? "홀수" : "짝수";
            Console.WriteLine($"{i}는 {oddOrEven}입니다.");
        }
    }
}