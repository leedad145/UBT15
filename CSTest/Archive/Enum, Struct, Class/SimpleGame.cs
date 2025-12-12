public class SimpleGame
{
    enum ClassType
    {
        None,
        Knight,
        Mage,
        Rogue
    }
    enum ClassMonster
    {
        None,
        Slime,
        Orc,
        Skeleton
    }
    struct Player
    {
        public int hp;
        public int atk;
    }

    struct Monster
    {
        public int hp;
        public int atk;
    }

    static SimpleGame()
    {
        ClassType choice = ClassType.None;

        Player player;

        while (true)
        {
            choice = ClassChoice();
            if (choice != ClassType.None)
            {
                CreatePlayer(choice, out player);

                Console.WriteLine($"HP {player.hp}, ATK {player.atk}");

                Monster monster;
                CreateRandomMonster(out monster);
                Console.WriteLine($"HP {monster.hp}, ATK {monster.atk}");
            }
        }
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

    static void CreatePlayer(ClassType choice, out Player player)
    {
        switch(choice) // Knight(100/10), Mage(50/15), Rogue(75/12)
        {
            case ClassType.Knight:
                player.hp = 100;
                player.atk = 10;
                break;
            case ClassType.Mage:
                player.hp = 50;
                player.atk = 15;
                break;
            case ClassType.Rogue:
                player.hp = 75;
                player.atk = 12;
                break;
            default:
                player.hp = 0;
                player.atk = 0;
                break;
        }
    }
    static void CreateRandomMonster(out Monster monster)
    {
        Random rand = new Random();
        ClassMonster monsterChoice = (ClassMonster)rand.Next(1, 4); // 1 ~ 3 의 랜덤 값을 넣어짐
        switch (monsterChoice) // Slime(20/2), Orc(40/4), Skeleton(30/3)
        {
            case ClassMonster.Slime:
                monster.hp = 20;
                monster.atk = 2;
                break;
            case ClassMonster.Orc:
                monster.hp = 40;
                monster.atk = 4;
                break;
            case ClassMonster.Skeleton:
                monster.hp = 30;
                monster.atk = 3;
                break;
            default:
                monster.hp = 0;
                monster.atk = 0;
                break;
        }
    }
}


