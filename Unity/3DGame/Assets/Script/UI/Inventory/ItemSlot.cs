using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ItemSlot : UI_Base
{
    ItemData _item;
    int _count;
    
    enum Images
    {
        ItemIcon,
        ItemFrame,
    }
    
    void Awake()
    {
        //Init();
    }
    public override void Init()
    {
        Bind<Image>(typeof(Images));
        //Get<Image>((int)Images.ItemImage);
        //Get<Image>((int)Images.Frame);
        SetInfo();
    }

    public ItemData SetInfo(ItemData.Rarity rarity = ItemData.Rarity.Common, string itemID = "")
    {
        Bind<Image>(typeof(Images));
        _item =  new ItemData(rarity, itemID);
        RefeshUI();
        return _item;
    }
    public void RefeshUI()
    {
        Image icon = Get<Image>((int)Images.ItemIcon).GetOrAddComponent<Image>();
        //icon.sprite = _texture;
        Image frame = Get<Image>((int)Images.ItemFrame).GetOrAddComponent<Image>();

        frame.color = _item.ItemRarity switch
        {
            ItemData.Rarity.Common => Color.white,
            ItemData.Rarity.Uncommon => Color.green,
            ItemData.Rarity.Rare => Color.blue,
            ItemData.Rarity.Epic => Color.purple,
            ItemData.Rarity.Legendary => Color.gold,
            ItemData.Rarity.Mythic => Color.red,
            _ => Color.white,
        };
    }
}
