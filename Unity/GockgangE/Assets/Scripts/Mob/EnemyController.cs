using UnityEngine;
public class EnemyController : Mob
{
    Transform Player;
    public float detectionRange = 5f; // 플레이어 감지 범위
    public float stopRange = 1f; // 멈추기
    public float attackRange = 1f;  // 공격 범위
    public float attackCooldown = 1.5f; // 공격 쿨다운
    private float lastAttackTime;

    void Start()
    {
        Player = GameObject.Find("Player").transform;
        
        switch(name){
            case "FlyingEye":
            case "FlyingEye(clone)":
                detectionRange = 5f;
                SetStatus(10, 6, 3f, 10);
                break;
            case "Goblin":
            case "Goblin(clone)":
                detectionRange = 10f;
                SetStatus(20, 4, 2f, 6);
                break;
            case "Mushroom":
            case "Mushroom(clone)":
                detectionRange = 20f;

                SetStatus(50, 2, 0.5f, 4);
                break;
            case "Skeleton":
            case "Skeleton(clone)":
                detectionRange = 10f;
                SetStatus(15, 5, 1f, 2);
                break;

        }
    }

    void Update()
    {
        if(_mobState == MobState.Dead)
            return;
            
        SetAnim();

        if (Player == null) return;

        float distance = Vector3.Distance(transform.position, Player.position);

        if (distance <= detectionRange)
        {
            // 감지 범위 내: 플레이어 따라가기 (Mob의 Move 사용)
            if (stopRange <= distance)
            {
                Vector2 direction = (Player.position - transform.position).normalized;
                Move(direction.x); // Mob의 Move 메서드 사용
            }

            // 공격 범위 내 공격
            if (distance <= attackRange && Time.time >= lastAttackTime + attackCooldown)
            {
                Attack(new Vector2(0.5f, 0.5f), "Player");
                lastAttackTime = Time.time;
            }
        }
    }
    public override void Dead()
    {
        base.Dead();
        Destroy(col2D);
        Destroy(rb);
    }
}
