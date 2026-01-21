using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Define.PlayerState _state = Define.PlayerState.Idle;

    [SerializeField]
    private Stat _stat = new Stat(1, 100, 10, 5, 5f);
    public Stat Stat => _stat;

    private CharacterController _cc;
    private Animator _animator;
    private readonly int _stateHash = Animator.StringToHash("State");

    [Header("Prefabs")]
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private GameObject weaponPrefab;

    [Header("Settings")]
    [SerializeField] private float throwPower = 15f;

    // Movement
    private float gravity = -20f;
    private float yVelocity = 0f;

    private bool isInventoryOpen = false;

    private void Start()
    {
        _cc = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _state = Define.PlayerState.Idle;
    }

    private void Update()
    {
        HandleInput();
        UpdateAnimator();
    }

    private void HandleInput()
    {
        // Priority: attack / fire / inventory toggle -> movement
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
            return;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Fire();
            return;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            PopupInventory();
            return;
        }

        _state = Move();
    }

    private void UpdateAnimator()
    {
        if (_animator != null)
            _animator.SetInteger(_stateHash, (int)_state);
    }

    #region Move
    private Define.PlayerState Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);

        if (dir.magnitude < 0.1f)
        {
            // Apply gravity while idle
            if (_cc != null && _cc.isGrounded)
                yVelocity = 0f;
            else
                yVelocity += gravity * Time.deltaTime;

            return Define.PlayerState.Idle;
        }

        dir = dir.normalized;
        dir = Camera.main.transform.TransformDirection(dir); // Keeping Camera usage as requested
        dir.y = 0f;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 720f * Time.deltaTime);

        if (Physics.Raycast(transform.position, dir, 1f))
            return Define.PlayerState.Idle;

        if (_cc != null)
        {
            if (_cc.isGrounded)
                yVelocity = 0f;
            else
                yVelocity += gravity * Time.deltaTime;

            dir.y = yVelocity;
            _cc.Move(dir * _stat.MoveSpeed * Time.deltaTime);
        }

        return Define.PlayerState.Run;
    }
    #endregion
    #region Fire
    private void Fire()
    {
        GameObject bomb = Managers.Resource.Instantiate("Prefabs/Bomb", transform);

        bomb.transform.position = transform.position + Vector3.up;
        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        if (rb != null)
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);

        _state = Define.PlayerState.Attack;
    }
    #endregion
    #region Attack
    private void Attack()
    {
        GameObject weapon = Managers.Resource.Instantiate("Prefabs/Weapon", transform);

        weapon.transform.position = transform.position + Camera.main.transform.TransformDirection(1, 1, 0);
        weapon.transform.rotation = Camera.main.transform.rotation;
        _state = Define.PlayerState.Attack;
    }
    
    #endregion Attack
    public int GetAtkDmg()
    {
        return _stat.Attack;
    }
    public void PopupInventory()
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
