using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemServiceSO", menuName = "Scriptable Objects/InventoryItemServiceSO")]
public class InventoryItemServiceSO : ScriptableObject
{
    public InventoryItemService Service { get; private set; }
    public void Init()
    {
        Service = new InventoryItemService();
    }
}
