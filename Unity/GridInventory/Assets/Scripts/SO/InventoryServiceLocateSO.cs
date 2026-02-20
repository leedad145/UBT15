using UnityEngine;

[CreateAssetMenu(fileName = "InventoryServiceSO", menuName = "Scriptable Objects/InventoryServiceSO")]
public class InventoryServiceLocateSO : ScriptableObject
{
    public InventoryService Service { get; private set; }
    public void Init(IInventoryRepository inventoryRepository)
    {
        Service = new InventoryService(inventoryRepository);
    }
}
