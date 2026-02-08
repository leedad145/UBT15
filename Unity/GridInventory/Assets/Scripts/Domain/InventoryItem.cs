public class InventoryItem
{
    Item _item;
    ItemId _id => _item.Id;
    
    public int[,] GridShape { get; private set; } // [y,x]
    public int Height { get {return GridShape.GetLength(0); } } 
    public int Width { get {return GridShape.GetLength(1); } }
    public InventoryItem(Item item)
    {
        _item = item;
        GridShape = new int[_id.Height, _id.Width];
        switch (_id.ItemStyle)
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
                for (int y = 0; y < _id.Height; y++)
                    for (int x = 0; x < _id.Width; x++)
                        GridShape[y, x] = 1;
                break;
            case ItemStyle.H:
                for (int x = 0; x < _id.Width; x++)
                    GridShape[_id.Height / 2, x] = 1;

                for (int y = 0; y < _id.Height; y++)
                {
                    GridShape[y, 0] = 1;
                    GridShape[y, _id.Width - 1] = 1;
                }
                break;
            case ItemStyle.S:
                for (int x = 0; x < _id.Width; x++)
                {
                    if(x <= _id.Width / 2)
                        GridShape[_id.Height - 1, x] = 1;
                    else
                        GridShape[0, x] = 1;
                }
                for (int y = 0; y < _id.Height; y++)
                    GridShape[y, _id.Width / 2] = 1;
                break;
            case ItemStyle.T:
                for (int x = 0; x < _id.Width; x++)
                    GridShape[0, x] = 1;
                for (int y = 0; y < _id.Height; y++)
                    GridShape[y, _id.Width / 2] = 1;
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