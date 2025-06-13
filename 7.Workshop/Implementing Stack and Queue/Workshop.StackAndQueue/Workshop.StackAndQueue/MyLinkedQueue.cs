using System.Collections;

namespace Workshop.StackAndQueue;

public class MyLinkedQueue<TValue> : IEnumerable<TValue>
{
    private readonly MyLinkedQueueNode<TValue> _begin;
    private MyLinkedQueueNode<TValue> _end;
    private int _count;
 
    public MyLinkedQueue()
    {
        this._begin = new MyLinkedQueueNode<TValue>();
        this._end = this._begin;
    }
 
    public void Enqueue(TValue value)
    {
        MyLinkedQueueNode<TValue> newNode = new MyLinkedQueueNode<TValue> { Value = value };
        this._end.Next = newNode;
        this._end = newNode;
 
        this._count++;
    }
 
    public TValue Peek()
    {
        this.ValidateNotEmpty();
        return this._begin.Next.Value;
    }
 
    public TValue Dequeue()
    {
        this.ValidateNotEmpty();
 
        MyLinkedQueueNode<TValue> nodeToRemove = this._begin.Next;
 
        TValue removedValue = nodeToRemove.Value;
        nodeToRemove.Value = default;
 
        this._begin.Next = nodeToRemove.Next;
        nodeToRemove.Next = null;
 
        this._count--;
        if (this._count == 0)
            this._end = this._begin;
 
        return removedValue;
    }
    
    public IEnumerator<TValue> GetEnumerator()
    {
        MyLinkedQueueNode<TValue> iter = this._begin.Next;
        for (int i = 0; i < this._count; i++, iter = iter.Next)
        {
            yield return iter.Value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
 
    private void ValidateNotEmpty()
    {
        if (this._count == 0)
            throw new InvalidOperationException("The requested operation cannot be executed because the queue is empty.");
    }
}
 
public class MyLinkedQueueNode<TValue>
{
    public TValue Value { get; set; }
    public MyLinkedQueueNode<TValue> Next { get; set; }
}