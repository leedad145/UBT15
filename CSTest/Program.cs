using System;
using System.Runtime.CompilerServices;
//교과서
//https://thebook.io/006890/
//노션
//https://aquatic-care-bc3.notion.site/Unity-15th-2b0715f54fd48008bcb4f25c2bb6f983
//구글드라이브
//https://drive.google.com/drive/folders/1xP_gRcH-dhrZyV2zBjc1f_eEOVFrEOrF?dmr=1&ec=wgc-drive-globalnav-goto
class Program
{   
    static void Main()
    {
        clsGraph graph = new clsGraph(4);
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 2);
        graph.AddEdge(2, 0);
        graph.AddEdge(2, 3);
        graph.AddEdge(3, 3);

        // BFS 실행 (시작 노드: 2)
        // 예상 결과: 2 0 3 1
        graph.BFS(2);

        // DFS 실행 (시작 노드: 2)
        // (스택에 0과 3이 Push될 때 3이 먼저 Pop되어 탐색될 수 있음)
        // 예상 결과 (출력 순서에 따라 다를 수 있음): 2 3 0 1
        graph.DFS(2);
    }
}
