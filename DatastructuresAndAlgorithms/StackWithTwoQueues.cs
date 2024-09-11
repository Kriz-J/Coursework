namespace DataStructuresAndAlgorithms;

public class StackWithTwoQueues<T>
{
    private Queue<T> _queue1;
    private Queue<T> _queue2;

    public StackWithTwoQueues(int capacity = 16)
    { 
        ArgumentOutOfRangeException.ThrowIfNegative(capacity);

        _queue1 = new Queue<T>(capacity);
        _queue2 = new Queue<T>(capacity);
    }

    public void Push(T item)
    {
        _queue2.Enqueue(item);

        while (_queue1.Count > 0)
        {
            _queue2.Enqueue(_queue1.Dequeue());
        }

        (_queue1, _queue2) = (_queue2, _queue1);
    }

    public T Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        return _queue1.Dequeue();
    }

    public T Peek()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        return _queue1.Peek();
    }

    public int Size => _queue1.Count;

    public bool IsEmpty => Size == 0;
}