using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] InventoryServiceLocateSO _inventoryServiceLocateSO;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnApplicationQuit()
    {
        _inventoryServiceLocateSO.Service.Save();
    }
}
