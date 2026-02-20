using System;
using System.Text;
using NUnit.Framework;
using Random = UnityEngine.Random;
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
    public static ItemId GetRandomItemId()
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
        return new ItemId(randId);
    }
}
public class Item : Entity<ItemId>
{
    public readonly string Name;
    public readonly Status Stat;
    public int[,] GridShape { get; private set; } // [y,x]

    public Item(int id, string name, Status stat) : base(new ItemId(id))
    {
        Name = name;
        Stat = stat;
    }
}
