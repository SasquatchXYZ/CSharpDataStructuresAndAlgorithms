using System.Text;
using GraphDatastructures;

string[] lines = [
    "0011100000111110000011111",
    "0011100000111110000011111",
    "0011100000111110000011111",
    "0000000000011100000011111",
    "0000001110000000000011111",
    "0001001110011100000011111",
    "1111111111111110111111100",
    "1111111111111110111111101",
    "1111111111111110111111100",
    "0000000000000000111111110",
    "0000000000000000111111100",
    "0001111111001100000001101",
    "0001111111001100000001100",
    "0001100000000000111111110",
    "1111100000000000111111100",
    "1111100011001100100010001",
    "1111100011001100001000100"
];

var map = new bool[lines.Length][];

for (var i = 0; i < lines.Length; i++)
{
    map[i] = lines[i]
        .Select(c => int.Parse(c.ToString()) == 0)
        .ToArray();
}

var graph = new Graph<string> { IsDirected = false, IsWeighted = true };
for (var i = 0; i < map.Length; i++)
{
    for (var k = 0; k < map[i].Length; k++)
    {
        if (!map[i][k]) continue;

        var from = graph.AddNode($"{i}-{k}");

        if (i > 0 && map[i - 1][k])
        {
            var to = graph.Nodes
                .Find(node => node.Data == $"{i - 1}-{k}")!;

            graph.AddEdge(from, to, 1);
        }

        if (k > 0 && map[i][k - 1])
        {
            var to = graph.Nodes
                .Find(node => node.Data == $"{i}-{k - 1}")!;

            graph.AddEdge(from, to, 1);
        }
    }
}

var source = graph.Nodes.Find(node => node.Data == "0-0")!;
var target = graph.Nodes.Find(node => node.Data == "16-24")!;
var path = graph.GetShortestPath(source, target);

Console.OutputEncoding = Encoding.UTF8;
for (var r = 0; r < map.Length; r++)
{
    for (var c = 0; c < map[r].Length; c++)
    {
        var isPath = path
            .Any(edge => edge.From.Data == $"{r}-{c}" ||
                         edge.To.Data == $"{r}-{c}");

        Console.ForegroundColor = isPath
            ? ConsoleColor.White
            : map[r][c]
                ? ConsoleColor.Green
                : ConsoleColor.Red;

        Console.Write("\u25cf ");
    }

    Console.WriteLine();
}

Console.ResetColor();
