using UnityEngine;
using UnityEngine.UI;

public class FallowObject : MonoBehaviour
{
    public Transform targetTransform;
    public Slider slider;
    void Awake()
    {
        slider = GetComponent<Slider>();
    }
    void Update()
    {
        Vector3 worldPos = targetTransform.position + Vector3.up;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        screenPos.z = 1;
        transform.position = screenPos;

        // PlayerController나 EnemyController 중 하나를 가져옴
        EnemyController ec = targetTransform.GetComponent<EnemyController>();
        slider.value = ec.Hp / (float)ec.MaxHp;
    }
}
