namespace TreeDatastructures.Binary;

public class BinaryTreeNode<T> : TreeNode<T>
{
    public new BinaryTreeNode<T>?[] Children { get; set; } = [null, null];

    public BinaryTreeNode<T>? Left
    {
        get => Children[0];
        set => Children[0] = value;
    }

    public BinaryTreeNode<T>? Right
    {
        get => Children[1];
        set => Children[1] = value;
    }
}
