using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryGrid : MonoBehaviour
{
    private RectTransform _rectTransform;
    public RectTransform RT => _rectTransform;
    public float Width => _rectTransform.rect.width;
    public float Height => _rectTransform.rect.height;
    public float TileSizeWidth { get; private set; } = 64f; // UI 타일의 크기
    public float TileSizeHeight { get; private set; } = 64f; // UI 타일의 크기

    Color _cellColor = new Color(0.5f, 0.5f, 0.5f, 0.3f); // 기본
    Color _invalidCellColor = new Color(1f, 0f, 0f, 0.3f); // 설치 불가능한 셀

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
    // 아이템 inventory상의 위치를 출력
    public Vector2Int GetTileGridPosition(Vector2 screenMousePosition)
    {
        Vector2Int _tileGridPosition = new Vector2Int();

        RectTransformUtility.ScreenPointToLocalPointInRectangle(RT, screenMousePosition, null, out var _localPoint);

        // 로컬 좌표는 pivot 기준. 좌하단(0,0) 기준으로 맞추기 위해 rect.min을 더해줌.
        var rect = RT.rect;
        var pointFromBottomLeft = _localPoint - rect.min; // rect.min은 보통 (-w*pivot.x, -h*pivot.y)

        _tileGridPosition.x = Mathf.FloorToInt(pointFromBottomLeft.x / TileSizeWidth);
        _tileGridPosition.y = Mathf.FloorToInt(pointFromBottomLeft.y / TileSizeHeight);

        return _tileGridPosition;
    }
    // 설치 가능하면 초록
    // 설치 불가능 하면 빨강으로 표시되게 해보자

    /// <summary>
    /// inventory 표시
    /// </summary>
    public void ShowInventoryGrid(int[,] itemSlot)
    {
        ClearMovePrediction();
        
        // 예상 지역에 회색 오버레이 표시
        for (int y = 0; y < itemSlot.GetLength(0); y++)
        {
            for (int x = 0; x < itemSlot.GetLength(1); x++)
            {
                if (itemSlot[y, x] < 1) continue;

                if (itemSlot[y, x] < 1) continue;
                else if (itemSlot[y, x] == 1)
                    CreateMovePredictionCell(x, y, _cellColor);
                else
                    CreateMovePredictionCell(x, y, _invalidCellColor);
            }
        }
    }

    /// <summary>
    /// 드래그 중 로컬 미리보기만 표시 (서버 데이터는 변경 X)
    /// </summary>
    public void ShowInventoryGridPreview(int[,] itemSlot, InventoryItem draggedItem, int previewX, int previewY)
    {
        ClearMovePrediction();
        
        // 기존 itemSlot 표시
        for (int y = 0; y < itemSlot.GetLength(0); y++)
        {
            for (int x = 0; x < itemSlot.GetLength(1); x++)
            {
                if (itemSlot[y, x] < 1) continue;

                if (itemSlot[y, x] < 1) continue;
                else if (itemSlot[y, x] == 1)
                    CreateMovePredictionCell(x, y, _cellColor);
                else
                    CreateMovePredictionCell(x, y, _invalidCellColor);
            }
        }
        
        // 미리보기 아이템 위치 추가 (초록색: 유효, 빨강: 겹침)
        if (draggedItem != null)
        {
            for (int y = 0; y < draggedItem.GridShape.GetLength(0); y++)
            {
                for (int x = 0; x < draggedItem.GridShape.GetLength(1); x++)
                {
                    if (draggedItem.GridShape[y, x] == 1)
                    {
                        int cellX = previewX + x;
                        int cellY = previewY + y;
                        
                        // 범위 체크
                        if (cellX < 0 || cellY < 0 || cellX >= itemSlot.GetLength(1) || cellY >= itemSlot.GetLength(0))
                            continue;
                        
                        // 겹침 여부 확인 (임시 미리보기에서만)
                        bool isOverlap = itemSlot[cellY, cellX] > 0;
                        Color previewColor = isOverlap ? _invalidCellColor : new Color(0f, 1f, 0f, 0.3f); // 녹색
                        
                        CreateMovePredictionCell(cellX, cellY, previewColor);
                    }
                }
            }
        }
    }

    private readonly List<GameObject> _predictionCells = new List<GameObject>();

    /// <summary>
    /// 단일 위치에 예상 셀을 생성합니다.
    /// </summary>
    private void CreateMovePredictionCell(int x, int y, Color cellColor)
    {
        var go = new GameObject($"PredictionCell_{x}_{y}", typeof(RectTransform), typeof(CanvasRenderer), typeof(Image));
        go.transform.SetParent(RT, false);

        var rt = (RectTransform)go.transform;
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.zero;
        rt.pivot = Vector2.zero;
        rt.anchoredPosition = new Vector2(x * TileSizeWidth, y * TileSizeHeight);
        rt.sizeDelta = new Vector2(TileSizeWidth, TileSizeHeight);

        var img = go.GetComponent<Image>();
        img.raycastTarget = false;
        img.color = cellColor;

        _predictionCells.Add(go);
    }

    /// <summary>
    /// 단일 예상 위치 모두 제거합니다.
    /// </summary>
    public void ClearMovePrediction()
    {
        for (int i = 0; i < _predictionCells.Count; i++)
        {
            if (_predictionCells[i] != null)
                Destroy(_predictionCells[i]);
        }
        _predictionCells.Clear();
    }
}