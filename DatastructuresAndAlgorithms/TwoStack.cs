namespace DataStructuresAndAlgorithms;

public class TwoStack<T>
{
    private T[] _items;
    private int _top1;
    private int _top2;

    public TwoStack(int size = 16)
    {
        if (size < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(size));
        }

        _items = new T[size];
        _top1 = -1;
        _top2 = size;
    }

    public int Count1 => _top1 + 1;
    public int Count2 => _items.Length - _top2;

    public void Push1(T item)
    {
        if (IsFull1())
        {
            Resize();
        }

        _items[++_top1] = item;
    }

    public void Push2(T item)
    {
        if (IsFull2())
        {
            Resize();
        }

        _items[--_top2] = item;
    }

    public T Pop1()
    {
        if (IsEmpty1())
        {
            throw new InvalidOperationException("Stack 1 is empty.");
        }

        return _items[_top1--];
    }
    
    public T Pop2()
    {
        if (IsEmpty2())
        {
            throw new InvalidOperationException("Stack 2 is empty.");
        }

        return _items[_top2++];
    }
    
    public T Peek1()
    {
        if (IsEmpty1())
        {
            throw new InvalidOperationException("Stack 1 is empty.");
        }


        return _items[_top1];
    }
    
    public T Peek2()
    {
        if (IsEmpty2())
        {
            throw new InvalidOperationException("Stack 2 is empty.");
        }


        return _items[_top2];
    }

    public bool IsEmpty1() => _top1 == -1;

    public bool IsEmpty2() => _top2 == _items.Length;

    public bool IsFull1() => _top1 + 1 == _top2;

    public bool IsFull2() => _top1 + 1 == _top2;

    private void Resize()
    {
        var newArray = new T[_items.Length * 2];

        Array.Copy(_items, 0 , newArray, 0, _top1 + 1);
        Array.Copy(_items, _top2, newArray, newArray.Length - (_items.Length - _top2), _items.Length - _top2);

        _top2 = newArray.Length - (_items.Length - _top2);

        _items = newArray;
    }
}