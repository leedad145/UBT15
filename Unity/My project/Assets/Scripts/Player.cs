using UnityEngine;

enum Dir 
{
    Up,
    Down,
    Left,
    Right,
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
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector3 inputVector = new Vector3(inputX, inputY);

        if (inputVector.magnitude > 0)
        {
            Vector3 direction = inputVector.normalized;
            _state = State.Walk;

            if (direction == Vector3.up)
            {
                _dir = Dir.Up;
            }
            else if (direction == Vector3.down)
            {
                _dir = Dir.Down;
            }
            else if (direction == Vector3.left)
            {
                _dir = Dir.Left;
                spriteRenderer.flipX = true;
            }
            else if (direction == Vector3.right)
            {
                _dir = Dir.Right;
                spriteRenderer.flipX = false;
            }

            transform.position += direction * speed * time;
        }
        else
        {
            _state = State.Idle;
        }

        time = 0;
    }


    void UpdateAnimation()
    {
        if (_dir == Dir.Right || _dir == Dir.Left)
        {
            animator.Play($"Side{_state}");
        }
        else 
        {
            animator.Play($"{_dir}{_state}");
        }
    }
}
