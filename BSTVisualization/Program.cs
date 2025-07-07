using static BSTVisualization.Utilities;
using TreeDatastructures.Binary;
using TreeDatastructures.Binary.BinarySearch;

var tree = new BinarySearchTree<int>();
tree.Root = new BinaryTreeNode<int>{ Data = 100 };
tree.Root.Left = new BinaryTreeNode<int>{ Data = 50, Parent = tree.Root };
tree.Root.Right = new BinaryTreeNode<int>{ Data = 150, Parent = tree.Root };
tree.Count = 3;
Visualize(tree, "BST with 3 nodes (50, 100, 150):");

tree.Add(75);
tree.Add(125);
Visualize(tree, "BST after adding 2 nodes (75, 125):");

tree.Add(25);
tree.Add(175);
tree.Add(90);
tree.Add(110);
tree.Add(135);
Visualize(tree, "BST after adding 5 nodes (25, 175, 90, 110, 135):");

tree.Remove(25);
Visualize(tree, "BST after removing the node 25:");

tree.Remove(50);
Visualize(tree, "BST after removing the node 50:");

tree.Remove(100);
Visualize(tree, "BST after removing the node 100:");

foreach (var mode in Enum.GetValues<Traversal>())
{
    Console.Write($"\n{mode} traversal:\t");
    Console.Write(string.Join(", ",
        tree.Traverse(mode).Select(node => node.Data)));
}
