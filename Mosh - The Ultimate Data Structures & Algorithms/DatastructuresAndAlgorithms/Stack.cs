namespace DataStructuresAndAlgorithms;

public class Stack<T>
{
    private T[] _items;

    public Stack(int size = 16)
    {
        _items = new T[size];
    }

    public int Count { get; private set; }

    public void Push(T item)
    {
        if (Count == _items.Length)
        {
            var newArray = new T[Count * 2];
            
            for (int i = 0; i < Count; i++)
            {
                newArray[i] = _items[i];
            }

            _items = newArray;
        }

        _items[Count++] = item;
    }

    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        return _items[--Count];
    }
    
    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }


        return _items[Count - 1];
    }

    public bool IsEmpty() => Count == 0;
}