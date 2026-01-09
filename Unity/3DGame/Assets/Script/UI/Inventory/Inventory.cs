using Unity.VisualScripting;
using UnityEngine;

public class Inventory : UI_Scene
{
    enum GameObjects
    {
        EquippedItems,
        ItemInfo,
        ItemList,
    }

    ItemSlot[] _equipItems = new ItemSlot[6];
    ItemSlot[] _Inventory = new ItemSlot[20];

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        GameObject EquippedItems = Get<GameObject>((int)GameObjects.EquippedItems);
        for (int i = 0; i < _equipItems.Length; i++)
        {
            Transform eq = EquippedItems.transform.GetChild(i);
            _equipItems[i] = eq.GetChild(0).GetOrAddComponent<ItemSlot>();
            _equipItems[i].SetInfo();
        }
        for (int i = 0; i < _Inventory.Length; i++)
        {
            GameObject itemSlot = Managers.Resource.Instantiate("Popup/ItemSlot");
            itemSlot.transform.SetParent(Get<GameObject>((int)GameObjects.ItemList).transform);
            _Inventory[i] = itemSlot.GetOrAddComponent<ItemSlot>();
            _Inventory[i].SetInfo();
        }
    }
}
