using System;

public class InventoryItem : Entity<long>
{
    public long SerialNumber => Id;
    public ItemId ItemId { get; }
    
    public int[,] GridShape { get; private set; } // [y,x]
    public int Height { get {return GridShape.GetLength(0); } } 
    public int Width { get {return GridShape.GetLength(1); } }
    public InventoryItem(long serialNumber, ItemId itemId) : base(serialNumber)
    {
        ItemId = itemId;
        GridShape = new int[ItemId.Height, ItemId.Width];
        switch (ItemId.ItemStyle)
        {
        /*
        width 3 height 3 style None
        [1][1][1]
        [1][1][1]
        [1][1][1]
        width 3 height 3 style H
        [1][0][1]
        [1][1][1]
        [1][0][1]
        width 3 height 3 style S
        [0][1][1]
        [0][1][0]
        [1][1][0]
        width 3 height 3 style T
        [1][1][1]
        [0][1][0]
        [0][1][0]
        */
            case ItemStyle.None:
            default:
                for (int y = 0; y < ItemId.Height; y++)
                    for (int x = 0; x < ItemId.Width; x++)
                        GridShape[y, x] = 1;
                break;
            case ItemStyle.H:
                for (int x = 0; x < ItemId.Width; x++)
                    GridShape[ItemId.Height / 2, x] = 1;

                for (int y = 0; y < ItemId.Height; y++)
                {
                    GridShape[y, 0] = 1;
                    GridShape[y, ItemId.Width - 1] = 1;
                }
                break;
            case ItemStyle.S:
                for (int x = 0; x < ItemId.Width; x++)
                {
                    if(x <= ItemId.Width / 2)
                        GridShape[ItemId.Height - 1, x] = 1;
                    else
                        GridShape[0, x] = 1;
                }
                for (int y = 0; y < ItemId.Height; y++)
                    GridShape[y, ItemId.Width / 2] = 1;
                break;
            case ItemStyle.T:
                for (int x = 0; x < ItemId.Width; x++)
                    GridShape[0, x] = 1;
                for (int y = 0; y < ItemId.Height; y++)
                    GridShape[y, ItemId.Width / 2] = 1;
                break;
        }
    }
    public static InventoryItem Create(ItemId itemId)
    {
        Random randomGenerator = new Random();
        long serialNumber = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + randomGenerator.Next(9999).ToString("D4"));
        
        return new InventoryItem(serialNumber, itemId);
    }
    public void Rotate(bool dir = true)
    {
        if (dir)
        {
            Perform90DegreeRotation();
        }
        else
        {
            Perform90DegreeRotation();
            Perform90DegreeRotation();
            Perform90DegreeRotation();
        }
    }
    public void Perform90DegreeRotation()
    {
        int[,] next = new int[Width, Height];

        for (int y = 0; y < Height; y++)
            for (int x = 0; x < Width; x++)
                next[x, Height - 1 - y] = GridShape[y, x];

        GridShape = (int[,])next.Clone();
    }
}