using System.Linq;
using System.Text;
using UnityEngine;

public class ItemService
{
    /// <summary>
    /// 랜덤 테스트 아이템 데이터를 생성합니다.
    /// </summary>
    public Item MakeRandomItemData()
    {
        // type, style, w, h, idx
        string type = "1";
        string[] style =  new[] { "1", "2", "3" };
        string[] wh = new[] {"12", "21", "22", "32", "23", "33"};
        string idx = "001";
        StringBuilder sb = new StringBuilder();
        sb.Append(type);
        sb.Append(style[Random.Range(0, style.Length)]);
        sb.Append(wh[Random.Range(0, wh.Length)]);
        sb.Append(idx);
        int randId = int.Parse(sb.ToString());
        return new Item(randId);
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
