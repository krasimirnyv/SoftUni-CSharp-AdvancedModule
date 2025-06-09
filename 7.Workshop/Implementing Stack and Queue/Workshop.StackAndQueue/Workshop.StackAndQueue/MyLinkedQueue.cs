namespace Workshop.StackAndQueue;

public class MyLinkedQueue
{
    private readonly MyLinkedQueueNode _begin;
    private MyLinkedQueueNode _end;
    private int _count;
 
    public MyLinkedQueue()
    {
        this._begin = new MyLinkedQueueNode();
        this._end = this._begin;
    }
 
    public void Enqueue(int value)
    {
        MyLinkedQueueNode newNode = new MyLinkedQueueNode { Value = value };
        this._end.Next = newNode;
        this._end = newNode;
 
        this._count++;
    }
 
    public int Peek()
    {
        this.ValidateNotEmpty();
        return this._begin.Next.Value;
    }
 
    public int Dequeue()
    {
        this.ValidateNotEmpty();
 
        MyLinkedQueueNode nodeToRemove = this._begin.Next;
 
        int removedValue = nodeToRemove.Value;
        nodeToRemove.Value = default;
 
        this._begin.Next = nodeToRemove.Next;
        nodeToRemove.Next = null;
 
        this._count--;
        if (this._count == 0)
            this._end = this._begin;
 
        return removedValue;
    }
 
    public int[] ToArray()
    {
        int[] result = new int[this._count];
 
        MyLinkedQueueNode iter = this._begin.Next;
        for (int i = 0; i < this._count; i++, iter = iter.Next)
            result[i] = iter.Value;
 
        return result;
    }
 
    private void ValidateNotEmpty()
    {
        if (this._count == 0)
            throw new InvalidOperationException("The requested operation cannot be executed because the queue is empty.");
    }
}
 
public class MyLinkedQueueNode
{
    public int Value { get; set; }
    public MyLinkedQueueNode Next { get; set; }
}