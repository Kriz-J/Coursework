namespace DataStructuresAndAlgorithms;

public class QueueReverser<T>
{
    public static void ReverseKFirstElements(Queue<T> queue, int k)
    {
        if (k < 0 || k > queue.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(k));
        }

        var stack = new Stack<T>();

        for (int i = 0; i < k; i++)
        {
            stack.Push(queue.Dequeue());
        }

        while (stack.Count > 0)
        {
            queue.Enqueue(stack.Pop());
        }

        for (int i = k; i < queue.Count; i++)
        {
            queue.Enqueue(queue.Dequeue());
        }
    }
}