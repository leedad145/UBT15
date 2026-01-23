using UnityEngine;
public enum MobState
{
    Idle,
    Run,
    Attack,
    Jump,
    Dead,

}
public class Mob : MonoBehaviour
{
    public int Hp {get; set;} = 100;
    public int MaxHp {get; set;} = 100;
    protected int _atkDmg = 10;
    protected float _moveSpd = 4f;
    protected float _jumpPower = 5f;  // 점프 힘
    protected MobState _mobState = MobState.Idle;
    protected int _dropGold = 10;
    protected Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer;
    protected Animator _anim;
    protected Collider2D col2D;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    // Mob의 status를 설정하는 함수
    protected void SetStatus(int hp, int atkDmg, float moveSpd, float jumpPower)
    {
        Hp = hp;
        MaxHp = hp;
        _atkDmg = atkDmg;
        _moveSpd = moveSpd;
        _jumpPower = jumpPower;
    }
    public void Attacked(int atkDmg)
    {
        Hp -= atkDmg;
        if(Hp <= 0)
        {
            Dead();
        }
    }
    public void SetAnim()
    {
        _anim.SetInteger("State", (int)_mobState);
    }
    public virtual void Dead()
    {
        Debug.Log($"{name}: 죽음");
        _mobState = MobState.Dead;
        SetAnim();
        GameManager.Instance.AddGold(_dropGold);
    }
    public virtual void Move(float x)
    {
        transform.Translate(Vector3.right * x * _moveSpd * Time.deltaTime);
        
        // Jump 상태이고 공중에 있으면 Jump 상태 유지
        if (!IsGruond())
        {
            _mobState = MobState.Jump;
        }
        else if (x != 0)
        {
            _mobState = MobState.Run;
        }
        else
        {
            _mobState = MobState.Idle;
        }
        
        if (x > 0)
            spriteRenderer.flipX = false; // 오른쪽 이동 시 원래 방향
        else if (x < 0)
            spriteRenderer.flipX = true; // 왼쪽 이동 시 반전
    }
    public virtual bool IsGruond() 
    {
        RaycastHit2D boxcastHit = Physics2D.BoxCast(col2D.bounds.center, col2D.bounds.size * 0.9f, 0f, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
        return boxcastHit.collider != null;
    }
    public virtual void Jump()
    {
        _mobState = MobState.Jump;
        rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
    }
    public virtual void Attack(Vector2 size, string layerName = "Enemy")
    {
        _mobState = MobState.Attack;
        RaycastHit2D[] boxcastHit = Physics2D.BoxCastAll(
            col2D.bounds.center,        // 시작 위치 (콜라이더 중심)
            size,                                   // 박스 크기
            0f,                                         // 박스 회전 각도
            spriteRenderer.flipX ? -transform.right : transform.right, // 나아가는 방향
            1,                          // 나아가는 거리
            LayerMask.GetMask(layerName) // 감지할 레이어
        );
        foreach(var hit in boxcastHit)
        {
            if (layerName == "Enemy")
            {
                EnemyController ec = hit.transform.GetComponent<EnemyController>();
                if(ec != null)
                {
                    ec.Attacked(_atkDmg);   
                }
            }
            else if (layerName == "Player")
            {
                PlayerController pc = hit.transform.GetComponent<PlayerController>();
                if(pc != null)
                {
                    pc.Attacked(_atkDmg);   
                }
            }
        }
    }
}
