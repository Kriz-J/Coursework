using System.Text;

namespace DataStructuresAndAlgorithms;

public class StringReverser
{
    public static string Reverse(string input)
    {
        if (input is null)
        {
            throw new ArgumentNullException("input");
        }

        var stack = new Stack<char>();
        foreach (var c in input)
        {
            stack.Push(c);
        }

        var reverse = new StringBuilder();
        while (stack.Count > 0)
        {
            reverse.Append(stack.Pop());
        }

        return reverse.ToString();
    }
}