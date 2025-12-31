using System.Runtime.Serialization;

class Program
{    
    static void Main(string[] args)
    {
        GameEntities.Player player = new GameEntities.Player("Hero", 100);
        player.TakeDamage(50);
        Console.WriteLine($"Player Health: {player.Hp.CurrentHealth}");
        player.TakeDamage(60);
        Console.WriteLine($"Player Health: {player.Hp.CurrentHealth}");
    }
}
namespace GameEntities
{
    class Health
    {
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; private set; }

        public Health(int maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth < 0)
                CurrentHealth = 0;
        }

        public void Heal(int amount)
        {
            CurrentHealth += amount;
            if (CurrentHealth > MaxHealth)
                CurrentHealth = MaxHealth;
        }
        public bool IsDead()
        {
            return CurrentHealth <= 0;
        }
        public void DeadEvent()
        {
            Console.WriteLine("Player is dead.");
        }
    }
    class Player
    {
        public string Name { get; private set; }
        public Health Hp { get; private set; }
        public event Action OnDead;

        public Player(string name, int maxHealth)
        {
            Name = name;
            Hp = new Health(maxHealth);
            OnDead -= Hp.DeadEvent;
            OnDead += Hp.DeadEvent;
        }
        public void TakeDamage(int damage)
        {
            Hp.TakeDamage(damage);
            if(Hp.IsDead())
            {
                OnDead?.Invoke();
            }
        }   
    }
}
