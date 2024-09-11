namespace DataStructuresAndAlgorithms;

public class LinkedListQueue<T>
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

    public Node? Head { get; private set; }
    public Node? Tail { get; private set; }
    public int Count { get; private set; }

    public void Enqueue(T item)
    {
        var node = new Node(item);

        if (Head is null)
        {
            Head = node;
            Tail = node;
        }
        else
        {
            Tail!.Next = node;
            Tail = node;
        }

        Count++;
    }

    public T Dequeue()
    {
        if (Head is null)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        var head = Head;

        if (Head.Next is null)
        {
            Head = null;
            Tail = null;
        }
        else
        {
            Head = Head.Next;
        }
        
        Count--;

        return head.Value;
    }

    public T Peek()
    {
        if (Head is null)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        return Head.Value;
    }

    public int Size => Count;

    public bool IsEmpty => Count == 0;
}