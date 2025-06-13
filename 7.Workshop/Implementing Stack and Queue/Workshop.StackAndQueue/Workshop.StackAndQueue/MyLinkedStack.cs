using System.Collections;

namespace Workshop.StackAndQueue;

public class MyLinkedStack<TValue> : IEnumerable<TValue>
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
    
    public IEnumerator<TValue> GetEnumerator()
    {
        MyLinkedStackNode<TValue> iterator = this._begin.Next;
        for (int i = 0; i < this._count; i++, iterator = iterator.Next)
        {
            yield return iterator.Value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
 
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