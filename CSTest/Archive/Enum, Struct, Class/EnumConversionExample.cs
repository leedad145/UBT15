public class EnumDonversionExample
{
    public enum Season
    {
        Spring = 1,
        Sunmmer,
        Autumn,
        Winter
    }
    public EnumDonversionExample()
    {
        Season a = Season.Autumn;
        Console.WriteLine($"Inergral value of {a} is {(int)a}");
        Season b = (Season)1;
        Console.WriteLine(b);
        Season c = 0; // 0과 암시적 변환이 일어나기 때문에 0을 포함하는 것이 버그를 없에는데 유리하다 
        Console.WriteLine(c);

    }
}