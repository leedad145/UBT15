class Program
{
    static void Main()
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(),int.Parse);
        int output = input[0] + input[1];
        Console.Write(output);
    }
}