public class InventoryItem
{
    Item _itemData;
    public ItemType ItemType => _itemData.ItemType;
    public int[,] GridShape { get; private set; } // [y,x]
    public int Height { get {return GridShape.GetLength(0); } } 
    public int Width { get {return GridShape.GetLength(1); } }
    public InventoryItem(Item item)
    {
        _itemData = item;
        GridShape = new int[item.Height, item.Width];
        switch (item.ItemStyle)
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
        */
            case ItemStyle.None:
            default:
                for (int y = 0; y < item.Height; y++)
                    for (int x = 0; x < item.Width; x++)
                        GridShape[y, x] = 1;
                break;
            case ItemStyle.H:
                for (int x = 0; x < item.Width; x++)
                    GridShape[item.Height / 2, x] = 1;

                for (int y = 0; y < item.Height; y++)
                {
                    GridShape[y, 0] = 1;
                    GridShape[y, item.Width - 1] = 1;
                }
                break;
            case ItemStyle.S:
                for (int x = 0; x < item.Width; x++)
                {
                    if(x <= item.Width / 2)
                        GridShape[item.Height - 1, x] = 1;
                    else
                        GridShape[0, x] = 1;
                }
                for (int y = 0; y < item.Height; y++)
                    GridShape[y, item.Width / 2] = 1;
                break;
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