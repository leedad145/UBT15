using UnityEngine;

public class ItemShop : MonoBehaviour
{
    private Item[] _items;
    public Item[] Items => _items;
    GameObject ItemSlotPrefab;
    GameObject Player;
    Transform slotPanel;
    Transform canvas;


    void Awake()
    {
        Player = GameObject.Find("Player");
        canvas = transform.Find("ItemShopCanvas");
        slotPanel = canvas.transform.Find("SlotPanel");
        canvas.gameObject.SetActive(false);
        
        ItemSlotPrefab = Resources.Load<GameObject>("Prefabs/ItemSlot");
        _items = new Item[5];
        Items[0] = Resources.Load<Item>("Items/HealthBoost");
        Items[1] = Resources.Load<Item>("Items/AttackBoost");
        Items[2] = Resources.Load<Item>("Items/SpeedBoost");
        Items[3] = Resources.Load<Item>("Items/JumpBoost");
        Items[4] = Resources.Load<Item>("Items/FullBoost");
        foreach(Item item in _items)
        {
            GameObject slot = Instantiate(ItemSlotPrefab, slotPanel);
            slot.transform.SetParent(slotPanel);
            slot.GetComponent<ItemSlot>().SetItem(item);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Player = GameObject.Find("Player");
        if(other.gameObject == Player)
        {
            canvas.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == Player)
        {
            canvas.gameObject.SetActive(false);
        }
    }
    public bool TryBuyItem(Item item)
    {
        // 골드 확인
        if (GameManager.Instance._gold._value < item._price)
        {
            Debug.Log("골드 부족!");
            return false;
        }

        // 골드 차감
        GameManager.Instance._gold.SpendGold(item._price);

        // 플레이어 스텟 증가
        PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.ApplyItem(item);
            Debug.Log($"{item._itemName} 구매 완료!");
            return true;
        }

        return false;
    }
}
