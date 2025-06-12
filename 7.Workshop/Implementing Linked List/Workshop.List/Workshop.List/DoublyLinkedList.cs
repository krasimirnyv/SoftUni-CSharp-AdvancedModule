namespace CustomDoublyLinkedList;

public class DoublyLinkedList<TValue>
{
    private DoublyLinkedListNode<TValue> _front, _back;
    private int _count;
    public int Count => this._count;
 
    public void AddFirst(TValue value)
    {
        DoublyLinkedListNode<TValue> newNode = new DoublyLinkedListNode<TValue> { Value = value, Next = this._front };
 
        if (this._count == 0) this._back = newNode;
        else this._front.Prev = newNode;
 
        this._front = newNode;
        this._count++;
    }
 
    public void AddLast(TValue value)
    {
        DoublyLinkedListNode<TValue> newNode = new DoublyLinkedListNode<TValue> { Value = value, Prev = this._back };
 
        if (this._count == 0) this._front = newNode;
        else this._back.Next = newNode;
 
        this._back = newNode;
        this._count++;
    }
 
    public TValue RemoveFirst()
    {
        this.ValidateNotEmpty();
 
        TValue removedValue = this._front.Value;
        this._front.Value = default;
 
        DoublyLinkedListNode<TValue> nextFront = this._front.Next;
        this._front.Next = null;
 
        if (this._count == 1) this._back = null;
        else nextFront.Prev = null;
 
        this._front = nextFront;
        this._count--;
 
        return removedValue;
    }
 
    public TValue RemoveLast()
    {
        this.ValidateNotEmpty();
 
        TValue removedValue = this._back.Value;
        this._back.Value = default;
 
        DoublyLinkedListNode<TValue> nextBack = this._back.Prev;
        this._back.Prev = null;
 
        if (this._count == 1) this._front = null;
        else nextBack.Next = null;
 
        this._back = nextBack;
        this._count--;
 
        return removedValue;
    }
 
    public TValue GetFirst()
    {
        this.ValidateNotEmpty();
        return this._front.Value;
    }
 
    public TValue GetLast()
    {
        this.ValidateNotEmpty();
        return this._back.Value;
    }
 
    public TValue Get(int index)
    {
        this.ValidateIndex(index);
        return Iterate(index).Value;
    }
    
    public TValue this[int index] => Get(index);

    public TValue[] ToArray()
    {
        TValue[] arr = new TValue[this._count];
        Iterate(this._count, (val, idx) => arr[idx] = val);
        return arr;
    }
    
    public void ForEach(Action<TValue> action)
        => this.Iterate(this._count, (val, _) => action(val));
    
    public DoublyLinkedListNode<TValue> Iterate(int ops, Action<TValue, int>? action = null)
    {
        DoublyLinkedListNode<TValue> iter = this._front;
        for (int i = 0; i < ops; i++)
        {
            action?.Invoke(iter.Value, i);
            iter = iter.Next;
        }
 
        return iter;
    }
 
    public void ValidateNotEmpty()
    {
        if (this._count == 0) throw new InvalidOperationException("Cannot execute the requested operation because the linked list is empty.");
    }
 
    public void ValidateIndex(int index)
    {
        if (index < 0 || index >= this._count)
            throw new IndexOutOfRangeException($"Index must be in range [0, {this._count})");
    }
}
 
public class DoublyLinkedListNode<TValue>
{
    public TValue Value { get; set; }
    public DoublyLinkedListNode<TValue> Prev { get; set; }
    public DoublyLinkedListNode<TValue> Next { get; set; }
}