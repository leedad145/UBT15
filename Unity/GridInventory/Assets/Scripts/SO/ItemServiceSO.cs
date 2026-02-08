using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemServiceSO", menuName = "Scriptable Objects/InventoryItemServiceSO")]
public class ItemServiceSO : ScriptableObject
{
    public ItemService Service { get; private set; }
    public void Init()
    {
        Service = new ItemService();
    }
}
