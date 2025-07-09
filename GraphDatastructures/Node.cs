namespace GraphDatastructures;

public class Node<T>
{
    public int Index { get; set; }
    public required T Data { get; set; }

    /// <summary>
    /// Contains references to the `Node` instances representing adjacent nodes
    /// </summary>
    public List<Node<T>> Neighbors { get; set; } = [];

    /// <summary>
    /// Stores the weights assigned to adjacent edges.
    /// In the case of a weighted graph, the number of elements in this list
    /// is the same as the number of neighbors.
    /// If the graph is unweighted, this list will be empty.
    /// </summary>
    public List<int> Weights { get; set; } = [];

    public override string ToString() =>
        $"Index: {Index}. Data: {Data}. Neighbors: {Neighbors.Count}.";
}
