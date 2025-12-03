public class Wizard
{
    // =======================================
    // 1. Wizard 클래스를 만들어 다음 조건을 만족하세요:
    // 
    // - 멤버 변수: mp, intelligence (둘 다 int형)
    // - 생성자에서 각각 50, 20으로 초기화
    // - Main()에서 Wizard 객체를 생성하고 두 값을 출력
    //
    // [실행 결과]
    // 마법사의 MP: 50, 지능: 20
    // =======================================
    int mp;
    int intelligence;

    public Wizard()
    {
        this.mp = 50;
        this.intelligence = 20;
        Console.WriteLine($"마법사의 MP: {this.mp}, 지능: {this.intelligence}");
    }
}
