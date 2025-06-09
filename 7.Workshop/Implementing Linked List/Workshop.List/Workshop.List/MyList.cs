namespace Workshop.List;

public class MyList
{
    private const int DefaultCapacity = 4;
 
    private int[] _buffer;
    private int _count;
 
    public MyList() : this(DefaultCapacity)
    {
    }
 
    public MyList(int capacity)
    {
        this._buffer = new int[capacity];
        this._count = 0;
    }
 
    public int Count => this._count;
 
    public int this[int index]
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
 
    public void Add(int value)
    {
        this.GrowIfNecessary();
 
        this._buffer[this.Count] = value;
        this._count++;
    }
 
    public void Insert(int index, int value)
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
 
    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= this.Count)
            throw new IndexOutOfRangeException($"Index must be in range [0, {this.Count})");
    }
 
    private void GrowIfNecessary()
    {
        if (this.Count != this._buffer.Length) return;
 
        int[] newBuffer = new int[this._buffer.Length * 2];
        Array.Copy(this._buffer, newBuffer, this._buffer.Length);
        this._buffer = newBuffer;
    }
}