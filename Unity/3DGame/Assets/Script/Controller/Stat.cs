using System;

public class Stat
{
    readonly int _level;
    Health _health;
    readonly int _attack;
    readonly int _defense;
    readonly float _moveSpeed;

    public int Level { get { return _level; } }
    public Health Health { get { return _health; } }
    public int Attack { get { return _attack; } }
    public int Defense { get { return _defense; } }
    public float MoveSpeed { get { return _moveSpeed; } }
    
    public event Action OnDead;
    public event Action OnAttacked;

    public Stat(int level, int maxHealth, int attack, int defense, float moveSpeed)
    {
        _level = level;
        _health = new Health(maxHealth, maxHealth);
        _attack = attack;
        _defense = defense;
        _moveSpeed = moveSpeed;
    }

    public void TakeDamage(int damage)
    {
        damage = Math.Max(damage - _defense, 1);
        _health = _health.Attacked(damage);
        if (_health.IsDead())
        {
            OnDead?.Invoke();
        }
        else
        {
            OnAttacked?.Invoke();
        }
    }
}
