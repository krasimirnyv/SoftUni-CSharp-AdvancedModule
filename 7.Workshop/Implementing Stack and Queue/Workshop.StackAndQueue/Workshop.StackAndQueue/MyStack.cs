namespace Workshop.StackAndQueue;

public class MyStack<TValue>
{
    private const int DefaultCapacity = 4;
 
    private TValue[] _buffer;
    private int _count;
 
    public MyStack() : this(DefaultCapacity)
    {
    }
 
    public MyStack(int capacity)
    {
        this._buffer = new TValue[capacity];
    }
 
    public void Push(TValue value)
    {
        this.GrowIfNecessary();
 
        this._buffer[this._count] = value;
        this._count++;
    }
 
    public TValue Peek()
    {
        this.ValidateNotEmpty();
        return this._buffer[this._count - 1];
    }
 
    public TValue Pop()
    {
        this.ValidateNotEmpty();
        TValue poppedValue = this._buffer[this._count - 1];
 
        this._buffer[this._count - 1] = default;
        this._count--;
 
        return poppedValue;
    }
 
    public TValue[] ToArray()
    {
        TValue[] result = new TValue[this._count];
        Array.Copy(this._buffer, result, this._count);
        Array.Reverse(result);
        return result;
    }
 
    private void ValidateNotEmpty()
    {
        if (this._count == 0)
            throw new InvalidOperationException("The requested operation cannot be executed because the stack is empty.");
    }
 
    private void GrowIfNecessary()
    {
        if (this._count < this._buffer.Length) return;
 
        TValue[] newBuffer = new TValue[this._buffer.Length * 2];
        Array.Copy(this._buffer, newBuffer, this._buffer.Length);
        this._buffer = newBuffer;
    }
}