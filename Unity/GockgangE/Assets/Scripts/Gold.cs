using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour
{
    int _gold;
    TextMeshProUGUI tMPro;
    void Start()
    {
        tMPro = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        tMPro.text = $"{_gold} Gold";
    }
    public void AddGold(int gold)
    {
        _gold += gold;
    }
}
