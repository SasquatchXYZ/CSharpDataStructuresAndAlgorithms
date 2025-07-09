using GraphDatastructures;

var graph = new Graph<int> { IsDirected = false, IsWeighted = false };

var n1 = graph.AddNode(1);
var n2 = graph.AddNode(2);
var n3 = graph.AddNode(3);
var n4 = graph.AddNode(4);
var n5 = graph.AddNode(5);
var n6 = graph.AddNode(6);
var n7 = graph.AddNode(7);
var n8 = graph.AddNode(8);

graph.AddEdge(n1, n2);
graph.AddEdge(n1, n3);
graph.AddEdge(n2, n4);
graph.AddEdge(n3, n4);
graph.AddEdge(n4, n5);
graph.AddEdge(n5, n6);
graph.AddEdge(n5, n7);
graph.AddEdge(n5, n8);
graph.AddEdge(n6, n7);
graph.AddEdge(n7, n8);
