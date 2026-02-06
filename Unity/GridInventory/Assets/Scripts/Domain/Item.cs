public enum ItemStyle
{
    None,
    H,
    S
}
public enum ItemType
{
    None,
    Helmet,
    Gloves,
    Boots,
    BodyArmor,
    Weapon,
}
public class Item // status, status, type
{
    public readonly int Width;
    public readonly int Height;
    public readonly ItemStyle ItemStyle;
    public readonly ItemType ItemType;
    public Item(int width = 3,int height = 3, ItemStyle itemStyle = ItemStyle.None, ItemType itemType = ItemType.None)
    {
        Width = width;
        Height = height;
        ItemStyle = itemStyle;
        ItemType = itemType;
    }
}
