namespace Workshop.StackAndQueue;

public class MyQueue
{
    private const int DefaultCapacity = 4;
 
    private int[] _buffer;
    private int _count, _start;
 
    public MyQueue() : this(DefaultCapacity)
    {
    }
 
    public MyQueue(int capacity)
    {
        this._buffer = new int[capacity];
    }
 
    public void Enqueue(int value)
    {
        this.GrowIfNecessary();
 
        int index = this.GetBufferIndex(this._count);
        this._buffer[index] = value;
        this._count++;
    }
 
    public int Peek()
    {
        this.ValidateNotEmpty();
        return this._buffer[this._start];
    }
 
    public int Dequeue()
    {
        this.ValidateNotEmpty();
 
        int removedVal = this._buffer[this._start];
        this._buffer[this._start] = default;
 
        this._start = this.GetBufferIndex(1);
        this._count--;
 
        return removedVal;
    }
 
    public int[] ToArray()
    {
        int[] result = new int[this._count];
 
        for (int i = 0; i < this._count; i++)
            result[i] = this._buffer[GetBufferIndex(i)];
 
        return result;
    }
 
    private int GetBufferIndex(int offset)
        => (this._start + offset) % this._buffer.Length;
 
    private void ValidateNotEmpty()
    {
        if (this._count == 0)
            throw new InvalidOperationException("The requested operation cannot be executed because the queue is empty.");
    }
 
    private void GrowIfNecessary()
    {
        if (this._count < this._buffer.Length) return;
 
        int[] newBuffer = new int[this._buffer.Length * 2];
 
        int rotate = this._buffer.Length - this._start;
        Array.Copy(this._buffer, this._start, newBuffer, 0, rotate);
        Array.Copy(this._buffer, 0, newBuffer, rotate, this._start);
 
        this._buffer = newBuffer;
        this._start = 0;
    }
}