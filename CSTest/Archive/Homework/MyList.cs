public class MyList<T>
{
    int capacity = 1;
    int count = 0; // 배열에 등록된 실제 데이터 길이

    T?[] arr = new T[1];
    public T? this[int index]
    {
        get
        {
            if(0 <= index && index < count)
            {
                return arr[index];   
            }
            Console.Write("index범위 초과 ");

            return default;
        }
        set
        {
            if(0 <= index && index < count)
            {
                arr[index] = value;
            }
            Console.Write("index범위 초과 ");
        }
    }
    public void Add(T value)
    {
        if (capacity <= count)
        {
            T?[] arrTemp = new T[capacity * 2];
            for(int i = 0; i < count; i++)
            {
                arrTemp[i] = arr[i];
            }
            arr = arrTemp;
        }
        arr[count] = value;
        count++;
    }
    public void RemoveAt(int index)
    {
        for(int i = index; i < count - 1; i++)
        {
            arr[i] = arr[i + 1];
        }
        count--;
    }
}