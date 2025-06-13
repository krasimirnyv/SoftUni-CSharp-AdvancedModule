using System.Collections;

namespace Workshop.List;

public class MyList<TValue> : IEnumerable<TValue>
{
    private const int DefaultCapacity = 4;
 
    private TValue[] _buffer;
    private int _count;
    public int Count => this._count;

    public MyList() : this(DefaultCapacity)
    {
    }
 
    public MyList(int capacity)
    {
        this._buffer = new TValue[capacity];
        this._count = 0;
    }
    
    public TValue this[int index]
    {
        get
        {
            this.ValidateIndex(index);
            return this._buffer[index];
        }
        set
        {
            this.ValidateIndex(index);
            this._buffer[index] = value;
        }
    }
 
    public void Add(TValue value)
    {
        this.GrowIfNecessary();
 
        this._buffer[this.Count] = value;
        this._count++;
    }
 
    public void Insert(int index, TValue value)
    {
        if (index == this.Count) this.Add(value);
        else
        {
            this.ValidateIndex(index);
            this.GrowIfNecessary();
 
            for (int i = this.Count - 1; i >= index; i--)
                this._buffer[i + 1] = this._buffer[i];
 
            this._buffer[index] = value;
            this._count++;
        }
    }
 
    public void RemoveAt(int index)
    {
        this.ValidateIndex(index);
 
        for (int i = index; i < this.Count - 1; i++)
            this._buffer[i] = this._buffer[i + 1];
 
        this._buffer[this._count - 1] = default;
        this._count--;
    }
    
    public IEnumerator<TValue> GetEnumerator()
    {
        for (int i = 0; i < this._count; i++)
        {
            yield return this._buffer[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
 
    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= this.Count)
            throw new IndexOutOfRangeException($"Index must be in range [0, {this.Count})");
    }
 
    private void GrowIfNecessary()
    {
        if (this.Count != this._buffer.Length) return;
 
        TValue[] newBuffer = new TValue[this._buffer.Length * 2];
        Array.Copy(this._buffer, newBuffer, this._buffer.Length);
        this._buffer = newBuffer;
    }
}