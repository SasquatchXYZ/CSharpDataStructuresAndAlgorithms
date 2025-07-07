using TreeDatastructures;

var tree = new Tree<int>
{
    Root = new TreeNode<int>
    {
        Data = 100
    }
};

tree.Root.Children =
[
    new TreeNode<int>
    {
        Data = 50,
        Parent = tree.Root
    },
    new TreeNode<int>
    {
        Data = 1,
        Parent = tree.Root
    },
    new TreeNode<int>
    {
        Data = 150,
        Parent = tree.Root
    },
];

tree.Root.Children[2].Children =
[
    new TreeNode<int>
    {
        Data = 30,
        Parent = tree.Root.Children[2]
    }
];
