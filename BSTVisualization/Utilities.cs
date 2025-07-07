using TreeDatastructures.Binary;
using TreeDatastructures.Binary.BinarySearch;

namespace BSTVisualization;

public class Utilities
{
    private const int ColumnWidth = 5;

    public static void Visualize(BinarySearchTree<int> tree, string caption)
    {
        var console = Initialize(tree, out var width);
        VisualizeNode(
            node: tree.Root,
            row: 0,
            column: width / 2,
            console: console,
            width: width);

        Console.WriteLine(caption);
        Draw(console);
    }

    private static char[,] Initialize(BinarySearchTree<int> tree, out int width)
    {
        var height = tree.GetHeight();
        width = (int) Math.Pow(2, height) - 1;
        var console = new char[height * 2, ColumnWidth * width];

        for (var y = 0; y < console.GetLength(0); y++)
        {
            for (var x = 0; x < console.GetLength(1); x++)
            {
                console[y, x] = ' ';
            }
        }

        return console;
    }

    private static void VisualizeNode(
        BinaryTreeNode<int>? node,
        int row,
        int column,
        char[,] console,
        int width)
    {
        if (node is null) return;

        var chars = node.Data.ToString().ToCharArray();
        var margin = (ColumnWidth - chars.Length) / 2;
        for (var i = 0; i < chars.Length; i++)
        {
            var col = ColumnWidth * column + i + margin;
            console[row, col] = chars[i];
        }

        var columnDelta = (width + 1) /
                          (int) Math.Pow(2, node.GetHeight() + 1);

        VisualizeNode(
            node.Left,
            row: row + 2,
            column: column - columnDelta,
            console,
            width);

        VisualizeNode(
            node.Right,
            row: row + 2,
            column: column + columnDelta,
            console,
            width);

        DrawLineLeft(node, row, column, console, columnDelta);
        DrawLineRight(node, row, column, console, columnDelta);
    }

    private static void DrawLineLeft(
        BinaryTreeNode<int> node,
        int row,
        int column,
        char[,] console,
        int columnDelta)
    {
        if (node.Left is null) return;
        var sci = ColumnWidth * (column - columnDelta) + 2;
        var eci = ColumnWidth * column + 2;
        for (var x = sci + 1; x < eci; x++)
        {
            console[row + 1, x] = '-';
        }

        console[row + 1, sci] = '+';
        console[row + 1, eci] = '+';
    }

    private static void DrawLineRight(
        BinaryTreeNode<int> node,
        int row,
        int column,
        char[,] console,
        int columnDelta)
    {
        if (node.Right is null) return;
        var sci = ColumnWidth * column + 2;
        var eci = ColumnWidth * (column + columnDelta) + 2;
        for (var x = sci + 1; x < eci; x++)
        {
            console[row + 1, x] = '-';
        }

        console[row + 1, sci] = '+';
        console[row + 1, eci] = '+';
    }

    private static void Draw(char[,] console)
    {
        for (var y = 0; y < console.GetLength(0); y++)
        {
            for (var x = 0; x < console.GetLength(1); x++)
            {
                Console.Write(console[y, x]);
            }

            Console.WriteLine();
        }
    }
}
