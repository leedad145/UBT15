using System;

[Serializable]
public class ItemModels
{
    public ItemModel[] data;
}

[Serializable]
public class ItemModel
{
    public int item_id;
    public string item_name;
    public int attack_power;
    public int defense;
}
