namespace DataStructuresAndAlgorithms;

public class ArrayQueue<T>
{   
    private readonly T[] _items;
    private int _start;
    private int _end;
    private int _count;

    public ArrayQueue(int size = 16)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(size, 1);
        _items = new T[size];

    }

    public void Enqueue(T item)
    {
        if (IsFull())
        {
            throw new InvalidOperationException("Queue is full.");
        }

        _items[_end] = item;
        _end = (_end + 1 ) % _items.Length;
        _count++;
    }

    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }
        
        var item = _items[_start];
        _start = (_start + 1) % _items.Length;
        _count--;

        return item;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        return _items[_start];
    }

    public bool IsEmpty() => _count == 0;

    public bool IsFull() => _count == _items.Length;
}