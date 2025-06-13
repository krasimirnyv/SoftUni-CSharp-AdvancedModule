using System.Collections;

namespace ListyIterator;

public class ListyIterator<TValue> : IEnumerable<TValue>
{
    private readonly List<TValue> _list;
    private int _index;

    public ListyIterator(List<TValue> list)
    {
        _list = list ?? throw new ArgumentNullException(nameof(list));
    }

    public bool MoveNext()
    {
        bool hasNext = HasNext();
        if (hasNext)
            _index++;
        
        return hasNext;
    }

    public bool HasNext()
    {
        return IndexIsValid(_index + 1);
    }

    public TValue GetValue()
    {
        if(!IndexIsValid(_index))
            throw new InvalidOperationException("Invalid Operation!");
        
        return _list[_index];
    }
    private bool IndexIsValid(int index)
        => index < _list.Count;

    public IEnumerator<TValue> GetEnumerator()
    {
        for (int i = 0; i < _list.Count; i++)
        {
            yield return _list[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}