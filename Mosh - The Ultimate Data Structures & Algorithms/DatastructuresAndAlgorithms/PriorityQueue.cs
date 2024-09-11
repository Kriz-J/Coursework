namespace DataStructuresAndAlgorithms;

public class PriorityQueue
{
    private int[] _items;
    public int Count { get; private set; }

    public PriorityQueue(int capacity = 16)
    {
        if (capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be positive.");
        }

        _items = new int[capacity];
    }

    public void Enqueue(int item)
    {
        if (Count == _items.Length)
        {
            IncreaseQueueCapacity();
        }

        int i = Count;
        while (i > 0 && item > _items[i - 1])
        {
            _items[i] = _items[i - 1];
            i--;
        }

        _items[i] = item;
        Count++;
    }

    private void IncreaseQueueCapacity()
    {
        var newArray = new int[Count * 2];
        Array.Copy(_items, newArray, Count);
        _items = newArray;
    }

    public int Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        var highestPriorityItem = _items[--Count];
        _items[Count] = default;
        return highestPriorityItem;
    }

    public int Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        return _items[Count - 1];
    }
}