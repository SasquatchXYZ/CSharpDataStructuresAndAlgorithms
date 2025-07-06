using static SimpleQuiz.Quiz;

var tree = GetTree();
var node = tree.Root;
while (node is not null)
{
    if (node.Left is not null && node.Right is not null)
    {
        Console.WriteLine(node.Data);
        node = Console.ReadKey(intercept: true).Key switch
        {
            ConsoleKey.Y => node.Left,
            ConsoleKey.N => node.Right,
            _ => node,
        };
    }
    else
    {
        Console.WriteLine(node.Data);
        node = null;
    }
}
