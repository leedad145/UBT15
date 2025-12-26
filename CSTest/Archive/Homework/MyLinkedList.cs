public class MyLinkedList<T>
{
    T? _val;                // 값
    static int count = 0;   // LinkedList에 등록된 실제 데이터 길이
    MyLinkedList<T>? prev;  // 이전 노드, 처음생성 객체가 tail 가르킴
    MyLinkedList<T>? next;  // 다음 노드, 처음생성 객체가 head 가르킴
    public MyLinkedList()
    {
        prev = this;
    }
    public MyLinkedList<T>? this[int index]
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
                return temp;
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
                temp = value; 
            }
            else
            {
                Console.WriteLine($"Set: index: {index} [0 ~ {count-1}]초과");
            }
        }
    }
    public void GetVal()
    {
        Console.Write(_val);
    }
    public void AddFirst(T val)
    {
        next.prev = new MyLinkedList<T>();
        next.prev._val = val;
        next.prev.prev = this;
        next.prev.next = next;
        next = next.prev;

        count++;
    }
    public void AddIndex(int index, T val)
    {
        MyLinkedList<T> me = this[index-1];
        me.next.prev = new MyLinkedList<T>();
        me.next.prev._val = val;
        me.next.prev.prev = me;
        me.next.prev.next = me.next;
        me.next = me.next.prev;

        count++;
    }
    public void AddLast(T val)
    {
        prev.next = new MyLinkedList<T>();
        prev.next.prev = prev;
        prev.next._val = val;
        prev = prev.next;

        count++;
    }
    public void RemoveAt(int index)
    {
        if(index > count)
        {
            Console.Write($"RemoveAt: index: {index} [0 ~ {count-1}]초과");
            return;
        }
        MyLinkedList<T>? temp = next;
        for(int i = 0; i < index; i++)
        {
            temp = temp.next;
        }
        Remove(temp);
    }
    public void Remove(MyLinkedList<T> node)
    {
        node.prev.next = node.next;
        if(node.next != null)
            node.next.prev = node.prev;
        else // 마지막 노드를 없엤으면 Tail을 바꿔준다.
            prev = node.prev;
        count--;
    }
}
