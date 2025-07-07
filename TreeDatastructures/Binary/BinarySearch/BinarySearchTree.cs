namespace TreeDatastructures.Binary.BinarySearch;

public class BinarySearchTree<T> : BinaryTree<T>
    where T : IComparable<T>
{
    public bool Contains(T data)
    {
        var node = Root;
        while (node is not null)
        {
            var result = data.CompareTo(node.Data);
            switch (result)
            {
                case 0:
                    return true;
                case < 0:
                    node = node.Left;
                    break;
                default:
                    node = node.Right;
                    break;
            }
        }

        return false;
    }

    public void Add(T data)
    {
        var parent = GetParentForNewNode(data);
        var node = new BinaryTreeNode<T>
        {
            Data = data,
            Parent = parent
        };

        if (parent is null)
        {
            Root = node;
        }
        else if (data.CompareTo(parent.Data) < 0)
        {
            parent.Left = node;
        }
        else
        {
            parent.Right = node;
        }

        Count++;
    }

    public void Remove(T data) => Remove(Root, data);

    private BinaryTreeNode<T>? GetParentForNewNode(T data)
    {
        var current = Root;
        BinaryTreeNode<T>? parent = null;
        while (current is not null)
        {
            parent = current;
            var result = data.CompareTo(current.Data);
            current = result switch
            {
                // We are not allowing duplicates in this variant of the BST
                0 => throw new ArgumentException($"The node {data} already exists."),
                < 0 => current.Left,
                _ => current.Right
            };
        }

        return parent;
    }

    private void Remove(BinaryTreeNode<T>? node, T data)
    {
        if (node is null)
            return;
        else if (data.CompareTo(node.Data) < 0)
            Remove(node.Left, data);
        else if (data.CompareTo(node.Data) > 0)
            Remove(node.Right, data);
        else
        {
            // Removal of a leaf node, or a node with just a left/right child
            if (node.Left is null || node.Right is null)
            {
                var newNode = node.Left is null && node.Right is null
                    ? null
                    : node.Left ?? node.Right;

                ReplaceInParent(node, newNode);
                Count--;
            }
            else
            {
                // Removal of a node with both child nodes
                var successor = FindMinimumInSubtree(node.Right);
                node.Data = successor.Data;
                Remove(successor, successor.Data!);
            }
        }
    }

    /// <summary>
    /// Removing a leaf node or a node with only a left or right child
    /// </summary>
    /// <param name="node"></param>
    /// <param name="newNode"></param>
    private void ReplaceInParent(
        BinaryTreeNode<T> node,
        BinaryTreeNode<T>? newNode)
    {
        if (node.Parent is not null)
        {
            var parent = (BinaryTreeNode<T>) node.Parent;
            if (parent.Left == node)
            {
                parent.Left = newNode;
            }
            else
            {
                parent.Right = newNode;
            }
        }
        else
        {
            Root = newNode;
        }

        if (newNode is not null)
        {
            newNode.Parent = node.Parent;
        }
    }

    private static BinaryTreeNode<T> FindMinimumInSubtree(BinaryTreeNode<T> node)
    {
        while (node.Left is not null)
            node = node.Left;

        return node;
    }
}
