using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        if(cc == null)
        {
            cc = cc.AddComponent<CharacterController>();
        }
    }
    void Update()
    {
        move();
        rotate();
        fire();
    }

    #region move
    public float moveSpeed = 7f;
    float gravity = -20f;
    float yVelocity = 0f;
    void move()
    {
        Logger.Log("무브");
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3 (h, 0, v);
        dir = dir.normalized;
        dir = Camera.main.transform.TransformDirection(dir);

        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * moveSpeed * Time.deltaTime);
    }
    #endregion move
    #region rotate
    public float rotSpeed = 720f;

    float mx = 0;

    void rotate()
    {
        Logger.Log("회전");
        float mouse_X = Input.GetAxis("Mouse X");

        mx += mouse_X * rotSpeed * Time.deltaTime;


        transform.eulerAngles = new Vector3(0, mx, 0);
    }
    #endregion rotate
    #region fire
    public float throwPower = 15f;
    GameObject bombFactory;
    void fire()
    {
        bombFactory = Resources.Load<GameObject>("Prefabs/Bomb");
        if (Input.GetMouseButtonDown(0))
        {
            Logger.Log("파이어");

            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = transform.position;
            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
        }
    }
    #endregion fire
}
