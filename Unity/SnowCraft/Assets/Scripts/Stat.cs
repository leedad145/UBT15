using System;
using UnityEngine;

public class Stat : MonoBehaviour
{
    private int _hp;
    public event Action OnDead;
    public Stat(int hp = 3)
    {
        _hp = hp;
    }
    public void Attacked()
    {
        _hp--;
        if(_hp <= 0)
            OnDead?.Invoke();
    }
}
