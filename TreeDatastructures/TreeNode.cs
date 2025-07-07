namespace TreeDatastructures;

public class TreeNode<T>
{
    public T? Data { get; set; }
    public TreeNode<T>? Parent { get; set; }
    public List<TreeNode<T>> Children { get; set; } = [];

    public int GetHeight()
    {
        var height = 1;
        var current = this;
        while (current.Parent is not null)
        {
            height++;
            current = current.Parent;
        }

        return height;
    }
}
