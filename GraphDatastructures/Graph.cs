namespace GraphDatastructures;

public class Graph<T>
{
    public required bool IsDirected { get; init; }
    public required bool IsWeighted { get; init; }
    public List<Node<T>> Nodes { get; set; } = [];

    /// <summary>
    /// Indexer
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns>An edge between the two provided Nodes</returns>
    public Edge<T>? this[int from, int to]
    {
        get
        {
            var nodeFrom = Nodes[from];
            var nodeTo = Nodes[to];
            var i = nodeFrom.Neighbors.IndexOf(nodeTo);
            if (i < 0)
                return null;

            var edge = new Edge<T> {
                From = nodeFrom,
                To = nodeTo,
                Weight = i < nodeFrom.Weights.Count
                    ? nodeFrom.Weights[i]
                    : 0,
            };

            return edge;
        }
    }

    public Node<T> AddNode(T value)
    {
        var node = new Node<T> { Data = value };
        Nodes.Add(node);
        UpdateIndices();
        return node;
    }

    public void RemoveNode(Node<T> node)
    {
        Nodes.Remove(node);
        UpdateIndices();
        Nodes.ForEach(n => RemoveEdge(n, node));
    }

    public void AddEdge(Node<T> from, Node<T> to, int weight = 0)
    {
        from.Neighbors.Add(to);
        if (IsWeighted)
            from.Weights.Add(weight);

        if (!IsDirected)
        {
            to.Neighbors.Add(from);
            if (IsWeighted)
                to.Weights.Add(weight);
        }
    }

    public void RemoveEdge(Node<T> from, Node<T> to)
    {
        var index = from.Neighbors.FindIndex(node => node == to);
        if (index < 0)
            return;

        from.Neighbors.RemoveAt(index);
        if (IsWeighted)
            from.Weights.RemoveAt(index);

        if (!IsDirected)
        {
            index = to.Neighbors.FindIndex(node => node == from);
            if (index < 0)
                return;

            to.Neighbors.RemoveAt(index);
            if (IsWeighted)
                to.Weights.RemoveAt(index);
        }
    }

    public List<Edge<T>> GetEdges()
    {
        var edges = new List<Edge<T>>();
        foreach (var from in Nodes)
        {
            for (var i = 0; i < from.Neighbors.Count; i++)
            {
                var weight = i < from.Weights.Count
                    ? from.Weights[i]
                    : 0;

                var edge = new Edge<T> { From = from, To = from.Neighbors[i], Weight = weight, };
                edges.Add(edge);
            }
        }

        return edges;
    }

    private void UpdateIndices()
    {
        var i = 0;
        Nodes.ForEach(n => n.Index = i++);
    }

    #region Depth-First Search

    public List<Node<T>> Dfs()
    {
        var isVisited = new bool[Nodes.Count];
        var result = new List<Node<T>>();
        Dfs(isVisited, Nodes[0], result);
        return result;
    }

    private static void Dfs(
        bool[] isVisited,
        Node<T> node,
        List<Node<T>> result)
    {
        result.Add(node);
        isVisited[node.Index] = true;
        foreach (var neighbor in node.Neighbors)
        {
            if (!isVisited[neighbor.Index])
            {
                Dfs(isVisited, neighbor, result);
            }
        }
    }

    #endregion

    #region Breadth-First Search

    public List<Node<T>> Bfs() => Bfs(Nodes[0]);

    private List<Node<T>> Bfs(Node<T> node)
    {
        var isVisited = new bool[Nodes.Count];
        isVisited[node.Index] = true;

        var result = new List<Node<T>>();
        var queue = new Queue<Node<T>>();
        queue.Enqueue(node);
        while (queue.Count > 0)
        {
            var next = queue.Dequeue();
            result.Add(next);

            foreach (var neighbor in next.Neighbors)
            {
                if (!isVisited[neighbor.Index])
                {
                    isVisited[neighbor.Index] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return result;
    }

    #endregion

}
