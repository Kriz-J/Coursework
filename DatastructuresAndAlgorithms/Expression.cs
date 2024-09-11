namespace DataStructuresAndAlgorithms;

public class Expression
{
    public static bool IsBalanced(string expression)
    {
        var stack = new Stack<char>();

        foreach (var c in expression)
        {
            switch (c)
            {
                case '(':
                    stack.Push(')');
                    break;
                case '[':
                    stack.Push(']');
                    break;
                case '{':
                    stack.Push('}');
                    break;
                case '<':
                    stack.Push('>');
                    break;
                case ')' or ']' or '}' or '>' when stack.Count == 0 || stack.Pop() != c:
                    return false;
            }
        }

        return stack.Count == 0;
    }
}