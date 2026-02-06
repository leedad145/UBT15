using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Unity.Mathematics;

/*
아이템 배치, 제거
아이템 회전
*/
public class Inventory
{
    public int Width { get; private set; }
    public int Height { get; private set; }
    public int[,] ItemSlot { get; private set; }
    public bool HasOverlap => ItemSlot.Cast<int>().Any(slot => slot > 1);
    public readonly struct ItemPlacement // 저장
    {
        public readonly InventoryItem Item;
        // 시작 좌표
        public readonly int X; 
        public readonly int Y;

        public ItemPlacement(InventoryItem item, int x, int y)
        {
            Item = item;
            X = x;
            Y = y;
        }
    }

    // 아이템이 "어디에 놓였는지"를 저장(드래그 이동/좌표 역추적용)
    private readonly List<ItemPlacement> _placements = new List<ItemPlacement>();
    public IReadOnlyList<ItemPlacement> Placements => _placements;

    public Inventory(int width, int height)
    {
        Width = width;
        Height = height;
        // [y, x] 순서로 접근하므로 [Height, Width]로 생성해야 안전함
        ItemSlot = new int[Height, Width];
    }

    /// <summary>
    /// 아이템을 인벤토리의 지정된 위치에 배치합니다. _placements에만 추가하고, ItemSlot은 RebuildItemSlot()을 호출하여 업데이트합니다.
    /// </summary>
    public void PlaceItem(InventoryItem item, int X, int Y)
    {
        Assert.IsFalse(X < 0 || Y < 0 || X + item.Width > Width || Y + item.Height > Height);
        _placements.Add(new ItemPlacement(item, X, Y));
        RebuildItemSlot();
    }
    public void PickUpAt(int X, int Y)
    {
        InventoryItem item = GetItemAt(X, Y);
        for (int i = _placements.Count - 1; i >= 0; i--)
        {
            if (_placements[i].Item == item)
            {
                _placements.RemoveAt(i);
                break;
            }
        }
        RebuildItemSlot();
    }
    /// <summary>
    /// 지정된 위치의 아이템을 제거합니다. _placements에서만 제거하고, ItemSlot은 RebuildItemSlot()을 호출하여 업데이트합니다.
    /// </summary>
    public void PickUp(InventoryItem item)
    {
        for (int i = _placements.Count - 1; i >= 0; i--)
        {
            if (_placements[i].Item == item)
            {
                _placements.RemoveAt(i);
                break;
            }
        }
        RebuildItemSlot();
    }

    /// <summary>
    /// 지정된 inventory좌표에 있는 아이템을 찾습니다.
    /// </summary>
    public InventoryItem GetItemAt(int x, int y)
    {
        // 유효성 확인
        Assert.IsFalse(x < 0 || y < 0 || x >= Width || y >= Height);
        Assert.IsFalse(ItemSlot[y, x] <= 0);

        // _placements에서 이 좌표를 실제로 덮는 아이템 찾기
        foreach (var placement in _placements)
        {
            var item = placement.Item;
            int localX = x - placement.X;
            int localY = y - placement.Y;
            
            // placement item이 점유하는 slotItem의 범위를 탐지
            if (localX >= 0 && localY >= 0 && 
                localX < item.Width && localY < item.Height &&
                item.GridShape[localY, localX] == 1)
            {
                return item;
            }
        }

        return null;
    }

    /// <summary>
    /// 아이템의 현재 위치를 가져옵니다.
    /// </summary>
    public (int X, int Y) GetItemPos(InventoryItem item)
    {
        foreach (var p in _placements)
            if(item == p.Item)
                return (p.X, p.Y);
        return (0, 0);
    }

    /// <summary>
    /// _placements를 읽어와서 ItemSlot을 재구성합니다.
    /// </summary>
    private void RebuildItemSlot()
    {
        // ItemSlot 초기화
        ItemSlot = new int[Height, Width];

        // _placements의 모든 아이템을 기반으로 ItemSlot 재구성
        foreach (var placement in _placements)
        {
            var item = placement.Item;
            for (int y = 0; y < item.GridShape.GetLength(0); y++)
            {
                for (int x = 0; x < item.GridShape.GetLength(1); x++)
                {
                    if (item.GridShape[y, x] == 1)
                    {
                        ItemSlot[placement.Y + y, placement.X + x]++;
                    }
                }
            }
        }
    }

}