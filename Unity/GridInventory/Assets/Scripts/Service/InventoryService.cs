public class InventoryService
{
    private IInventoryRepository _inventoryRepository;
    private Inventory _inventory;

    public int[,] ItemSlot => _inventory.ItemSlot;
    public int Width { get {return _inventory.Width; } }
    public int Height { get {return _inventory.Height; } }
    public InventoryService(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
        _inventory = _inventoryRepository.Load();
    }
    public void Save()
        => _inventoryRepository.Save(_inventory);
    public void Load()
        => _inventory = _inventoryRepository.Load();
    /// <summary>
    /// 지정좌표에 랜덤 테스트 아이템을 소환합니다.
    /// </summary>
    public void TryPlaceRandomTestItem(int x, int y)
    {
        // 간단 테스트 데이터(원하면 여기만 바꿔서 다양한 아이템 시험 가능)
        var itemId = ItemId.GetRandomItemId();
        var invenItem = InventoryItem.Create(itemId);
        TryPlaceItem(invenItem, x, y);
    }
    // 등록 시도
    public bool TryPlaceItem(InventoryItem item, int targetX, int targetY)
    {
        if(!_inventory.IsValidPosition(item, targetX, targetY))
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
        if(!_inventory.IsValidPosition(item, targetX, targetY))
            return false;

        (int originalX, int originalY) = _inventory.GetItemPos(item);
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
        InventoryItem item = _inventory.GetItemAt(x, y);

        if (item != null)
        {
            _inventory.PickUp(item);
        }
    }
    // 파사드: 도메인 메서드 위임
    public InventoryItem? GetItemAt(int x, int y)
        => _inventory.GetItemAt(x, y);
    public (int X, int Y) GetItemPos(InventoryItem item)
        => _inventory.GetItemPos(item);
    public bool IsValidPosition(InventoryItem item, int x, int y)
        => _inventory.IsValidPosition(item, x, y);
}
