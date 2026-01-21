using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Controller
{
    float _power = 0f;
    Slider _powerGauge;
    public event Action OnGameEnd;
    float _curTime;
    void Start()
    {
        gameObject.GetOrAddComponent<CircleCollider2D>();
        GameObject _powerGaugePrefab = Resources.Load<GameObject>("PowerGauge");
        
        _powerGauge = Instantiate(_powerGaugePrefab).GetComponent<Slider>();
        _powerGauge.transform.SetParent(GameObject.Find("Canvas").transform);
        _curTime = 0;
        transform.position = new Vector3(10,0,0);
    }
    void Update()
    {
        _curTime += Time.deltaTime;
        if(_curTime < 0.7f)   
            transform.position += Vector3.left * 5 * Time.deltaTime;
    }
    public void OnMouseDown()
    {
        _power = 0;
        _powerGauge.value = 0f;
        _powerGauge.gameObject.SetActive(true);
    }

    public void OnMouseDrag()
    {
        Vector3 mousePos = Input.mousePosition;
        _power += Time.deltaTime * 1.5f;
        _power = Mathf.Min(_power,1.5f);
        _powerGauge.value = _power / 1.5f;

        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        mousePos.x = MathF.Max(mousePos.x, 1000);
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        _powerGauge.transform.position = mousePos + Vector3.right*100;
    }
    public void OnMouseUp()
    {
        Debug.Log(_power);
        Attack(_power);
        _powerGauge.gameObject.SetActive(false);
    }
    public override void Dead()
    {
        Destroy(_powerGauge.gameObject);
        OnGameEnd?.Invoke();
        Destroy(gameObject);
    }
}
