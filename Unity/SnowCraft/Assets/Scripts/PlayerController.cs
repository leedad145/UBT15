using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Controller
{
    float _power = 0f;
    Slider _powerGauge;
    void Start()
    {
        gameObject.GetOrAddComponent<CircleCollider2D>();
        GameObject _powerGaugePrefab = Resources.Load<GameObject>("PowerGauge");
        
        _powerGauge = Instantiate(_powerGaugePrefab).GetComponent<Slider>();
        _powerGauge.transform.SetParent(GameObject.Find("Canvas").transform);
    }
    public void OnMouseDown()
    {
        _power = 0;
        _powerGauge.gameObject.SetActive(true);

    }

    public void OnMouseDrag()
    {
        Vector3 mousePos = Input.mousePosition;
        _power += Time.deltaTime;
        _power = Mathf.Min(_power,1.5f);
        _powerGauge.value = _power / 1.5f;

        _powerGauge.transform.position = mousePos + Vector3.right*100;
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
    public void OnMouseUp()
    {
        Debug.Log(_power);
        Attack(_power);
        _powerGauge.gameObject.SetActive(false);
    }
    public override void OnDead()
    {
        Destroy(_powerGauge.gameObject);
        Destroy(gameObject);
    }
}
