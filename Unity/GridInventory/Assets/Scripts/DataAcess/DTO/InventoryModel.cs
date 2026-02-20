using System;

[Serializable]
public sealed class InventoryItemModel
{
    public long serial_number;
    public int item_id;
    public int x;
    public int y;
}

[Serializable]
public sealed class InventoryModel
{
    public InventoryItemModel[] data;
}