using UnityEngine;
// 유니티 에디터 메뉴에서 Item생성
[CreateAssetMenu(fileName = "New Item", menuName = "Item/New Item")]
public class Item : ScriptableObject
{
    public string _itemName;
    public int _price;
    public string _description;
    
    // 플레이어 스텟 증가량
    public int _hpIncrease;
    public int _atkDmgIncrease;
    public float _moveSpdIncrease;
    public float _jumpPowerIncrease;
}
