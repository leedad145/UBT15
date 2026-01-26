using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

public class GameManager : MonoBehaviour
{
    static GameManager _instance { get; set; }

    public static GameManager Instance { get{ Init(); return _instance;}}

    // Gold System
    public int _gold;
    private TextMeshProUGUI _goldText;
    
    public GameObject PlayerPrefab;
    public GameObject GoblinPrefab;
    public GameObject FlyingEyePrefab;



    // PlayerHpBar System

    private Transform _playerTransform;
    private Slider _hpSlider;
    private Text _hpText;
    private PlayerController _playerController;

    Transform canvas;
    void Awake()
    {
        Init();
        canvas = transform.Find("Canvas");
        if(canvas == null)
        {
            Debug.LogError("GameManager: Canvas를 찾을 수 없습니다. @GameManager Prefab에 Canvas가 있는지 확인하세요.");
            return;
        }
        canvas.gameObject.SetActive(false);

        // Gold 초기화
        Transform goldTransform = canvas.transform.Find("Gold");
        if(goldTransform != null)
            _goldText = goldTransform.GetComponent<TextMeshProUGUI>();
        
        // PlayerHpBar 초기화
        Transform hpBarTransform = canvas.transform.Find("PlayerHpBar");
        if(hpBarTransform != null)
        {
            _hpSlider = hpBarTransform.GetComponent<Slider>();
            Transform hpTextTransform = _hpSlider.transform.Find("HpText");
            if(hpTextTransform != null)
                _hpText = hpTextTransform.GetComponent<Text>();
        }

        PlayerPrefab = Resources.Load<GameObject>("Prefabs/Player");
        GoblinPrefab = Resources.Load<GameObject>("Prefabs/Goblin");
        FlyingEyePrefab = Resources.Load<GameObject>("Prefabs/FlyingEye");
    }
    public void CanvasSetActive(bool set)
    {
        if(canvas == null)
        {
            Debug.LogError("GameManager: Canvas가 null입니다.");
            return;
        }
        canvas.gameObject.SetActive(set);
    }
    static void Init()
    {
        if (_instance == null)
        {
			GameObject go = GameObject.Find("@GameManager");
            if (go == null)
            {
                // Resources에서 GameManager Prefab 로드 시도
                GameObject prefab = Resources.Load<GameObject>("Prefabs/@GameManager");
                if (prefab != null)
                {
                    go = Instantiate(prefab);
                    go.name = "@GameManager";
                }
                else
                {
                    // Prefab이 없으면 동적으로 생성
                    go = new GameObject { name = "@GameManager" };
                    go.AddComponent<GameManager>();
                }
            }

            DontDestroyOnLoad(go);
            _instance = go.GetComponent<GameManager>();
        }
    }

    static void EnsureEventSystem()
    {
        // UI 클릭이 안 되는 대부분의 원인: 씬에 EventSystem이 없음
        if (Object.FindFirstObjectByType<EventSystem>() != null)
            return;

        var esGo = new GameObject("EventSystem");
        esGo.AddComponent<EventSystem>();
        esGo.AddComponent<InputSystemUIInputModule>();
        DontDestroyOnLoad(esGo);
    }
    public void InitAfterLoad() // 씬을 불러온 후, 호출해주어야함
    {
        EnsureEventSystem();

        // PlayerPrefab이 null이면 다시 로드 시도
        if(PlayerPrefab == null)
        {
            PlayerPrefab = Resources.Load<GameObject>("Prefabs/Player");
            if(PlayerPrefab == null)
            {
                Debug.LogError("PlayerPrefab을 로드할 수 없습니다. Resources/Prefabs/Player 경로를 확인하세요.");
                return;
            }
        }

        GameObject Player = GameObject.Find("Player");
        if(Player == null)
        {
            Player = SpawnMob(PlayerPrefab, Vector2.zero);
            if(Player == null)
            {
                Debug.LogError("Player 생성에 실패했습니다.");
                return;
            }
        }
        if(Camera.main.gameObject.GetComponent<FallowCam>() == null)
            Camera.main.gameObject.AddComponent<FallowCam>();
        _playerTransform = Player.transform;
        _playerController = _playerTransform.GetComponent<PlayerController>();
        if(_playerController == null)
        {
            Debug.LogError("PlayerController 컴포넌트를 찾을 수 없습니다.");
            return;
        }
        _playerController.Heal(_playerController.MaxHp);
        CanvasSetActive(true);
    }
    public GameObject SpawnMob(GameObject go, Vector2 pos)
    {
        if(go == null)
        {
            Debug.LogError("SpawnMob: Prefab이 null입니다.");
            return null;
        }
        GameObject _go = Instantiate(go);
        _go.name = go.name;
        _go.transform.position = pos;
        return _go;
    }
    
    void Update()
    {
        if(canvas == null || !canvas.gameObject.activeSelf)
            return;
        // Gold 업데이트
        if(_goldText != null)
            _goldText.text = $"{_gold} Gold";
        
        // PlayerHpBar 업데이트
        if(_hpSlider != null && _playerController != null)
        {
            _hpSlider.value = _playerController.Hp / (float)_playerController.MaxHp;
            if(_hpText != null)
                _hpText.text = $"{_playerController.Hp} / {_playerController.MaxHp}";
        }
    }
    
    public void AddGold(int gold)
    {
        _gold += gold;
    }

    public void SpendGold(int gold)
    {
        _gold -= gold;
        if (_gold < 0) _gold = 0;
    }
}
