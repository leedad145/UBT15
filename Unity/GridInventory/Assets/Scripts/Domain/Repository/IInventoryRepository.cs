public interface IInventoryRepository
{
    void Save(Inventory inventory);
    Inventory Load();
}