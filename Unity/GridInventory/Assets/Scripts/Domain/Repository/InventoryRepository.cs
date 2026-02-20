using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

public sealed class InventoryRepository : IInventoryRepository
{
    private readonly string _dataPath;
    private int _width;
    private int _height;
    public InventoryRepository(string dataPath, int width, int height)
    {
        Assert.IsFalse(string.IsNullOrEmpty(dataPath));

        _dataPath = dataPath;
        _width = width;
        _height = height;
    }

    public Inventory Load()
    {
        if (File.Exists(_dataPath) == false)
        {
            return Inventory.CreateEmpty(_width, _height);
        }

        string json = File.ReadAllText(_dataPath);

        // 2. Json에서 모델 개체 생성
        InventoryModel inventoryModel = JsonUtility.FromJson<InventoryModel>(json);

        // 3. 모델 개체에서 도메인 개체 생성
        List<ItemPlacement> items = inventoryModel.data
            .Select(model => 
            new ItemPlacement(
                new InventoryItem(
                    model.serial_number, 
                    new ItemId(model.item_id)),
                    model.x, 
                    model.y ))
            .ToList();
        Inventory inventory = new Inventory(_width, _height, items);

        return inventory;
    }

    public void Save(Inventory inventory)
    {
        Assert.IsNotNull(inventory);

        InventoryModel inventoryModel = new()
        {
            data = inventory.Placements
                .Select(placement => new InventoryItemModel()
                {
                    serial_number = placement.Item.SerialNumber,
                    item_id = placement.Item.ItemId.RawId,
                    x = placement.X,
                    y = placement.Y
                })
                .ToArray()
        };

        string json = JsonUtility.ToJson(inventoryModel, true);

        File.WriteAllText(_dataPath, json); 
    }
}