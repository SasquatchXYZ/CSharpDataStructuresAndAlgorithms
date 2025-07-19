using GraphDatastructures;

var graph = new Graph<int> { IsDirected = false, IsWeighted = true };

var n1 = graph.AddNode(1);
var n2 = graph.AddNode(2);
var n3 = graph.AddNode(3);
var n4 = graph.AddNode(4);
var n5 = graph.AddNode(5);
var n6 = graph.AddNode(6);
var n7 = graph.AddNode(7);
var n8 = graph.AddNode(8);

graph.AddEdge(n1, n2, 3);
graph.AddEdge(n1, n3, 5);
graph.AddEdge(n2, n4, 4);
graph.AddEdge(n3, n4, 12);
graph.AddEdge(n4, n5, 9);
graph.AddEdge(n4, n8, 8);
graph.AddEdge(n5, n6, 4);
graph.AddEdge(n5, n7, 5);
graph.AddEdge(n5, n8, 1);
graph.AddEdge(n6, n7, 6);
graph.AddEdge(n7, n8, 20);

Console.WriteLine("Minimum Spanning Tree - Kruskal:");
var kruskal = graph.MstKruskal();
kruskal.ForEach(Console.WriteLine);
Console.WriteLine($"Cost: {kruskal.Sum(edge => edge.Weight)}");

Console.WriteLine();

Console.WriteLine("Minimum Spanning Tree - Prim:");
var prim = graph.MstPrim();
prim.ForEach(Console.WriteLine);
Console.WriteLine($"Cost: {prim.Sum(edge => edge.Weight)}");
