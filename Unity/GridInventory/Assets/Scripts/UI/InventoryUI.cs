using System.Data.Common;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 테스트용 인벤토리 UI 컨트롤러.
/// 프리팹(=GameObject)에 붙이고 RectTransform만 연결하면,
/// 클릭 위치를 그리드 좌표로 변환해서 Domain.Inventory에 아이템을 넣어볼 수 있습니다.
/// </summary>
[DisallowMultipleComponent]
public class InventoryUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    [Header("Service SO")]
    [SerializeField] private InventoryServiceLocateSO _inventoryServiceSO;

    [Header("Grid")]
    [SerializeField] private InventoryGrid _inventoryGrid;
    
    // 드래그 상태 추적
    private InventoryItem? _targetItem = null;
    private int _dragStartX;
    private int _dragStartY;
    private int _currentDragX;  // 로컬 미리보기 위치
    private int _currentDragY;
    
    // 회전 상태 추적
    private int _rotateValue;

    void Update()
    {
        if(_targetItem == null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var tile = _inventoryGrid.GetTileGridPosition(Input.mousePosition);
                _inventoryServiceSO.Service.TryPlaceRandomTestItem(tile.x, tile.y);
                GridUpdate();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                var tile = _inventoryGrid.GetTileGridPosition(Input.mousePosition);
                _inventoryServiceSO.Service.PickUpAt(tile.x, tile.y);
                GridUpdate();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Rotate(true);
            }
            // T = 반대 방향 회전
            if (Input.GetKeyDown(KeyCode.T))
            {
                Rotate(false);
            }
        }
    }
    #region Input
    public void OnPointerDown(PointerEventData eventData) //클릭
    {
        var tilePos = _inventoryGrid.GetTileGridPosition(eventData.position);
        _targetItem = _inventoryServiceSO.Service.GetItemAt(tilePos.x, tilePos.y);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var tilePos = _inventoryGrid.GetTileGridPosition(eventData.position);
        _targetItem = _inventoryServiceSO.Service.GetItemAt(tilePos.x, tilePos.y);
        
        if(_targetItem != null)
        {
            (_dragStartX, _dragStartY) = _inventoryServiceSO.Service.GetItemPos(_targetItem);
            _currentDragX = _dragStartX;
            _currentDragY = _dragStartY;
            _rotateValue = 0;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_targetItem == null) return;
        
        var tilePos = _inventoryGrid.GetTileGridPosition(eventData.position);
        
        // 유효성 검증만 (서버 호출 X, 로컬만 업데이트)
        if (!_inventoryServiceSO.Service.IsValidPosition(_targetItem, tilePos.x, tilePos.y))
            return;

        // 로컬 미리보기 위치만 업데이트
        _currentDragX = tilePos.x;
        _currentDragY = tilePos.y;
        
        // UI 프리뷰만 갱신 (아직 서버 데이터는 변경 X)
        PreviewUpdate();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_targetItem == null) return;

        // 드래그 완료 시 서버에 최종 확정 (1회만)
        if(!_inventoryServiceSO.Service.TryMoveItem(_targetItem, _currentDragX, _currentDragY))
        {
            // 실패 시 원위치로 복귀
            _currentDragX = _dragStartX;
            _currentDragY = _dragStartY;
            
            // 회전도 롤백
            while(_rotateValue != 0)
            {
                if(_rotateValue > 0)
                    Rotate(false);
                else
                    Rotate(true);
            }
        }
        
        _targetItem = null;
        GridUpdate();
    }
    #endregion Input
    
    /// <summary>
    /// 드래그 중 로컬 미리보기만 갱신 (서버 데이터 변경 X)
    /// </summary>
    void PreviewUpdate()
    {
        // 임시 위치로 미리보기만 표시
        _inventoryGrid.ShowInventoryGridPreview(_inventoryServiceSO.Service.ItemSlot, _targetItem, _currentDragX, _currentDragY);
    }
    
    /// <summary>
    /// 드래그 완료 후 최종 서버 데이터로 갱신
    /// </summary>
    void GridUpdate()
    {
        _inventoryGrid.ShowInventoryGrid(_inventoryServiceSO.Service.ItemSlot);
    }
    
    void Rotate(bool dir)
    {
        if (_targetItem == null) return;
        
        _targetItem.Rotate(dir);
        if(dir)
            _rotateValue++;
        else
            _rotateValue--;

        // 회전도 로컬 미리보기 갱신만
        PreviewUpdate();
    }
}