class Character
{
    public string Name;
    public int Hp;
    public int Atk;
    public Character()
    {
        
    }
    public Character(string Name, int Hp, int Atk)
    {
        
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
    public Player(string name, int hp, int atk)
    {
        
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