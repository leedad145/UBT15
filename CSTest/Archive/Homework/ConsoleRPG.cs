
public class ConsoleRPG
{
    static public void RunTest()
    {
        Player player = new Player("이재영", 100, 10);
        Console.WriteLine($"플레이어 생성: {player.Name}/{player.Hp}/{player.Atk}");
        bool isFight = true;
        while (isFight)
        {
            Monster monster = new Monster();
            monster.Name = RandomName();
            Console.WriteLine($"몬스터 생성: {monster.Name}/{monster.Hp}/{monster.Atk}");

            while (!monster.IsDead() && !player.IsDead())
            {
                Console.WriteLine("----------------------------------");
                Console.Write($"{player.Name}공격 - {monster.Name} HP: {monster.Hp} -> ");
                player.Attack(monster);
                Console.WriteLine($"{Math.Max(0, monster.Hp)}");

                Console.Write($"{monster.Name}공격 - {player.Name} HP: {player.Hp} -> ");
                monster.Attack(player);
                Console.WriteLine($"{Math.Max(0, player.Hp)}");
                Console.WriteLine("----------------------------------");
            }
            if (player.IsDead())
            {
                Console.WriteLine("플레이어가 죽었습니다.");
                break;
            }
            player.GainExp(10);
            Console.WriteLine($"현재 경험치: {player.Exp}");

            Console.WriteLine("계속 싸우시겠습니까?(y/n): ");
            isFight = Console.ReadLine()?.Trim().ToLower() == "y" ? true : false;
        }
        
    }
    static string RandomName()
    {
        string[] names = { "슬라임", "고블린", "늑대", "박쥐" };
        return names[new Random().Next(names.Length)];
    }
}
class Character
{
    public string Name;
    public int Hp;
    public int Atk;
    public Character()
    {
        Name = "기본";
        Hp = 10;
        Atk = 1;
    }
    public Character(string Name, int Hp, int Atk)
    {
        this.Name = Name;
        this.Hp = Hp;
        this.Atk = Atk;
    }
    public virtual void Attack(Character target)
    {
        target.Hp -= Atk;
    }
    public bool IsDead()
    {
        if(Hp <= 0)
        {
            return true;
        }
        return false;
    }


}
class Player : Character
{
    public int Exp = 0;
    public Player(string Name, int Hp, int Atk)
    {
        this.Name = Name;
        this.Hp = Hp;
        this.Atk = Atk;
    }
    public void GainExp(int amount)
    {
        Exp += amount;
    }
}
class Monster : Character
{
    public Monster()
    {
        Random rand = new Random();
        Hp = rand.Next(20, 50);
        Atk = rand.Next(2, 6);
    }
}
