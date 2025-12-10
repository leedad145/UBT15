public class NapaCabbage
{
    static List<(int, int, bool)> K;
    public static void RunTest()
    {   
        
        int T = 0; // 테스트 케이스
        int[] inputInfo = new int[3]; // 가로 세로 배추 갯수
        List<(int, int, bool)> K = new List<(int, int, bool)>();
        T = int.Parse(Console.ReadLine());
        string[] str = Console.ReadLine().Split();


        int count = 0;
        foreach(string s in str)
        {
            inputInfo[count] = int.Parse(s);
            count++;
        }
        for(int i = 0; i < inputInfo[2]; i++)
        {
            string[] pos = Console.ReadLine().Split();
            int posX = int.Parse(pos[0]);
            int posY = int.Parse(pos[1]);
            K.Add((posX, posY, false));
        }
        int totalWorm = 0;
        int worm = 0;
        // 위에서 부터 탐색 처음 배추를 만나면 worm++
        // 주변탐색 후 방문한 곳이 있다면 worm--
        K.Sort();
        foreach((int, int, bool) k in K)
        {
            worm = MDFS(k, ref worm);
            totalWorm += worm;
        }
        Console.Write(worm);
    }
    static int MDFS((int, int, bool) k, ref int worm)
    {
        for(int i = 0; i < K.Count; i++)
        {
            if(k == (K[i].Item1, K[i].Item2, false))
            {
                worm++;
                K[i] = (K[i].Item1, K[i].Item2, true);
                if(K.Contains((K[i].Item1 + 1, K[i].Item2, false)))
                {
                    return MDFS((K[i].Item1 + 1, K[i].Item2, false), ref worm) + worm - 1;
                }
                if(K.Contains((K[i].Item1 - 1, K[i].Item2, false)))
                {
                    return MDFS((K[i].Item1 - 1, K[i].Item2, false), ref worm);
                }
                else if(K.Contains((K[i].Item1, K[i].Item2 + 1, false)))
                {
                    return MDFS((K[i].Item1, K[i].Item2 + 1, false), ref worm) + worm - 1;
                }
                else if(K.Contains((K[i].Item1, K[i].Item2 + 1, false)))
                {
                    return MDFS((K[i].Item1, K[i].Item2 + 1, false), ref worm) + worm - 1;
                }
            }
        }
        return worm;
    }
}