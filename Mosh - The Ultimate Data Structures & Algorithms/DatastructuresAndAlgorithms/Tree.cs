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

    public List<int> GetNodesAtDistance(int distance)
    {
        if (Root is null)
        {
            throw new InvalidOperationException("Tree is empty.");
        }

        if (distance < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(distance), "Distance cannot be negative.");
        }

        var list = new List<int>();

        GetNodesAtDistance(Root, distance, list);
        
        return list;
    }

    public bool IsBinarySearchTree()
    {
        if (Root is null)
        {
            throw new InvalidOperationException("Tree is empty.");
        }

        return IsBinarySearchTree(Root, int.MinValue, int.MaxValue);
    }

    public bool Equal(Tree other)
    {
        if (Root is null)
        {
            throw new InvalidOperationException("Tree is empty.");
        }

        if (other.Root is null)
        {
            throw new InvalidOperationException("Comparing tree is empty.");
        }

        return Equals(Root, other.Root);
    }

    public int Min()
    {
        if (Root is null)
        {
            throw new InvalidOperationException("Tree is empty.");
        }

        return Min(Root);
    }

    public int Height()
    {
        if (Root is null)
        {
            throw new InvalidOperationException("Tree is empty.");
        }

        return Height(Root);
    }

    public void TraversePreOrder()
    {
        if (Root is null)
        {
            throw new InvalidOperationException("Tree is empty.");
        }

        TraversePreOrder(Root);
    }

    public void TraverseInOrderAsc()
    {
        if (Root is null)
        {
            throw new InvalidOperationException("Tree is empty.");
        }

        TraverseInOrderAsc(Root);
    }

    public void TraverseInOrderDesc()
    {
        if (Root is null)
        {
            throw new InvalidOperationException("Tree is empty.");
        }

        TraverseInOrderDesc(Root);
    }

    public void TraversePostOrder()
    {
        if (Root is null)
        {
            throw new InvalidOperationException("Tree is empty.");
        }

        TraversePostOrder(Root);
    }

    private static void GetNodesAtDistance(Node? node, int distance, ICollection<int> list)
    {
        if (node is null)
        {
            return;
        }

        if (distance == 0)
        {
            list.Add(node.Value);
            return;
        }

        GetNodesAtDistance(node.LeftChild, distance - 1, list);
        GetNodesAtDistance(node.RightChild, distance - 1, list);
    }

    private static bool IsBinarySearchTree(Node? node, int min, int max)
    {
        if (node is null)
        {
            return true;
        }

        if (node.Value <= min || node.Value >= max)
        {
            return false;
        }

        return IsBinarySearchTree(node.LeftChild, min, node.Value) && IsBinarySearchTree(node.RightChild, node.Value, max);
    }

    private static bool Equals(Node? node1, Node? node2)
    {
        if (node1 is null && node2 is null)
        {
            return true;
        }

        if (node1 is null || node2 is null)
        {
            return false;
        }

        if (node1.Value != node2.Value)
        {
            return false;
        }

        return Equals(node1.LeftChild, node2.LeftChild) && Equals(node1.RightChild, node2.RightChild);
    }

    private static int Min(Node? node)
    {
        var current = node;
        while (current!.LeftChild is not null)
        {
            current = current.LeftChild;
        }

        return current.Value;
    }

    private static int MinGeneric(Node? node)
    {
        var minValue = node!.Value;

        if (node.LeftChild is not null)
        {
            minValue = Math.Min(minValue, MinGeneric(node.LeftChild));
        }

        if (node.RightChild is not null)
        {
            minValue = Math.Min(minValue, MinGeneric(node.RightChild));
        }

        return minValue;
    }

    private static int Height(Node? node)
    {
        if (node is null)
        {
            return -1;
        }

        return 1 + Math.Max(Height(node.LeftChild), Height(node.RightChild));
    }

    private static void TraversePreOrder(Node? node)
    {
        if (node is null)
        {
            return;
        }

        Console.WriteLine(node.Value);
        TraversePreOrder(node.LeftChild);
        TraversePreOrder(node.RightChild);
    }

    private static void TraverseInOrderAsc(Node? node)
    {
        if (node is null)
        {
            return;
        }

        TraverseInOrderAsc(node.LeftChild);
        Console.WriteLine(node.Value);
        TraverseInOrderAsc(node.RightChild);
    }

    private static void TraverseInOrderDesc(Node? node)
    {
        if (node is null)
        {
            return;
        }

        TraverseInOrderDesc(node.RightChild);
        Console.WriteLine(node.Value);
        TraverseInOrderDesc(node.LeftChild);
    }

    private static void TraversePostOrder(Node? node)
    {
        if (node is null)
        {
            return;
        }

        TraversePostOrder(node.LeftChild);
        TraversePostOrder(node.RightChild);
        Console.WriteLine(node.Value);
    }
}