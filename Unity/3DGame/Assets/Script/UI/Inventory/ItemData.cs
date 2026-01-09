public class ItemData
{
    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary,
        Mythic,
    }
    Rarity _itemRarity;
    public Rarity ItemRarity
    {
        get
        {
            return _itemRarity;
        }
    }
    readonly string _ItemID;
    readonly string _name;
    readonly int _atk;
    readonly int _def;
    readonly int _hp;
    readonly int _mp;
    readonly int _spd;
    public ItemData(Rarity rarity, string _itemID = "")
    {
        _itemRarity = rarity;
        SetItemData(_itemID);
    }
    private void SetItemData(string itemID)
    {
        // 아이템 정보를 받아서 세팅
    }
    public (Rarity rarity, string name, int atk, int def, int hp, int mp, int spd) GetItemData()
    {
        return (_itemRarity, _name, _atk, _def, _hp, _mp, _spd);
    }
}
