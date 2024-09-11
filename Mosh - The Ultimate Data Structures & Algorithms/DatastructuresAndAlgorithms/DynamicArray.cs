namespace DataStructuresAndAlgorithms;

public class DynamicArray
{
    private int[] _array;

    private int AssignedElements { get; set; }

    public int this[int i] => _array[i];

    public DynamicArray(int size)
    {
        _array = new int[size];
    }

    public void Insert(int value)
    {
        if (AssignedElements == _array.Length)
        {
            ExtendArray();
        }

        _array[AssignedElements++] = value;
    }


    public void InsertAt(int index, int value)
    {
        if (index < 0 || index >= _array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index out of bounds.");
        }

        if (index > AssignedElements)
        {
            throw new InvalidOperationException("Not allowed to insert value beyond the end of array.");
        }

        if (AssignedElements == _array.Length)
        {
            ExtendArray();
        }
        
        for (int i = AssignedElements; i > index; i--)
        {
            _array[i] = _array[i - 1];
        }

        _array[index] = value;
        AssignedElements++;
    }

    private void ExtendArray()
    {
        var newArray = new int[AssignedElements * 2];

        for (int i = 0; i < AssignedElements; i++)
        {
            newArray[i] = _array[i];
        }

        _array = newArray;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= AssignedElements)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index out of bounds.");
        }

        AssignedElements--;

        for (int i = index; i < AssignedElements; i++)
        {
            _array[i] = _array[i + 1];
        }
    }

    public int IndexOf(int value)
    {
        for (int i = 0; i < AssignedElements; i++)
        {
            if (_array[i] == value)
            {
                return i;
            }
        }

        return -1;
    }

    public int Max()
    {
        if (AssignedElements == 0)
        {
            throw new InvalidOperationException("No elements in array.");
        }

        var max = _array[0];

        foreach (var element in _array)
        {
            max = (element > max) ? element : max;
        }

        return max;
    }

    public DynamicArray Intersect(DynamicArray array)
    {
        var intersectingElements = new DynamicArray(1);

        for (int i = 0; i < AssignedElements; i++)
        {
            for (int j = 0; j < array.AssignedElements; j++)
            {
                if (_array[i] == array[j])
                {
                    intersectingElements.Insert(_array[i]);
                }
            }
        }

        return intersectingElements;
    }

    public void Reverse()
    {
        var copy = new int[AssignedElements];
        for (int i = 0; i < AssignedElements; i++)
        {
            copy[i] = _array[i];
        }

        for (int i = 0; i < AssignedElements; i++)
        {
            _array[i] = copy[AssignedElements - 1 - i];
        }
    }

    public void Print()
    {
        Console.Write("[");

        for (int i = 0; i < AssignedElements; i++)
        {
            Console.Write((i != AssignedElements - 1) ? $"{_array[i]}, " : $"{_array[i]}");
        }

        Console.WriteLine("]");
    }
}