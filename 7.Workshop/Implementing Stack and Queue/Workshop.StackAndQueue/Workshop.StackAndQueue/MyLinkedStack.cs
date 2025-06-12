namespace Workshop.StackAndQueue;

public class MyLinkedStack<TValue>
{
    private readonly MyLinkedStackNode<TValue> _begin = new MyLinkedStackNode<TValue>();
    private int _count;
 
    public void Push(TValue value)
    {
        this._begin.Next = new MyLinkedStackNode<TValue> { Value = value, Next = this._begin.Next };
        this._count++;
    }
 
    public TValue Peek()
    {
        this.ValidateNotEmpty();
        return this._begin.Next.Value;
    }
 
    public TValue Pop()
    {
        this.ValidateNotEmpty();
 
        MyLinkedStackNode<TValue> nodeToRemove = this._begin.Next;
        this._begin.Next = nodeToRemove.Next;
        TValue poppedValue = nodeToRemove.Value;
 
        nodeToRemove.Next = null;
        nodeToRemove.Value = default;
 
        this._count--;
 
        return poppedValue;
    }
 
    public TValue[] ToArray()
    {
        TValue[] result = new TValue[this._count];
 
        MyLinkedStackNode<TValue> iter = this._begin.Next;
        for (int i = 0; i < this._count; i++, iter = iter.Next)
            result[i] = iter.Value;
 
        return result;
    }
 
    private void ValidateNotEmpty()
    {
        if (this._count == 0)
            throw new InvalidOperationException("The requested operation cannot be executed because the stack is empty.");
    }
}
 
public class MyLinkedStackNode<TValue>
{
    public TValue Value { get; set; }
    public MyLinkedStackNode<TValue> Next { get; set; }
}