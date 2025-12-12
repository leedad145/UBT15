public class SumChar //10808
{
    //baekjoon
    //1 1 0 0 1 0 0 0 0 1 1 0 0 1 2 0 0 0 0 0 0 0 0 0 0 0
    public SumChar()
    {
        int[] array = new int[26];

        string str = Console.ReadLine();
        foreach(char c in str)
        {
            array[c - 'a'] += 1;
        }
        foreach(int i in array)
        {
            Console.Write($"{i} ");
        }
    }
}