public class FloatDouble
{
    public FloatDouble()
    {
        float f = 2.0f;
        double d = 1.1;

        Console.WriteLine($"f: {f}, d: {d}");
        Console.WriteLine($"{f - d}");               // 0.8999999999...
        Console.WriteLine(Convert.ToDecimal(f - d)); // float과 double은 2진수 체계로 처리되지만 Decimal은 십진수로 표현되기 때문에 더 정확하다.
                                                     // 0.9
        decimal dc1 = 0m;
        decimal dc2 = 12.34m;
        decimal.TryParse("12.34", out dc1);          // decimal 변수는 M(m)을 접미사로 사용해야 합니다.
        Console.WriteLine($"{dc1}, {dc2}");
    }
}