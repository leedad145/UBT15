public class StandardBackpack
{
    static List<(int W, int V)> backpack;
    static int[,] DP;    // 무게의 최대 가치
    public StandardBackpack()
    {
        // 무게 W, 가치 V
        backpack = new List<(int W, int V)>();
        
        // 물품 수 N, 총 무게 K 입력
        string[] setInput = Console.ReadLine().Split();
        int N = int.Parse(setInput[0]);
        int K = int.Parse(setInput[1]);
        for(int i = 0; i < N; i++) // 무게 W 와 가치 V 받아서 백팩에 넣기
        {
            string[] objInput = Console.ReadLine().Split();
            int W = int.Parse(objInput[0]);
            int V = int.Parse(objInput[1]);
            backpack.Add((W, V));
        }
        DP = new int[K+1,K+1];
        Console.WriteLine(BestValue(K));
    }
    static int BestValue(int maxW, int index = 0)
    {
        if(DP[maxW,index] != 0)
        {
            return DP[maxW,index];
        }
        if(backpack.Count == index + 1) 
        {
            return 0;
        }

        // 물건 추출;
        (int W, int V) obj = backpack[index];

        // 공간이 있으면 넣을지 말지
        if(maxW >= obj.W)
        {
            // 버리는 것과 넣는 것중 더 결과가 큰 행동
            DP[maxW,index] = Math.Max
            (
                BestValue(maxW, index + 1),                  // 버림
                obj.V + BestValue(maxW - obj.W, index + 1)   // 넣음
            );
            return DP[maxW,index];
        }
        else // 공간이 없으면 버린다.
        {
            DP[maxW,index] = BestValue(maxW, index + 1);
            return DP[maxW,index];
        }
    }
}