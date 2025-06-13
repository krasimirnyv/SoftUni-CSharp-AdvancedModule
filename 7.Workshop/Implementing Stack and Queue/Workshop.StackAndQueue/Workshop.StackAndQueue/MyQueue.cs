using System.Collections;

namespace Workshop.StackAndQueue;

public class MyQueue<TValue> : IEnumerable<TValue>
{
    private const int DefaultCapacity = 4;
 
    private TValue[] _buffer;
    private int _count, _start;
 
    public MyQueue() : this(DefaultCapacity)
    {
    }
 
    public MyQueue(int capacity)
    {
        this._buffer = new TValue[capacity];
    }
 
    public void Enqueue(TValue value)
    {
        this.GrowIfNecessary();
 
        int index = this.GetBufferIndex(this._count);
        this._buffer[index] = value;
        this._count++;
    }
 
    public TValue Peek()
    {
        this.ValidateNotEmpty();
        return this._buffer[this._start];
    }
 
    public TValue Dequeue()
    {
        this.ValidateNotEmpty();
 
        TValue removedVal = this._buffer[this._start];
        this._buffer[this._start] = default;
 
        this._start = this.GetBufferIndex(1);
        this._count--;
 
        return removedVal;
    }
    
    public void Clear()
    {
        Array.Clear(this._buffer);
        this._start = 0; 
        this._count = 0;
    }
    
    public IEnumerator<TValue> GetEnumerator()
    {
        for (int i = 0; i < this._count; i++)
        {
            yield return this._buffer[this.GetBufferIndex(i)];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    private void GrowIfNecessary()
    {
        if (this._count < this._buffer.Length) return;
 
        TValue[] newBuffer = new TValue[this._buffer.Length * 2];
 
        int rotate = this._buffer.Length - this._start;
        Array.Copy(this._buffer, this._start, newBuffer, 0, rotate);
        Array.Copy(this._buffer, 0, newBuffer, rotate, this._start);
 
        this._buffer = newBuffer;
        this._start = 0;
    }
    
    private int GetBufferIndex(int offset)
        => (this._start + offset) % this._buffer.Length;
 
    private void ValidateNotEmpty()
    {
        if (this._count == 0)
            throw new InvalidOperationException("The requested operation cannot be executed because the queue is empty.");
    }
}