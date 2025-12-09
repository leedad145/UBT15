using UnityEngine;

enum Dir 
{
    Up,
    Down,
    Side,
}
enum State
{
    Idle,
    Walk,
    Attack,
}


public class Player : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    float time = 0;
    [SerializeField]
    float speed = 10f;
    Dir _dir;
    State _state;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdateInput();
        UpdateAnimation();
    }
    void UpdateInput()
    {
        time = Time.deltaTime;
        float px = Input.GetAxisRaw("Horizontal");
        float py = Input.GetAxisRaw("Vertical");

        if (py > 0)
        {
            _state = State.Walk;
            _dir = Dir.Up;
        }
        else if (py < 0)
        {
            _state = State.Walk;
            _dir = Dir.Down;
        }
        else if (px > 0)
        {
            _state = State.Walk;
            _dir = Dir.Side;
            spriteRenderer.flipX = false;
        }
        else if (px < 0)
        {
            _state = State.Walk;
            _dir = Dir.Side;
            spriteRenderer.flipX = true;
        }
        else
        {
            _state = State.Idle;
        }
        Vector3 direction = new Vector3(px, py, 0).normalized;

        transform.position += direction * speed * time;
        time = 0;
    }


    void UpdateAnimation()
    {
        animator.Play($"{_dir}{_state}");
    }
}
