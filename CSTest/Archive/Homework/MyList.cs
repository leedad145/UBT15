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
public class MyLinkedList<T>
{
    T? _val;
    static int count = 0; // LinkedList에 등록된 실제 데이터 길이
    MyLinkedList<T>? prev; // head는 마지막 가르킴 (구현 못함)
    MyLinkedList<T>? next;
    public T? getPrevVal()
    {
        return prev._val;
    }
    public T? this[int index]
    {
        get
        {
            if(0 <= index && index < count)
            {
                MyLinkedList<T>? temp = next;
                for(int i = 0; i < index; i++)
                {
                    temp = temp.next;
                }
                return temp._val;
            }
            Console.Write($"Get: index: {index} [0 ~ {count-1}]초과");
            return default;
        }
        set
        {
            if(0 <= index && index < count)
            { 
                MyLinkedList<T>? temp = next;
                for(int i = 0; i < index; i++)
                {
                    temp = temp.next;
                }
                temp._val = value; 
            }
            else
            {
                Console.WriteLine($"Set: index: {index} [0 ~ {count-1}]초과");
            }
        }
    }
    public void Add(T val)
    {
        // 첫번째 node(head)에 val값이 입력되지 않음
        prev = Add(val, ref next, this);
    }
    public MyLinkedList<T>? Add(T val, ref MyLinkedList<T>? next, MyLinkedList<T>? me)
    {
        if(next == null)
        {
            next = new MyLinkedList<T>();
            next.prev = me;
            next._val = val;
            count++;
            return me;
        }
        return Add(val, ref next.next, next);
    }
    public void RemoveAt(int index)
    {
        MyLinkedList<T>? temp = next;
        for(int i = 0; i < index; i++)
        {
            temp = temp.next;
        }
        temp.prev.next = temp.next;
        temp.next.prev = temp.prev;
        count--;
    }
}
// MyLinkedList<int> list = new MyLinkedList<int>();//출력용
//         list.Add(1);
//         list.Add(2);
//         list.Add(3);
//         list.Add(4);
//         list.Add(5);
//         list.Add(6);
//         list.Add(7);
//         // list[0] = 1;
//         // list[1] = 2;
//         // list[2] = 3;
//         // list[3] = 4;
//         // list[4] = 5;
//         // list[5] = 6;
//         // list[6] = 7;
//         Console.Write(list[0]);
//         Console.Write(list[1]);
//         Console.Write(list[2]);
//         Console.Write(list[3]);
//         Console.Write(list[4]);
//         Console.Write(list[5]);
//         Console.WriteLine(list[6]);

//         list.RemoveAt(5);
//         Console.Write(list[0]);
//         Console.Write(list[1]);
//         Console.Write(list[2]);
//         Console.Write(list[3]);
//         Console.Write(list[4]);
//         Console.WriteLine(list[5]);
//         list[0] = 3;
//         list[1] = 4;
//         list[2] = 5;
//         list[3] = 6;
//         list[4] = 7;
//         list[5] = 8;
//         Console.Write(list[0]);
//         Console.Write(list[1]);
//         Console.Write(list[2]);
//         Console.Write(list[3]);
//         Console.Write(list[4]);
//         Console.WriteLine(list[5]);
//         Console.WriteLine(list.getPrevVal());//마지막이랑 연결 되어야 함