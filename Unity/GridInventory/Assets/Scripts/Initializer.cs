using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] InventoryItemServiceSO _inventoryItemServiceSO;
    [SerializeField] InventoryServiceSO _inventoryServiceSO;
    void Awake()
    {
        _inventoryItemServiceSO.Init();
        _inventoryServiceSO.Init();
    }
}
