using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[DisallowMultipleComponent] // 한개의 스크립트만 붙혀야함       
[RequireComponent(typeof(RectTransform))] // 반드시 RectTransfrom이 있어야함
public class InventoryItemUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    private RectTransform _rectTransform;
    private InventoryGrid _inventoryGrid;
    private InventoryService _inventoryService;
    private InventoryItemService _inventoryItemService;

    private InventoryItem _item;
    public InventoryItem Item => _item;
    int originalX;
    int originalY;
    private bool _dragging;
    Color _cellColor = new Color(0.8f, 0.7f, 0.2f, 0.5f); // ui cell 색
    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (!_dragging) return;

        // 드래그 중 R키로 회전 (원본 오브젝트 변경)
        if (Input.GetKeyDown(KeyCode.R))
        {
            TryRotate(true);
        }
        // T = 반대 방향 회전
        if (Input.GetKeyDown(KeyCode.T))
        {
            TryRotate(false);
        }
    }
    #region Input
    /// <summary>
    /// InventoryItemUI를 InventoryUI와 InventoryItem 초기화합니다.
    /// </summary>
    /// <param name="ui">초기화할 InventoryUI</param>
    /// <param name="item">초기화할 아이템</param>
    public void Bind(InventoryUI ui, InventoryItem item)
    {
        _item = item;
        _inventoryGrid = ui.InventoryGrid;
        _inventoryService = ui.InventoryService;
        _inventoryItemService = ui.InventoryItemService;
        
        RebuildVisual();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // 인벤토리에 표시기능 추가
        
        RebuildVisual();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _dragging = true;
        (originalX, originalY) = _inventoryService.GetItemPos(_item);

        _rectTransform.SetParent(_inventoryGrid.RT, true);
        _rectTransform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_dragging) return;
        
        var tilePos = _inventoryGrid.GetTileGridPosition(eventData.position);
        _inventoryService.MoveItem(_item, tilePos.x, tilePos.y);

        RebuildVisual();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!_dragging) return;
        _dragging = false;

        _inventoryGrid.ClearMovePrediction();
        var tilePos = _inventoryGrid.GetTileGridPosition(eventData.position);

        if(!_inventoryService.TryMoveItem(_item, tilePos.x, tilePos.y))
            _inventoryService.MoveItem(_item, originalX, originalY);

        // 부모를 grid로 고정하고 스냅
        _rectTransform.SetParent(_inventoryGrid.RT, false);
        
        RebuildVisual();
    }
    #endregion Input
    public void TryRotate(bool dir = true)
    {
        (int X, int Y) = _inventoryService.GetItemPos(_item);
        _inventoryService.PickUp(_item);
        _inventoryItemService.Rotate(_item, dir);
        if(!_inventoryService.TryPlaceItem(_item, X, Y)) // 실패시 다시 돌림
        {
            _inventoryItemService.Rotate(_item, !dir);
            _inventoryService.TryPlaceItem(_item, X, Y);
        }

        RebuildVisual();
    }
    /// <summary>
    /// 아이템의 비주얼을 재구성합니다.
    /// </summary>
    public void RebuildVisual()
    {
        // 기존 자식 제거
        for (int i = transform.childCount - 1; i >= 0; i--)
            Destroy(transform.GetChild(i).gameObject);

        // 전체 바운딩 박스 크기
        _rectTransform.anchorMin = Vector2.zero;
        _rectTransform.anchorMax = Vector2.zero;
        _rectTransform.pivot = Vector2.zero;
        _rectTransform.sizeDelta = new Vector2(_item.Width * _inventoryGrid.Width, _item.Height * _inventoryGrid.Height);

        // GridShape가 1인 칸만 생성 (회색 cell)
        for (int y = 0; y < _item.Height; y++)
        {
            for (int x = 0; x < _item.Width; x++)
            {
                if (_item.GridShape[y, x] != 1) continue; // 1이 아니면 생성하지 않음
                
                var cell = new GameObject($"Cell_{x}_{y}", typeof(RectTransform), typeof(CanvasRenderer), typeof(Image));
                cell.transform.SetParent(transform, false);
                var rt = (RectTransform)cell.transform;
                rt.anchorMin = Vector2.zero;
                rt.anchorMax = Vector2.zero;
                rt.pivot = Vector2.zero;
                rt.anchoredPosition = new Vector2(x * _inventoryGrid.TileSizeWidth, y * _inventoryGrid.TileSizeHeight);
                rt.sizeDelta = new Vector2(_inventoryGrid.TileSizeWidth, _inventoryGrid.TileSizeHeight);

                var img = cell.GetComponent<Image>();
                img.raycastTarget = true; // 회색 cell에만 RaycastTarget 활성화
                img.color = _cellColor;
            }
        }
        SnapItemUIToPlacement();
    }
    /// 그리드에 딱 맞게 위치를 재지정 합니다.
    public void SnapItemUIToPlacement()
    {
        (int x, int y) = _inventoryService.GetItemPos(_item);
        _rectTransform.anchorMin = Vector2.zero;
        _rectTransform.anchorMax = Vector2.zero;
        _rectTransform.pivot = Vector2.zero;
        _rectTransform.anchoredPosition = new Vector2(x * _inventoryGrid.TileSizeWidth, y * _inventoryGrid.TileSizeWidth);
        _rectTransform.sizeDelta = new Vector2(_item.Width * _inventoryGrid.TileSizeWidth, _item.Height * _inventoryGrid.TileSizeWidth);
    }
}

