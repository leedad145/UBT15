
using System.Diagnostics.CodeAnalysis;

public class NapaCabbage //1012
{
    static bool[,] visited = new bool[50,50];
    static List<(int, int)> posList = new List<(int, int)>();
    int[] totalWorm;

    public NapaCabbage()
    {   
        int TC = 0; // 테스트 케이스
        int[] inputInfo = new int[3]; // 가로 세로 배추 갯수
#pragma warning disable CS8604 // 가능한 null 참조 인수입니다.
        TC = int.Parse(Console.ReadLine());
#pragma warning restore CS8604 // 가능한 null 참조 인수입니다.
        totalWorm = new int[TC];

        for(int tc = 0; tc < TC; tc++)
        {
            string[] str = Console.ReadLine().Split();

            for(int i = 0; i < inputInfo.Length; i++)
            {
                inputInfo[i] = int.Parse(str[i]);
            }
            for(int i = 0; i < inputInfo[2]; i++)
            {
                string[] pos = Console.ReadLine().Split();
                int posX = int.Parse(pos[0]);
                int posY = int.Parse(pos[1]);
                posList.Add((posX, posY));
                visited[posX, posY] = false;
            }
            foreach((int, int)pos in posList)
            {
                totalWorm[tc] += MDFS(pos);
            }
        }
        foreach (int w in totalWorm)
        {
            Console.WriteLine(w);
        }
    }
    static int MDFS((int, int) nowPos)
    {
        var (x, y) = nowPos;
        if (posList.Contains(nowPos) && visited[x, y] == false)
        {
            int reVal = 1;
            //Console.WriteLine($"Pos: {x},{y}");
            visited[x,y] = true;
            reVal += MDFS((x-1, y));
            reVal += MDFS((x+1, y));
            reVal += MDFS((x, y-1));
            reVal += MDFS((x, y+1));
            if (reVal >= 1)
            {
                return +1;
            }
        }
        return +0;
    }
}