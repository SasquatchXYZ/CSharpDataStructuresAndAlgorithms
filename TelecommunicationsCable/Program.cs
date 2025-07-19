using GraphDatastructures;

var graph = new Graph<string> { IsDirected = false, IsWeighted = true };
var nodeB1 = graph.AddNode("B1");
var nodeB2 = graph.AddNode("B2");
var nodeB3 = graph.AddNode("B3");
var nodeB4 = graph.AddNode("B4");
var nodeB5 = graph.AddNode("B5");
var nodeB6 = graph.AddNode("B6");
var nodeR1 = graph.AddNode("R1");
var nodeR2 = graph.AddNode("R2");
var nodeR3 = graph.AddNode("R3");
var nodeR4 = graph.AddNode("R4");
var nodeR5 = graph.AddNode("R5");
var nodeR6 = graph.AddNode("R6");

graph.AddEdge(nodeB1, nodeB2, 2);
graph.AddEdge(nodeB1, nodeB3, 20);
graph.AddEdge(nodeB1, nodeB4, 30);
graph.AddEdge(nodeB2, nodeB3, 30);
graph.AddEdge(nodeB2, nodeB4, 20);
graph.AddEdge(nodeB2, nodeR2, 25);
graph.AddEdge(nodeB3, nodeB4, 2);
graph.AddEdge(nodeB4, nodeR4, 25);
graph.AddEdge(nodeR1, nodeR2, 1);
graph.AddEdge(nodeR2, nodeR3, 1);
graph.AddEdge(nodeR3, nodeR4, 1);
graph.AddEdge(nodeR1, nodeR5, 75);
graph.AddEdge(nodeR3, nodeR6, 100);
graph.AddEdge(nodeR5, nodeR6, 3);
graph.AddEdge(nodeR6, nodeB5, 3);
graph.AddEdge(nodeR6, nodeB6, 10);
graph.AddEdge(nodeB5, nodeB6, 6);

Console.WriteLine("Minimum Spanning Tree - Kruskal:");
var kruskal = graph.MstKruskal();
kruskal.ForEach(Console.WriteLine);
Console.WriteLine($"Cost: {kruskal.Sum(edge => edge.Weight)}");

Console.WriteLine();

Console.WriteLine("Minimum Spanning Tree - Prim:");
var prim = graph.MstPrim();
prim.ForEach(Console.WriteLine);
Console.WriteLine($"Cost: {prim.Sum(edge => edge.Weight)}");
