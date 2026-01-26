using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    public Transform targetTransform;
    public Slider slider;
    void Awake()
    {
        targetTransform = GameObject.Find("Player").transform;
        slider = GetComponent<Slider>();
    }
    void Update()
    {
        PlayerController pc = targetTransform.GetComponent<PlayerController>();
        slider.value = pc.Hp / (float)pc.MaxHp;
    }
}
