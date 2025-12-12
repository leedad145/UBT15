class DFSBFS //1260
{
    bool[] DFSvisited;
    List<int> DFSvisitedArr;
    List<int> BFSvisitedArr;
    Queue<int> q;
    Dictionary<int, List<int>> tree;  //간선트리

    public DFSBFS()
    {
        int[] inputData = new int[3]; // 0:N정점의 개수, 1:M간선의 개수, 2:V탐색 시작 위치
        string[] inputDataSetting = Console.ReadLine().Split();
        for(int i = 0; i < 3; i++)                      // inputData 설정
        {
            inputData[i] = int.Parse(inputDataSetting[i]);
        }
        
        tree = new Dictionary<int, List<int>>();
        for (int i = 1; i <= inputData[0]; i++)          // inputData[0]개 정점 생성
        {
            tree.Add(i, new List<int>{});
        }
        for (int i = 0; i < inputData[1]; i++)          // inputData[1]개 간선 생성
        {
            string[] inputM = Console.ReadLine().Split();
            int key = int.Parse(inputM[0]);
            int val = int.Parse(inputM[1]);

            tree[key].Add(val);
            tree[key].Sort();
            tree[val].Add(key);
            tree[val].Sort();
        }
        
        DFSvisited = new bool[inputData[0]];
        DFSvisitedArr = new List<int>();
        BFSvisitedArr = new List<int>();
        q = new Queue<int>();
        DFS(inputData[2]);
        BFS(inputData[2]);
        foreach(int val in DFSvisitedArr)
        {
            Console.Write(val + " ");
        }
        Console.WriteLine();
        foreach(int val in BFSvisitedArr)
        {
            Console.Write(val + " ");
        }
    }

    void DFS(int start)
    {
        if (DFSvisited[start - 1] == false)
        {
            DFSvisited[start - 1] = true;
            DFSvisitedArr.Add(start);
            foreach(int next in tree[start])
            {
                DFS(next);
            }
        }
    }
    void BFS(int start)
    {
        BFSvisitedArr.Add(start);
        q.Enqueue(start);
        while(q.Count > 0)
        {
            int now = q.Dequeue();
            foreach(int val in tree[now])
            {
                if (!BFSvisitedArr.Contains(val))
                {
                    BFSvisitedArr.Add(val);
                    q.Enqueue(val);
                }
            }
        }
    }
}