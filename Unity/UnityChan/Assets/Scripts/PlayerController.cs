using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private Vector3 direction;
    void Start()
    {
        //Managers.Input.KeyAction += OnKeyboard;
    }

    void Update()
    {
        if(direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.2f);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    // void OnKeyboard()
    // {
    //     transform.Translate(direction * speed * Time.deltaTime);
    // }
    public void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        if(v.magnitude > 0)
        {
            direction = new Vector3(v.x, 0, v.y);
        }
        else
        {
            direction = Vector3.zero;
        }
    }
    public void OnLook(InputValue value)
    {
        Debug.Log("보기");
    }
    public void OnAttack(InputValue value)
    {
        bool b = value.isPressed;
        Debug.Log("공격");
    }
}
