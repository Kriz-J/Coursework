namespace DataStructuresAndAlgorithms;

public class LinkedList<T>
{
    public class Node
    {
        public T Value { get; }
        public Node? Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }

    public int Size { get; set; }
    public Node? First { get; set; }
    public Node? Last { get; set; }

    public void AddLast(T value)
    {
        var node = new Node(value);

        if (IsEmpty())
        {
            First = node;
            Last = node;
        }
        else
        {
            Last!.Next = node;
            Last = node;
        }

        Size++;
    }

    public void AddFirst(T value)
    {
        var node = new Node(value);

        if (IsEmpty())
        {
            First = node;
            Last = node;
        }
        else
        {
            node.Next = First;
            First = node;
        }

        Size++;
    }

    public void RemoveLast()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The LinkedList is empty.");
        }

        if (IsSingleNode())
        {
            First = null;
            Last = null;
        }
        else
        {
            var current = First!;
            var newLast = current;
            
            while (current.Next is not null)
            {
                newLast = current;
                current = current.Next;
            }

            Last = newLast;
            newLast.Next = null;
        }

        Size--;
    }

    public void RemoveFirst()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The LinkedList is empty.");
        }

        if (IsSingleNode())
        {
            First = null;
            Last = null;
        }
        else
        {
            var newFirst = First!.Next;
            First.Next = null;
            First = newFirst;
        }

        Size--;
    }

    public int IndexOf(T value)
    {
        var index = 0;
        var current = First;

        while (current is not null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value))
            {
                return index;
            }

            current = current.Next;
            index++;
        }

        return -1;
    }

    public bool Contains(T value)
    {
        return IndexOf(value) != -1; //if value has an index it also exists
    }

    public T[] ToArray()
    {
        var array = new T[Size];

        var i = 0;
        var current = First;

        while (current is not null)
        {
            array[i++] = current.Value;
            current = current.Next;
        }

        return array;
    }

    public void Reverse()
    {
        var current = First;
        Node? previous = null;
        
        while (current is not null)
        {
            var next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }

        Last = First;
        First = previous;
    }

    public Node? GetKthFromTheEnd(int k)
    {
        if (k < 1 || IsEmpty())
        {
            throw new InvalidOperationException("List is empty or 'k' is negative.");
        }

        var current = First;
        var lag = First;

        while (current is not null)
        {
            current = current.Next;
            if (--k < 0)
            {
                lag = lag!.Next;
            }
        }

        if (k >= 0)
        {
            throw new InvalidOperationException("'k' exceeds the size of the list.");
        }

        return lag;
    }

    public LinkedList<T> GetMiddle()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Empty list has no middle.");
        }

        var current = First;
        var lag = First;

        while (current != Last && current!.Next != Last)
        {
            current = current.Next!.Next;
            lag = lag!.Next;
        }
        
        var middle = new LinkedList<T>();
        middle.AddFirst(lag!.Value);
        if (current != Last)
        {
            middle.AddLast(lag.Next!.Value);
        }
        
        return middle;
    }

    public bool HasLoop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("List is empty.");
        }

        var fast = First;
        var slow = First;

        while (fast?.Next != null)
        {
            fast = fast.Next.Next;
            slow = slow!.Next;

            if (fast == slow)
            {
                return true;
            }
        }
        
        return false;
    }

    private bool IsEmpty() => First is null || Last is null;
    
    private bool IsSingleNode() => First == Last;
}