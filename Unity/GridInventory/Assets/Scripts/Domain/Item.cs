using System;
using NUnit.Framework;

public enum ItemStyle
{
    None,
    H,
    S,
    T
}
public enum ItemType
{
    None,
    Helmet, // 1
    Gloves, // 2
    Boots,  // 3
    BodyArmor, // 4
    Weapon, // 5
}
public class ItemId : IEquatable<ItemId>
{
    public readonly int RawId; // int {ItemType}{ItemStyle}{Width}{Height}{Index}
    public readonly ItemType ItemType;      // 1 ~ 9
    public readonly ItemStyle ItemStyle;    // 1 ~ 9
    public readonly int Width;              // 1 ~ 9
    public readonly int Height;             // 1 ~ 9
    public readonly int Index;              // 1 ~ 999


    public ItemId(int id)
    {
        Assert.IsTrue(id.ToString().Length == 7);
        RawId = id;
        ItemType = (ItemType)(id / 1000000 % 10);
        ItemStyle = (ItemStyle)(id / 100000 % 10);
        Width = id / 10000 % 10;
        Height = id / 1000 % 10;
        Index = id % 1000;
    }

    public bool Equals(ItemId other)
    {
        return RawId == other.RawId;
    }
}
public class Item : Entity<ItemId>
{
    public readonly string name;
    public readonly Status status;
    public int[,] GridShape { get; private set; } // [y,x]

    public Item(int id) : base(new ItemId(id))
    {
        name = "name";
        status = new Status(10, 10);
    }
}
