using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    Item _item;
    Text text;
    public void SetItem(Item item)
    {
        text = transform.Find("Text").GetComponent<Text>();
        _item = item;
        text.text = $"{item._description}({item._price}g)";
    }
    public void OnClick()
    {
        ItemShop shop = GameObject.Find("ItemShop").GetComponent<ItemShop>();
        if(shop != null)
            shop.TryBuyItem(_item);
    }
}
