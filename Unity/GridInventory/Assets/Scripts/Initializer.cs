using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] InventoryServiceLocateSO _inventoryServiceSO;
    [SerializeField] InventoryRepositorySO _inventoryRepositorySO;
    void Awake()
    {
        _inventoryRepositorySO.Init();
        _inventoryServiceSO.Init(_inventoryRepositorySO.Repository);
    }
}
