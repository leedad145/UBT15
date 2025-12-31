using System;

public struct Health
{
    readonly int _maxHp;
    readonly int _currentHp;
    public Health(int maxHp, int currentHp)
    {
        _maxHp = maxHp;
        _currentHp = currentHp;
    }
    public Health Attacked(int damage)
    {
		return new Health(_maxHp, Math.Clamp(_currentHp - damage, 0, _maxHp)); 
    }
    public Health Recovered(int heal)
    {
        return new Health(_maxHp, Math.Clamp(_currentHp + heal, 0, _maxHp));
    }
    public bool IsDead()
    {
        return _currentHp <= 0;
    }
}
