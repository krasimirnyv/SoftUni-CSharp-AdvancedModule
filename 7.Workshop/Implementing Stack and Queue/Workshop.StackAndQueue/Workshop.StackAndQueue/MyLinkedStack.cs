namespace Workshop.StackAndQueue;

public class MyLinkedStack
{
    private readonly MyLinkedStackNode _begin = new MyLinkedStackNode();
    private int _count;
 
    public void Push(int value)
    {
        this._begin.Next = new MyLinkedStackNode { Value = value, Next = this._begin.Next };
        this._count++;
    }
 
    public int Peek()
    {
        this.ValidateNotEmpty();
        return this._begin.Next.Value;
    }
 
    public int Pop()
    {
        this.ValidateNotEmpty();
 
        MyLinkedStackNode nodeToRemove = this._begin.Next;
        this._begin.Next = nodeToRemove.Next;
        int poppedValue = nodeToRemove.Value;
 
        nodeToRemove.Next = null;
        nodeToRemove.Value = default;
 
        this._count--;
 
        return poppedValue;
    }
 
    public int[] ToArray()
    {
        int[] result = new int[this._count];
 
        MyLinkedStackNode iter = this._begin.Next;
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
 
public class MyLinkedStackNode
{
    public int Value { get; set; }
    public MyLinkedStackNode Next { get; set; }
}