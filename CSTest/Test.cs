public class MyLinkedListNode
{
    private int _value;
    public MyLinkedListNode _prev;
    public MyLinkedListNode _next;
    public MyLinkedListNode(MyLinkedListNode prev, int value)
    {
        _next = prev._next;
        prev._next = this;

        _prev = prev;
        _value = value;
    }
    void Add(MyLinkedListNode next, int value)
    {
        _next = next;

        next._prev = this;
        next._value = value;
    }
    void remove()
    {
        _prev._next = _next;
        _next._prev = _prev;
    }
}