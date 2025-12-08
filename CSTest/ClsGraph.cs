using System;
using System.Collections.Generic;

public class clsGraph
{
    private int Vertices; // 정점(Vertex)의 수
    private List<Int32>[] adj; // 인접 리스트 (각 정점과 연결된 정점 목록)

    // 생성자
    public clsGraph(int v)
    {
        Vertices = v;
        adj = new List<Int32>[v];
        // 모든 정점에 대해 인접 리스트 초기화
        for (int i = 0; i < v; i++)
        {
            adj[i] = new List<Int32>();
        }
    }

    // 간선 추가 (방향 그래프 v -> w)
    public void AddEdge(int v, int w)
    {
        adj[v].Add(w);
    }
    // DFS traversal (Iterative, Stack-based)
    
    public void DFS(int startNode)
    {
        // 방문 여부 체크 배열
        bool[] visited = new bool[Vertices];
        // DFS는 Stack 사용
        Stack<int> stack = new Stack<int>();

        // 시작 노드 설정
        visited[startNode] = true;
        stack.Push(startNode);

        Console.Write("DFS Traversal (Starting from " + startNode + "): ");

        while (stack.Count != 0)
        {
            // 스택에서 정점을 꺼냄
            int currentNode = stack.Pop();
            Console.Write(currentNode + " ");

            // 인접한 모든 정점을 순회
            // DFS는 가장 최근에 스택에 넣은(가장 깊은) 인접 노드를 먼저 탐색합니다.
            // 일반적으로 인접 리스트의 순서와 반대로 Push하면 깊이 우선 탐색의 '깊이'를 유지하기 쉬울 수 있습니다.
            // 여기서는 예제 코드를 따라 순서대로 Push하겠습니다.
            foreach (int nextNode in adj[currentNode])
            {
                if (!visited[nextNode])
                {
                    visited[nextNode] = true;
                    stack.Push(nextNode);
                }
            }
        }
        Console.WriteLine();
    }
    // BFS traversal (Queue-based)
    public void BFS(int startNode)
    {
        // 방문 여부 체크 배열
        bool[] visited = new bool[Vertices];
        // BFS는 Queue 사용
        Queue<int> queue = new Queue<int>();

        // 시작 노드 설정
        visited[startNode] = true;
        queue.Enqueue(startNode);

        Console.Write("BFS Traversal (Starting from " + startNode + "): ");

        while (queue.Count != 0)
        {
            // 큐에서 정점을 꺼냄
            int currentNode = queue.Dequeue();
            Console.Write(currentNode + " ");

            // 인접한 모든 정점을 순회
            // 인접한 노드를 모두 큐에 넣고, 다음 레벨로 넘어갑니다.
            foreach (int nextNode in adj[currentNode])
            {
                if (!visited[nextNode])
                {
                    visited[nextNode] = true;
                    queue.Enqueue(nextNode);
                }
            }
        }
        Console.WriteLine();
    }
}