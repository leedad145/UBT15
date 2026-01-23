using UnityEngine;

public class PlayerController : Mob
{
    public float attackCooldown = 0.5f; // 공격 쿨다운
    private float lastAttackTime;
    void Start()
    {
        _dropGold = 0;
    }
    void Update()
    {
        if(_mobState == MobState.Dead)
            return;
        if (Time.time <= lastAttackTime + attackCooldown)
            return;

        Move(Input.GetAxisRaw("Horizontal"));

        if (IsGruond())
        {
            if (Input.GetButtonDown("Jump"))
            Jump();

            if (Input.GetButtonDown("Fire1"))
            {
                lastAttackTime = Time.time;
                Attack(Vector2.one);
            }
        }
        SetAnim();
    }
    public void Heal(int value)
    {
        Hp = Mathf.Min(Hp + value, MaxHp);
    }
    public void ApplyItem(Item item)
    {
        // 플레이어 스텟 증가
        MaxHp += item._hpIncrease;
        Hp += item._hpIncrease;
        _atkDmg += item._atkDmgIncrease;
        _moveSpd += item._moveSpdIncrease;
        _jumpPower += item._jumpPowerIncrease;

        Debug.Log($"[Item Applied] HP: +{item._hpIncrease}, ATK: +{item._atkDmgIncrease}, " +
                  $"Speed: +{item._moveSpdIncrease}, Jump: +{item._jumpPowerIncrease}");
    }
}
