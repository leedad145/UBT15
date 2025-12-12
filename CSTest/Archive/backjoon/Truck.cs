public class Truck //2979
{
    public Truck()
    {
        int[] price = new int[3];
        int[] time = new int[100];

        string[] readPrice = Console.ReadLine().Split();
        int count = 0;
        foreach(string str in readPrice)
        {
            price[count] = int.Parse(str);
            count++;
        }
        for (int i = 0; i < 3; i++)
        {
            string[] readTime = Console.ReadLine().Split();
            for(int j = int.Parse(readTime[0]) - 1; j < int.Parse(readTime[1]) - 1; j++)
            {
                time[j] += 1;
            }
        }
        int totalPrice = 0;
        foreach(int i in time)
        {
            if(i == 1)
            {
                totalPrice += price[0];
            }
            else if(i == 2)
            {
                totalPrice += price[1] * 2;
            }
            else if(i == 3)
            {
                totalPrice += price[2] * 3;
            }
        }
        Console.Write(totalPrice);
    }
}