public class MyBFS
{
    List<int>[] tree;
    List<int> visited;
    Queue<int> q = new Queue<int>();
    public MyBFS()
    {
        tree = new List<int>[]
        {
            new List<int>(){1, 2},
            new List<int>(){3, 4},
            new List<int>(){5, 6},
            new List<int>(),
            new List<int>(),
            new List<int>(),
            new List<int>(),
        };
        visited = new List<int>();
        BFS(0);
        foreach(int v in visited)
        {
            Console.WriteLine($"node: {v}");
        }
    }
    public void BFS(int start)
    {
        visited.Add(start);
        q.Enqueue(start);

        while(q.Count > 0)
        {
            int now = q.Dequeue();
            if (tree[now] != null)
            {
                foreach(int next in tree[now])
                {
                    if (!visited.Contains(next))
                    {
                        visited.Add(next);
                        q.Enqueue(next);
                    }
                }
            }
        }
        
    }
}