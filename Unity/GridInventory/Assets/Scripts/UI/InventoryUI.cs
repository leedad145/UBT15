using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 테스트용 인벤토리 UI 컨트롤러.
/// 프리팹(=GameObject)에 붙이고 RectTransform만 연결하면,
/// 클릭 위치를 그리드 좌표로 변환해서 Domain.Inventory에 아이템을 넣어볼 수 있습니다.
/// </summary>
[DisallowMultipleComponent]
public class InventoryUI : MonoBehaviour
{
    [Header("Service SO")]
    [SerializeField] private InventoryServiceSO _inventoryServiceSO;
    [SerializeField] private InventoryItemServiceSO _inventoryItemServiceSO;
    public InventoryService InventoryService => _inventoryServiceSO.Service;
    public InventoryItemService InventoryItemService => _inventoryItemServiceSO.Service;

    [Header("Grid")]
    [SerializeField] private InventoryGrid _inventoryGrid;
    public InventoryGrid InventoryGrid => _inventoryGrid;
    public int GridWidth => InventoryService.Width;
    public int GridHeight => InventoryService.Height;

    [Header("Item UI")]
    [SerializeField] private InventoryItemUI itemUiPrefab; // 비우면 기본 오브젝트 생성

    // 재사용 버퍼(할당 방지)
    private readonly Dictionary<InventoryItem, InventoryItemUI> _itemUIs = new Dictionary<InventoryItem, InventoryItemUI>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var tile = _inventoryGrid.GetTileGridPosition(Input.mousePosition);
            TryPlaceRandomTestItem(tile.x, tile.y);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            var tile = _inventoryGrid.GetTileGridPosition(Input.mousePosition);
            DespawnItemUI(tile.x, tile.y);
        }
    }

    /// <summary>
    /// 지정좌표에 랜덤 테스트 아이템을 소환합니다.
    /// </summary>
    private void TryPlaceRandomTestItem(int x, int y)
    {
        // 간단 테스트 데이터(원하면 여기만 바꿔서 다양한 아이템 시험 가능)
        var itemData = InventoryItemService.MakeRandomItemData();
        var item = new InventoryItem(itemData);
        TrySpawnItemUI(item, x, y);
    }
    /// <summary>
    /// 지정좌표에 아이템을 소환합니다.
    /// </summary>
    private void TrySpawnItemUI(InventoryItem item, int x, int y)
    {
        if (InventoryService.TryPlaceItem(item, x, y))
            SpawnItemUI(item);
        /////////////////////////////////////
        void SpawnItemUI(InventoryItem item)
        {
            if (item == null) return;
            if (_itemUIs.ContainsKey(item)) return;

            InventoryItemUI ui;
            if (itemUiPrefab != null)
            {
                ui = Instantiate(itemUiPrefab, _inventoryGrid.RT);
            }
            else
            {
                var go = new GameObject("InventoryItemUI", typeof(RectTransform), typeof(InventoryItemUI));
                go.transform.SetParent(_inventoryGrid.RT, false);
                ui = go.GetComponent<InventoryItemUI>();
            }

            ui.Bind(this, item);
            
            _itemUIs[item] = ui;
        }
    }

    private void DespawnItemUI(int x, int y)
    {
        InventoryItem item = InventoryService.GetItemAt(x, y);
        if (_itemUIs.TryGetValue(item, out var ui) && ui != null)
        {
            Destroy(ui.gameObject);
        }
        _itemUIs.Remove(item);
        InventoryService.PickUp(item);
    }
}