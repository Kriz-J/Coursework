using System.Threading.Channels;

namespace DataStructuresAndAlgorithms;

public class Tree
{
    public class Node
    {
        public int Value { get; set; }
        public Node? LeftChild { get; set; }
        public Node? RightChild { get; set; }

        public Node(int value)
        {
            Value = value;
        }
    }

    public Node? Root { get; private set; }

    public void Insert(int value)
    {
        var node = new Node(value);

        if (Root is null)
        {
            Root = node;
            return;
        }

        var current = Root;

        while (true)
        {
            if (value >= current.Value)
            {
                if (current.RightChild is null)
                {
                    current.RightChild = node;
                    break;
                }
                current = current.RightChild;
            }
            else
            {
                if (current.LeftChild is null)
                {
                    current.LeftChild = node;
                    break;
                }

                current = current.LeftChild;
            }
        }
    }

    public bool Contains(int value)
    {
        var current = Root;

        while (current is not null)
        {
            if (current.Value == value)
            {
                return true;
            }

            current = (value > current.Value) ? current.RightChild : current.LeftChild;
        }

        return false;
    }

    public void TraversePreOrder()
    {
        TraversePreOrder(Root);
    }

    public void TraverseInOrderAsc()
    {
        TraverseInOrderAsc(Root);
    }

    public void TraverseInOrderDesc()
    {
        TraverseInOrderDesc(Root);
    }

    public void TraversePostOrder()
    {
        TraversePostOrder(Root);
    }

    private static void TraversePreOrder(Node? root)
    {
        if (root is null)
        {
            return;
        }

        Console.WriteLine(root.Value);
        TraversePreOrder(root.LeftChild);
        TraversePreOrder(root.RightChild);
    }
    
    private static void TraverseInOrderAsc(Node? root)
    {
        if (root is null)
        {
            return;
        }

        TraverseInOrderAsc(root.LeftChild);
        Console.WriteLine(root.Value);
        TraverseInOrderAsc(root.RightChild);
    }

    private static void TraverseInOrderDesc(Node? root)
    {
        if (root is null)
        {
            return;
        }

        TraverseInOrderDesc(root.RightChild);
        Console.WriteLine(root.Value);
        TraverseInOrderDesc(root.LeftChild);
    }

    private static void TraversePostOrder(Node? root)
    {
        if (root is null)
        {
            return;
        }

        TraversePostOrder(root.LeftChild);
        TraversePostOrder(root.RightChild);
        Console.WriteLine(root.Value);
    }
}