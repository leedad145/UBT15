class Program
{
    static void Main()
    {
        
    }
}

class Parent
{
    public virtual void Foo() {}
    public virtual void Boo() {}
}
class Child : Parent
{   
    // {
    //     public virtual void Foo() {}
    //     public virtual void Boo() {}
    // }
    public override void Foo() {}
    public override void Boo() {}
}