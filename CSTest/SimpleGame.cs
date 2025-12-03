class SimpleGame
{
    enum ClassType
    {
        None,
        Knight,
        Mage,
        Rogue
    }

    static ClassType ClassChoice()
    {
        Console.WriteLine("직업을 선택하세요!");
        Console.WriteLine("[1] 기사");
        Console.WriteLine("[2] 마법사");
        Console.WriteLine("[3] 도둑");

        ClassType choice = ClassType.None;
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                choice = ClassType.Knight;
                break;
            case "2":
                choice = ClassType.Mage;
                break;
            case "3":
                choice = ClassType.Rogue;
                break;
        }

        return choice;
    }

    static void CreatePlayer(ClassType choice, out int hp, out int atk)
    {
        switch(choice) // 기사(100/10), 마법사(50/15), 도둑(75/12)
        {
            case ClassType.Knight:
                hp = 100;
                atk = 10;
                break;
            case ClassType.Mage:
                hp = 50;
                atk = 15;
                break;
            case ClassType.Rogue:
                hp = 75;
                atk = 12;
                break;
            default:
                hp = 0;
                atk = 0;
                Console.WriteLine($"입력범위를 벗어났습니다. 입력값: {choice}");
                break;
        }
    }

    static void RunTest()
    {
        ClassType choice = ClassType.None;

        while (true)
        {
            choice = ClassChoice();
            if (choice != ClassType.None)
            {
                // 캐릭터 생성
                int hp;
                int atk;
                CreatePlayer(choice, out hp, out atk);

                Console.WriteLine($"HP {hp}, ATK {atk}");
            }
        }
    }
}
