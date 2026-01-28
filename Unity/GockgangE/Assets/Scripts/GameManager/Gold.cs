public class Gold
{
    public int _value;
    public void AddGold(int value)
    {
        _value += value;
    }

    public void SpendGold(int value)
    {
        _value -= value;
        if (_value < 0) _value = 0;
    }    
}