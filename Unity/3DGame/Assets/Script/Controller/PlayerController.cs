using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Define.PlayerState _state;
    Stat _stat = new Stat(1, 100, 10, 5, 5f);
    public Stat Stat
    {
        get{return _stat;}
    }
    CharacterController _cc;
    Animator _animator;
    void Start()
    {
        _cc = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        Managers.Input.OnInputKey += fire;
        Managers.Input.OnInputKey += move;
        Managers.Input.OnInputKey += Attack;
        Managers.Input.OnInputKey += PopupInventory;
    }

    void Update()
    {
        _animator.SetInteger("State", (int)_state);
    }
    #region move
    float gravity = -20f;
    float yVelocity = 0f;
    void move(Define.InputEvent input)
    {
        if(input == Define.InputEvent.KeyPress)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 dir = new Vector3 (h, 0, v);
            dir = dir.normalized;
            dir = Camera.main.transform.TransformDirection(dir);
            dir.y = 0;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 720 * Time.deltaTime);
            if (Physics.Raycast(transform.position, dir, 1f))
                return;
            yVelocity += gravity * Time.deltaTime;
            dir.y = yVelocity;
            _cc.Move(dir * _stat.MoveSpeed * Time.deltaTime);
            _state = Define.PlayerState.Run;
        }
        else
        {
            _state = Define.PlayerState.Idle;
        }
    }
    #endregion move
    #region fire
    public float throwPower = 15f;
    GameObject bombFactory;
    void fire(Define.InputEvent mouse)
    {
        if (mouse == Define.InputEvent.RLClick)
        {
            bombFactory = Resources.Load<GameObject>("Prefabs/Bomb");

            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = transform.position + Vector3.up;
            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
            _state = Define.PlayerState.Attack;
        }
    }
    #endregion fire
    #region Attack
    GameObject weaponPrefab;
    void Attack(Define.InputEvent mouse)
    {
        if (mouse == Define.InputEvent.LUp)
        {
            weaponPrefab = Resources.Load<GameObject>("Prefabs/Weapon");

            GameObject weapon = Instantiate(weaponPrefab);
            weapon.transform.position = transform.position + Camera.main.transform.TransformDirection(1, 1, 0);
            weapon.transform.rotation = Camera.main.transform.rotation;
            _state = Define.PlayerState.Attack;
        }
    }
    
    #endregion Attack
    public int GetAtkDmg()
    {
        return _stat.Attack;
    }
    bool isInventoryOpen = false;
    public void PopupInventory(Define.InputEvent input)
    {
        if (input == Define.InputEvent.KeyPress && Input.GetKeyDown(KeyCode.I))
        {
            if (isInventoryOpen)
            {
                Managers.UI.ClosePopupUI();
                isInventoryOpen = false;
            }
            else
            {
                Managers.UI.ShowSceneUI<Inventory>();
                isInventoryOpen = true;
            }
        }
    }
}
