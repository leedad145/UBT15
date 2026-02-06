using UnityEngine;

public class InventoryItemService
{
    /// <summary>
    /// 랜덤 테스트 아이템 데이터를 생성합니다.
    /// </summary>
    public Item MakeRandomItemData()
    {
        var w = Random.Range(1, 4);
        var h = Random.Range(1, 4);
        var style = (ItemStyle)Random.Range(0, 3);

        var typeValues = new[] { ItemType.Helmet, ItemType.Gloves, ItemType.Boots, ItemType.BodyArmor, ItemType.Weapon };
        var type = typeValues[Random.Range(0, typeValues.Length)];

        return new Item(w, h, style, type);
    }
    /// <summary>
    /// 아이템의 모양을 회전합니다.
    /// </summary>
    /// <param name="targetItem">회전할 아이템</param>
    /// <param name="dir">회전 방향 (true: 시계방향, false: 반시계방향)</param>
    public void Rotate(InventoryItem targetItem, bool dir = true)
    {
        if (dir)
        {
            targetItem.Perform90DegreeRotation();
        }
        else
        {
            targetItem.Perform90DegreeRotation();
            targetItem.Perform90DegreeRotation();
            targetItem.Perform90DegreeRotation();
        }
    }
}
