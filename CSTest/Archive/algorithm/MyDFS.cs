public class MyDFS
{
    bool[] visited;
    List<int>[] nodeList; // 인접 노드
    public MyDFS()
    {
        List<int>[] list = new List<int>[]
        {
            new List<int>() {1,7},
            new List<int>() {0,2,4},
            new List<int>() {1,3},
            new List<int>() {2},
            new List<int>() {1,5,6},
            new List<int>() {4},
            new List<int>() {4},
            new List<int>() {0,4,8},
            new List<int>() {7,9},
            new List<int>() {8},

        };
        nodeList = list;
        visited = new bool[list.Length];
        DFS(0);
    }
    public void DFS(int now)
    {
        Console.WriteLine($"node: {now}");
        visited[now] = true;
        foreach(int next in nodeList[now])
        {
            if(visited[next])
                continue;
            DFS(next);
        }
    }
}