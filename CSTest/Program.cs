class InventoryUI
{
    public static void FindItem(Action hook)
    {
        hook?.Invoke();
    }
}
class Program
{
    void Asd()
    {
        
    }
    static void Main()
    {
        InventoryUI.FindItem(() => Console.WriteLine("포션찾기"));
        InventoryUI.FindItem(() => Console.WriteLine("검찾기"));
        InventoryUI.FindItem(() => Console.WriteLine("방패찾기"));
    }
}
