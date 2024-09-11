namespace DataStructuresAndAlgorithms;

public class MinStack
{
    private readonly Stack<int> _stack = new();
    private readonly Stack<int> _minStack = new();

    public int Min => _minStack.Peek();

    public void Push(int item)
    {
        if (_minStack.IsEmpty() || item <= _minStack.Peek())
        {
            _minStack.Push(item);
        }

        _stack.Push(item);
    }

    public int Pop()
    {
        if (_stack.IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        var top = _stack.Pop();

        if (top == _minStack.Peek())
        {
            _minStack.Pop();
        }

        return top;
    }
}