using UnityEngine;

[CreateAssetMenu(fileName = "InventoryServiceSO", menuName = "Scriptable Objects/InventoryServiceSO")]
public class InventoryServiceSO : ScriptableObject
{
    public InventoryService Service { get; private set; }
    [SerializeField] private int width;
    [SerializeField] private int height;
    public void Init()
    {
        Inventory inventory = new Inventory(width, height);
        Service = new InventoryService(inventory);
    }
}
