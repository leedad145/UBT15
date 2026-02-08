using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] ItemServiceSO _inventoryItemServiceSO;
    [SerializeField] InventoryServiceSO _inventoryServiceSO;
    void Awake()
    {
        _inventoryItemServiceSO.Init();
        _inventoryServiceSO.Init();
    }
}
