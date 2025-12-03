
public class Homework1
{

    public static void RunTest()
    {
        Console.WriteLine();question1();
        Console.WriteLine();question2();
        Console.WriteLine();question3();
        Console.WriteLine();question4();
        Console.WriteLine();question5();
        Console.WriteLine();question6();
        Console.WriteLine();question7();
        Console.WriteLine();question8();
        Console.WriteLine();question9();
        Console.WriteLine();question10();
        Console.WriteLine();question11();
    }
    public static void question1()
    {
        /*
        자기소개 프로그램
        이름(string), 나이(int), 키(float)를 저장할 변수를 선언하고 본인의 정보를 할당(변수에 대입)한 뒤, 
        Console.WriteLine을 사용하여 "이름: 홍길동, 나이: 99세, 키:180cm" 의 문장 형태로 출력하는 코드를 작성하세요.
        */
        string name = "이재영";
        int age = 25;
        float height = 184.12f;
        Console.WriteLine($"이름: {name}, 나이: {age}세, 키: {height}cm");
    }
    public static void question2()
    {
        /*
        문자열 합치기
        두 개의 문자열 변수 str1, str2, str3에 각각 "C#과", "유니티는", "너무쉽다" 를 저장합니다.
        + 연산자, 스트링포맷, 스트링인터폴레이션 방법을 사용하여 세 문자열을 이어 붙인 결과를 출력하세요. 
        (출력 예: 
        C#과 유니티는 너무쉽다
        C#과 유니티는 너무쉽다
        C#과 유니티는 너무쉽다
        */
        string str1 = "C#과";
        string str2 = "유니티는";
        string str3 = "너무쉽다";
        Console.WriteLine(str1+str2+str3);
        Console.WriteLine("{0}{1}{2}",str1,str2,str3);
        Console.WriteLine($"{str1}{str2}{str3}");

    }
    public static void question3()
    {
        /*
        사각형의 넓이와 둘레
        가로(width)와 세로(height) 길이를 저장할 float 형 변수 두 개를 선언하고 값을 대입합니다. 
        (가로 : 10.5, 세로 : 5.5) 이 사각형의 넓이(가로 * 세로)와 둘레((가로 + 세로) * 2)를 계산하여 출력하세요.
        */
        float width = 10.5f;
        float height = 5.5f;
        Console.WriteLine($"넓이: {width * height}, 둘레: {(width + height) * 2}");
    }
    public static void question4()
    {
        /*
        증감 연산자 테스트
        변수 a에 10을 저장합니다.
        a++를 한 번 실행한 후 출력하고, 그 다음 줄에 ++a를 실행한 후 출력하여 값이 어떻게 변하는지 확인하는 코드를 작성하세요.
        */
        int a = 10;
        Console.WriteLine(a++);
        Console.WriteLine(++a);
    }
    public static void question5()
    {
        /*  
        비교 연산자 결과 확인
        int number = 30; 변수를 선언합니다.
        이 숫자가 20보다 크고 50보다 작은지 확인하는 비교/논리 연산 식을 작성하여 결과를 true 또는 false로 출력하세요.
        */
        int number = 30;
        Console.WriteLine(20 < number && 50 > number);
    }
    public static void question6()
    {
        /*
        놀이공원 입장 조건 (AND)
        int height = 115; (키), int age = 15; (나이) 변수를 선언합니다.
        키가 120 이상이고, 나이가 12살 이상이어야만 true가 나오도록 논리 연산을 작성하세요.
        */
        int height = 115;
        int age = 15;
        Console.WriteLine(120 <= height && 12 <= age);
    
    }
    public static void question7()
    {
        /*
        할인 대상 여부 (OR)
        int age = 70; 변수를 선언합니다.
        나이가 65세 이상이거나, 8세 미만이면 true가 나오도록 논리 연산을 작성하세요.
        */
        int age = 70;
        Console.WriteLine(65 <= age || 8 > age);
    }
    public static void question8()
    {
        /*
        양수/음수 판별
        int myNumber = -5; 변수를 선언합니다
        if문을 사용하여 이 숫자가 양수면 "양수", 음수면 "음수", 0이면 "0"을 출력하세요.
        */
        int myNumber = -5;
        if (myNumber > 0)
            Console.WriteLine("양수");
        else if (myNumber < 0)
            Console.WriteLine("음수");
        else
            Console.WriteLine("0");
    }
    public static void question9()
    {
        /*
        짝수/홀수 판별
        int val = 17; 변수를 선언합니다.
        이 숫자를 2로 나눈 나머지를 이용해 짝수인지 홀수인지 판별하여 문자열을 출력하세요.
        */
        int val = 17;
        if (val % 2 == 0)
            Console.WriteLine("짝수");
        else
            Console.WriteLine("홀수");


    }
    public static void question10()
    {
        /*
        세 수 중 가장 큰 수 찾기
        int a = 10;, int b = 20;, int c = 5; 변수를 선언합니다.
        if문을 활용하여 세 변수 중 가장 큰 값을 찾아내어 출력하세요.
        */
        int a = 10;
        int b = 20;
        int c = 5;
        if (a >= b && a >= c)       Console.WriteLine("a");
        else if (b >= a && b >= c)  Console.WriteLine("b");
        else if (c >= a && c >= b)  Console.WriteLine("c");
    }
    public static void question11()
    {
        /*
        윤년 판별 (로직)
        int year = 2024; 변수를 선언합니다.
        윤년 조건: (4로 나누어떨어짐 AND 100으로 안 나누어떨어짐) OR (400으로 나누어떨어짐)
        위 조건에 맞으면 "윤년", 아니면 "평년"을 출력하세요.
        */
        int year = 2024;
        if ((year % 4 == 0) && (year % 100 != 0))   Console.WriteLine("윤년");
        else                                        Console.WriteLine("평년");
    }
}