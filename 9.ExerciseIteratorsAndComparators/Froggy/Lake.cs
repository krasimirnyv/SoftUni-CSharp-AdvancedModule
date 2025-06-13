using System.Collections;

namespace Froggy;

public class Lake : IEnumerable<int>
{
    private readonly int[] _stones;

    public Lake(int[] stones)
    {
        _stones = stones ?? throw new ArgumentNullException(nameof(stones));
    }

    public IEnumerator<int> GetEnumerator()
        => new StonesIterator(stones: _stones);
    
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    private class StonesIterator : IEnumerator<int>
    {
        private readonly int[] _stones;
        private int _index;
        private bool _goingForward;
        public StonesIterator(int[] stones)
        {
            _stones = stones ?? throw new ArgumentNullException(nameof(stones));
            Reset();
        }
        
        public bool MoveNext()
        {
            if (EndIsReached()) return false;
            
            if (_goingForward)
            {
                _index += 2;
                if (_index >= _stones.Length)
                {
                    _index = _stones.Length - _stones.Length % 2 - 1;
                    _goingForward = false;
                }
            }
            else
            {
                _index -= 2;
            }

            return !EndIsReached();
        }

        public void Reset()
        {
            _index = -2;
            _goingForward = true;
        }

        public int Current => _stones[_index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        private bool EndIsReached() => _index == -1;
    }
}