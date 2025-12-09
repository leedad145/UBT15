public static class Star
{
    //baekjoon
    //1 1 0 0 1 0 0 0 0 1 1 0 0 1 2 0 0 0 0 0 0 0 0 0 0 0
    public static void RunTest()
    {
        int[] array = new int[26];

        string S = Console.ReadLine();
        foreach(char c in S)
        {
            array[c - 'a'] += 1;
        }
        foreach(int i in array)
        {
            Console.Write($"{i} ");
        }
    }
}