namespace TreeDatastructures.Binary;

public class BinaryTree<T>
{
    public BinaryTreeNode<T>? Root { get; set; }
    public int Count { get; set; }

    public List<BinaryTreeNode<T>> Traverse(Traversal mode)
    {
        var nodes = new List<BinaryTreeNode<T>>();
        if (Root is null)
            return nodes;

        switch (mode)
        {
            case Traversal.PreOrder:
                TraversePreOrder(Root, nodes);
                break;
            case Traversal.InOrder:
                TraverseInOrder(Root, nodes);
                break;
            case Traversal.PostOrder:
                TraversePostOrder(Root, nodes);
                break;
        }

        return nodes;
    }

    public int GetHeight() => Root is not null
        ? Traverse(Traversal.PreOrder)
            .Max(n => n.GetHeight())
        : 0;

    /// <param name="node">The current node</param>
    /// <param name="result">The list of already visited nodes</param>
    private static void TraversePreOrder(
        BinaryTreeNode<T>? node,
        List<BinaryTreeNode<T>> result)
    {
        if (node is null)
            return;

        result.Add(node);
        TraversePreOrder(node.Left, result);
        TraversePreOrder(node.Right, result);
    }

    /// <param name="node">The current node</param>
    /// <param name="result">The list of already visited nodes</param>
    private static void TraverseInOrder(
        BinaryTreeNode<T>? node,
        List<BinaryTreeNode<T>> result)
    {
        if (node is null)
            return;

        TraverseInOrder(node.Left, result);
        result.Add(node);
        TraverseInOrder(node.Right, result);
    }

    /// <param name="node">The current node</param>
    /// <param name="result">The list of already visited nodes</param>
    private static void TraversePostOrder(
        BinaryTreeNode<T>? node,
        List<BinaryTreeNode<T>> result)
    {
        if (node is null)
            return;

        TraversePostOrder(node.Left, result);
        TraversePostOrder(node.Right, result);
        result.Add(node);
    }
}
