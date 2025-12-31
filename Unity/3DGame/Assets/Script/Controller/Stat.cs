using System;

public class Stat
{
    readonly int _level;
    Health _health;
    readonly int _attack;
    readonly int _defense;
    readonly float _moveSpeed;
    public event Action OnDead;
    public event Action OnAttacked;

    public Stat()
    {
        _level = 1;
        _health = new Health(10, 10);
        _attack = 10;
        _defense = 5;
        _moveSpeed = 5.0f;
    }
    public int Attack
    {
        get { return _attack; }
    }
    public float MoveSpeed
    {
        get { return _moveSpeed; }
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
