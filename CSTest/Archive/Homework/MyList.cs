public class MyList<T>
{
    T[] arr = new T[1];
    int length = 0; // 배열에 등록된 실제 데이터 길이
    public T this[int index]
    {
        get
        {
            if(0 <= index && index < length)
            {
                return arr[index];   
            }
            Console.Write("index범위 초과 ");

#pragma warning disable CS8603 // 가능한 null 참조 반환입니다.
            return default;
#pragma warning restore CS8603 // 가능한 null 참조 반환입니다.
        }
        set
        {
            if(0 <= index && index < length)
            {
                arr[index] = value;
            }
        }
    }
    public void Add(T value)
    {
        length++;
        if (arr.Length <= length)
        {
            T[] arrTemp = new T[length * 2];
            for(int i = 0; i < arr.Length; i++)
            {
                arrTemp[i] = arr[i];
            }
            arr = arrTemp;
        }
        arr[length] = value;
    }
    public void RemoveAt(int index)
    {
        length--;
        for(int i = index; i < arr.Length - 1; i++)
        {
            arr[i] = arr[i + 1];
        }
    }
}
/*
public class MyLinkedList<T>
{
    T val;
    int length = 0; // LinkedList에 등록된 실제 데이터 길이
    MyLinkedList<T> link;
     public T this[int index]
    {
        get
        {
            if(0 <= index && index < length)
            {
                MyLinkedList<T> temp = link;
                for(int i = 0; i < index; i++)
                {
                    temp = temp.link;
                }
                return temp.val;
            }
            Console.Write("index범위 초과 ");
            return default;
        }
        set
        {
            if(0 <= index && index < length)
            { 
                MyLinkedList<T> temp = link;
                for(int i = 0; i < index; i++)
                {
                    temp = temp.link;
                }
                temp.val = value; 
            }
        }
    }
    public void Add(T val)
    {
        length++;
        MyLinkedList<T> Temp = link;
        for(int i = 0; i < length - 1; i++)
        {
            Temp = Temp.link;
        }
        Temp.link.val = val;
    }
    public void RemoveAt(int index)
    {
        MyLinkedList<T> Temp = link;
        for(int i = 0; i < index - 1; i++)
        {
            Temp = Temp.link;
        }
        Temp = Temp.link.link;
        length--;
    }
}
*/