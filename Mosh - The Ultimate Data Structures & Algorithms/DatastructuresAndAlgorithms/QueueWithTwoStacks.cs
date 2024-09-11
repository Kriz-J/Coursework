namespace DataStructuresAndAlgorithms;

public class QueueWithTwoStacks<T>
{
    private readonly Stack<T> _stack;
    private readonly Stack<T> _reverseStack;
    private readonly int _capacity;

    public QueueWithTwoStacks(int capacity)
    {
        _stack = new Stack<T>(capacity);
        _reverseStack = new Stack<T>(capacity);
        _capacity = capacity;
    }

    public void Enqueue(T item)
    {
        if (_stack.Count == _capacity)
        {
            if (!_reverseStack.IsEmpty())
            {
                throw new InvalidOperationException("Queue is full.");
            }
        
            while (!_stack.IsEmpty())
            {
                _reverseStack.Push(_stack.Pop());
            }
        }

        _stack.Push(item);
    }

    public T Dequeue()
    {
        if (_stack.IsEmpty() && _reverseStack.IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        if (_reverseStack.IsEmpty())
        {
            TransferStackContents();
        }

        return _reverseStack.Pop();
    }

    public T Peek()
    {
        if (_stack.IsEmpty() && _reverseStack.IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        if (_reverseStack.IsEmpty())
        {
            TransferStackContents();
        }

        return _reverseStack.Peek();
    }
    private void TransferStackContents()
    {
        while (!_stack.IsEmpty())
        {
            _reverseStack.Push(_stack.Pop());
        }
    }
}