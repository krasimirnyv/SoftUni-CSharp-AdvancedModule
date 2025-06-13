using System.Collections;

namespace Workshop.List;

public class DoublyLinkedList<TValue> : IEnumerable<TValue>
{
    private MyLinkedListNode<TValue> _front, _back;
    private int _count;
    public int Count => this._count;
 
    public void AddFirst(TValue value)
    {
        MyLinkedListNode<TValue> newNode = new MyLinkedListNode<TValue> { Value = value, Next = this._front };
 
        if (this._count == 0) this._back = newNode;
        else this._front.Prev = newNode;
 
        this._front = newNode;
        this._count++;
    }
 
    public void AddLast(TValue value)
    {
        MyLinkedListNode<TValue> newNode = new MyLinkedListNode<TValue> { Value = value, Prev = this._back };
 
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
 
        MyLinkedListNode<TValue> nextFront = this._front.Next;
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
 
        MyLinkedListNode<TValue> nextBack = this._back.Prev;
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
        return this.Skip(index).First();
    }
    
    public TValue this[int index] => Get(index);
    
    public IEnumerator<TValue> GetEnumerator()
    {
        MyLinkedListNode<TValue> iterator = this._front;
        for (int i = 0; i < this._count; i++)
        {
            yield return iterator.Value;
            iterator = iterator.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
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
 
public class MyLinkedListNode<TValue>
{
    public TValue Value { get; set; }
    public MyLinkedListNode<TValue> Prev { get; set; }
    public MyLinkedListNode<TValue> Next { get; set; }
}