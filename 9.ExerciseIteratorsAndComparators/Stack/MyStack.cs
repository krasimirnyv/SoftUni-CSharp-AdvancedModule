using System.Collections;

namespace Stack;

public class MyStack<TValue> : IEnumerable<TValue>
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
 
    public TValue Pop()
    {
        if (!this.ValidateNotEmpty())
        {
            return default;
        }
        
        TValue poppedValue = this._buffer[this._count - 1];
 
        this._buffer[this._count - 1] = default;
        this._count--;
 
        return poppedValue;
    }
 
    public IEnumerator<TValue> GetEnumerator()
    {
        for (int i = this._count - 1; i >= 0; i--)
        {
            yield return this._buffer[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    
    private bool ValidateNotEmpty()
    {
        if (this._count == 0)
        {
            Console.WriteLine("No elements");
            return false;
        }
        
        return true;
    }
 
    private void GrowIfNecessary()
    {
        if (this._count < this._buffer.Length) return;
 
        TValue[] newBuffer = new TValue[this._buffer.Length * 2];
        Array.Copy(this._buffer, newBuffer, this._buffer.Length);
        this._buffer = newBuffer;
    }
}