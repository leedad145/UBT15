using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour //싱글톤으로?
{
    enum EquipSlot
    {
        Head,
        Chest,
        Legs,
        Feet,
        MainHand,
        OffHand,
        Count,
    }
    Item[] _equipItems = new Item[(int)EquipSlot.Count];
    static List<Item> _inven;
    [SerializeField]
    GameObject EquippedItem;
    [SerializeField]
    GameObject ItemInfo;
    [SerializeField]
    GameObject ItemList;
    
    void Start()
    {
        _inven = new List<Item>();
        _equipItems[(int)EquipSlot.Head] = new Item();
    }

    void Update()
    {
        
    }
}
