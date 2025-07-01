using System.Collections;

namespace SpinTheWheel;

public class CircularEnumerator<T>(LinkedList<T> list) : IEnumerator<T>
{
    private LinkedListNode<T>? _current;

    public T Current => _current is not null
        ? _current.Value
        : default!;

    object IEnumerator.Current => Current!;

    public bool MoveNext()
    {
        if (_current is null)
        {
            _current = list.First;
            return _current is not null;
        }

        _current = _current.Next ?? _current!.List?.First;
        return true;
    }

    public void Reset()
    {
        _current = null;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
