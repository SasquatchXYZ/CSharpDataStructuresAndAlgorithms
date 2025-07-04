namespace GravityRollerCoaster;

public class CircularQueue<T>(int size) where T : struct
{
    private readonly T[] _items = new T[size];
    private int _front = -1;
    private int _rear = -1;
    private int _count;

    public int Count
    {
        get => _count;
    }

    public bool Enqueue(T item)
    {
        // Make sure that we have space in the queue
        if (_count == _items.Length)
            return false;

        if (_front < 0) // Check if the queue is empty...
        {
            // If so, set front and rear to 0 signifying
            // there is one element in the queue...
            _front = _rear = 0;
        }
        else
        {
            // Otherwise, increment the rear index
            // if it is equal to the number of elements in the array,
            // it gets assigned `0`
            _rear = ++_rear % _items.Length;
        }

        _items[_rear] = item;
        _count++;
        return true;
    }

    public T? Dequeue()
    {
        if (_count == 0)
            return null;

        T result = _items[_front];
        if (_front == _rear) // Only one element in the queue
        {
            _front = _rear = -1; // Queue is now empty
        }
        else
        {
            _front = ++_front % _items.Length;
        }

        _count--;
        return result;
    }

    public T? Peek()
    {
        if (_count == 0)
            return null;

        return _items[_front];
    }
}
