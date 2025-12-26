using TMPro;
using UnityEngine;

public class Stat : MonoBehaviour
{
    [SerializeField]
    protected int _level;
    [SerializeField]
    protected int _hp;
    [SerializeField]
    protected int _maxHp;
    [SerializeField]
    protected int _attack;
    [SerializeField]
    protected int _defense;
    [SerializeField]
    protected float _moveSpeed;
    [SerializeField]
    protected bool _isDead;
    public int Level { get { return _level; } set { _level = value; } }
    public int Hp { get { return _hp; } set { _hp = Mathf.Clamp(value,0,MaxHp); } }
    public int MaxHp { get { return _maxHp; } set { _maxHp = value; } }
    public int Attack { get { return _attack; } set { _attack = value; } }
    public int Defense { get { return _defense; } set { _defense = value; } }
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    public bool IsDead { get {return _isDead; } }

    private void Start()
    {
        _level = 1;
        _hp = 100;
        _maxHp = 100;
        _attack = 10;
        _defense = 5;
        _moveSpeed = 5.0f;
        _isDead = false;
    }

    public virtual void OnAttacked(Stat attacker)
    {
		int damage = Mathf.Max(0, attacker.Attack - Defense);
		Hp -= damage;
        if (Hp <= 0)
        {
            Hp = 0;
            OnDead(attacker);
        }   
    }

    protected virtual void OnDead(Stat attacker)
    {
		PlayerStat playerStat = attacker as PlayerStat;
		if (playerStat != null)
		{
            playerStat.Exp += 15;
		}
        _isDead = true;
    }
}
