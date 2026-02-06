public class InventoryService
{
    private Inventory _inventory;
    public int[,] Itemslot => _inventory.ItemSlot;
    public int Width { get {return _inventory.Width; } }
    public int Height { get {return _inventory.Height; } }
    public InventoryService(Inventory inventory)
    {
        _inventory = inventory;
    }
    // 등록 시도
    public bool TryPlaceItem(InventoryItem item, int targetX, int targetY)
    {
        if(targetX < 0 || targetY < 0 || targetX + item.Width > Width || targetY + item.Height > Height)
            return false;
        _inventory.PlaceItem(item, targetX, targetY);
        if(_inventory.HasOverlap)
        {
            _inventory.PickUp(item);
            return false;
        }
        return true;
    }
    /// <summary>
    /// 아이템을 이동합니다.
    /// </summary>
    public bool TryMoveItem(InventoryItem item, int targetX, int targetY)
    {
        if(targetX < 0 || targetY < 0 || targetX + item.Width > Width || targetY + item.Height > Height)
            return false;

        (int originalX, int originalY) = GetItemPos(item);
        MoveItem(item, targetX, targetY);

        // 겹침이 발생하면 롤백후 실패
        if (_inventory.HasOverlap)
        {
            MoveItem(item, originalX, originalY);
            return false;
        }

        return true;
    }
    public void MoveItem(InventoryItem item, int targetX, int targetY)
    {
        _inventory.PickUp(item);
        _inventory.PlaceItem(item, targetX, targetY);
    }
    /// <summary>
    /// 아이템을 제거합니다.
    /// </summary>
    public void PickUpAt(int x, int y)
    {
        InventoryItem item = GetItemAt(x, y);

        if (item != null)
            PickUp(item);
    }
    public void PickUp(InventoryItem item)
        =>_inventory.PickUp(item);
    public InventoryItem GetItemAt(int x, int y)
        => _inventory.GetItemAt(x, y);
    public (int X, int Y) GetItemPos(InventoryItem item)
        => _inventory.GetItemPos(item);
}
