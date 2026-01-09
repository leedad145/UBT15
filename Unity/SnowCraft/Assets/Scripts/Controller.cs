using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    Stat _stat;
    void Awake()
    {
        _stat = new Stat();
    }
    void Start()
    {
        _stat.OnDead += OnDead;
    }
    public virtual void Attack(float power, string target)
    {
        GameObject snowPrefab = Resources.Load<GameObject>("Snow");
        if (snowPrefab != null)
        {
            // Instantiate의 반환값을 사용
            GameObject snow = Instantiate(snowPrefab);
            Snow snowComponent = snow.GetComponent<Snow>();
            if (snowComponent != null)
            {
                snowComponent.Init(gameObject.layer, power, transform.position);
            }
        }
    }
    public void Attack(float power)
    {
        GameObject snowPrefab = Resources.Load<GameObject>("Snow");
        if (snowPrefab != null)
        {
            GameObject snow = Instantiate(snowPrefab);
            Snow snowComponent = snow.GetComponent<Snow>();
            if (snowComponent != null)
            {
                snowComponent.Init(gameObject.layer, power, transform.position);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.layer != other.gameObject.layer)
        {
            gameObject.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 100);
            _stat.Attacked();
        }
    }
    public virtual void OnDead()
    {
        Destroy(gameObject);
    }
}
