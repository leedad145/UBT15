using UnityEngine;

[CreateAssetMenu(fileName = "InventoryRepositorySO", menuName = "Scriptable Objects/InventoryRepositorySO")]
public class InventoryRepositorySO : ScriptableObject
{
    public IInventoryRepository Repository;
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    public void Init()
    {
        Repository = new InventoryRepository(Application.persistentDataPath, _width, _height);
    }
}
