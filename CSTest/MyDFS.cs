public class MyDFS
{
    int value;
    List<MyDFS> nodeList; // 인접 노드
    public MyDFS()
    {
        nodeList = new List<MyDFS>();
    }
    void DFS()
    {
        Console.WriteLine($"value: {value}, node: {nodeList}");
        foreach(MyDFS node in nodeList)
        {
            node.DFS();
        }
    }
}