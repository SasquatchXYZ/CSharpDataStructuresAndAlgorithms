using GraphDatastructures;

var graph = new Graph<string> { IsDirected = false, IsWeighted = false };

List<string> borders = [
    "PK:LU|SK|MA",
    "LU:PK|SK|MZ|PD",
    "SK:PK|MA|SL|LD|MZ|LU",
    "MA:PK|SK|SL",
    "SL:MA|SK|LD|OP",
    "LD:SL|SK|MZ|KP|WP|OP",
    "WP:LD|KP|PM|ZP|LB|DS|OP",
    "OP:SL|LD|WP|DS",
    "MZ:LU|SK|LD|KP|WM|PD",
    "PD:LU|MZ|WM",
    "WM:PD|MZ|KP|PM",
    "KP:MZ|LD|WP|PM|WM",
    "PM:WM|KP|WP|ZP",
    "ZP:PM|WP|LB",
    "LB:ZP|WP|DS",
    "DS:LB|WP|OP"
];

var nodes = new Dictionary<string, Node<string>>();
foreach (var border in borders)
{
    var parts = border.Split(":");
    var name = parts[0];
    nodes[name] = graph.AddNode(name);
}

foreach (var border in borders)
{
    var parts = border.Split(":");
    var name = parts[0];
    var vicinities = parts[1].Split("|");
    foreach (var vicinity in vicinities)
    {
        var from = nodes[name];
        var to = nodes[vicinity];
        if (!from.Neighbors.Contains(to))
        {
            graph.AddEdge(from, to);
        }
    }
}

var colors = graph.Color();
for (var i = 0; i < colors.Length; i++)
{
    Console.WriteLine($"{graph.Nodes[i].Data}: {colors[i]}");
}
