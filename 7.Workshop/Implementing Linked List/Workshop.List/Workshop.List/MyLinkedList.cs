namespace Workshop.List;

public class MyLinkedList
{
    private MyLinkedListNode _front, _back;
    private int _count;
 
    public void AddFront(int value)
    {
        MyLinkedListNode newNode = new MyLinkedListNode { Value = value, Next = this._front };
 
        if (this._count == 0) this._back = newNode;
        else this._front.Prev = newNode;
 
        this._front = newNode;
        this._count++;
    }
 
    public void AddBack(int value)
    {
        MyLinkedListNode newNode = new MyLinkedListNode { Value = value, Prev = this._back };
 
        if (this._count == 0) this._front = newNode;
        else this._back.Next = newNode;
 
        this._back = newNode;
        this._count++;
    }
 
    public int RemoveFront()
    {
        this.ValidateNotEmpty();
 
        int removedValue = this._front.Value;
        this._front.Value = default;
 
        MyLinkedListNode nextFront = this._front.Next;
        this._front.Next = null;
 
        if (this._count == 1) this._back = null;
        else nextFront.Prev = null;
 
        this._front = nextFront;
        this._count--;
 
        return removedValue;
    }
 
    public int RemoveBack()
    {
        this.ValidateNotEmpty();
 
        int removedValue = this._back.Value;
        this._back.Value = default;
 
        MyLinkedListNode nextBack = this._back.Prev;
        this._back.Prev = null;
 
        if (this._count == 1) this._front = null;
        else nextBack.Next = null;
 
        this._back = nextBack;
        this._count--;
 
        return removedValue;
    }
 
    public int GetFront()
    {
        this.ValidateNotEmpty();
        return this._front.Value;
    }
 
    public int GetBack()
    {
        this.ValidateNotEmpty();
        return this._back.Value;
    }
 
    public int Get(int index)
    {
        this.ValidateIndex(index);
        return Iterate(index).Value;
    }
    
    public int this[int index] => Get(index);

    public int[] ToArray()
    {
        int[] arr = new int[this._count];
        Iterate(this._count, (val, idx) => arr[idx] = val);
        return arr;
    }
 
    public void ForEach(Action<int, int> action)
        => this.Iterate(this._count, action);
 
    private MyLinkedListNode Iterate(int ops, Action<int, int>? action = null)
    {
        MyLinkedListNode iter = this._front;
        for (int i = 0; i < ops; i++)
        {
            action?.Invoke(iter.Value, i);
            iter = iter.Next;
        }
 
        return iter;
    }
 
    private void ValidateNotEmpty()
    {
        if (this._count == 0) throw new InvalidOperationException("Cannot execute the requested operation because the linked list is empty.");
    }
 
    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= this._count)
            throw new IndexOutOfRangeException($"Index must be in range [0, {this._count})");
    }
}
 
public class MyLinkedListNode
{
    public int Value { get; set; }
    public MyLinkedListNode Prev { get; set; }
    public MyLinkedListNode Next { get; set; }
}