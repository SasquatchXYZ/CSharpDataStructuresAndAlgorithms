using Priority_Queue;

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

    #region Minimum Spanning Tree - Kruskal's Algorithm

    public List<Edge<T>> MstKruskal()
    {
        var edges = GetEdges();
        edges.Sort((x, y) => x.Weight.CompareTo(y.Weight));
        var queue = new Queue<Edge<T>>(edges);

        var subsets = new Subset<T>[Nodes.Count];
        for (var i = 0; i < Nodes.Count; i++)
        {
            subsets[i] = new Subset<T> { Parent = Nodes[i] };
        }

        var result = new List<Edge<T>>();
        while (result.Count < Nodes.Count - 1)
        {
            var edge = queue.Dequeue();
            var from = GetRoot(subsets, edge.From);
            var to = GetRoot(subsets, edge.To);
            if (from == to)
                continue;

            result.Add(edge);
            Union(subsets, from, to);
        }

        return result;
    }

    /// <summary>
    /// Update parents for subsets and returns the root node of the subset
    /// </summary>
    private static Node<T> GetRoot(Subset<T>[] subsets, Node<T> node)
    {
        var index = node.Index;
        subsets[index].Parent = subsets[index].Parent != node
            ? GetRoot(subsets, subsets[index].Parent)
            : subsets[index].Parent;

        return subsets[index].Parent;
    }

    /// <summary>
    /// Union by Rank of two sets, the two Nodes represent the root
    /// nodes for subsets on which the union operation should be
    /// performed
    /// </summary>
    /// <param name="subsets">Array of Subset instances</param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    private static void Union(Subset<T>[] subsets, Node<T> a, Node<T> b)
    {
        subsets[b.Index].Parent = subsets[a.Index].Rank >= subsets[b.Index].Rank
            ? a
            : subsets[b.Index].Parent;

        subsets[a.Index].Parent = subsets[a.Index].Rank < subsets[b.Index].Rank
            ? b
            : subsets[a.Index].Parent;

        if (subsets[a.Index].Rank == subsets[b.Index].Rank)
        {
            subsets[a.Index].Rank++;
        }
    }

    #endregion

    #region Minimum Spanning Tree - Prim's Algorithm

    public List<Edge<T>> MstPrim()
    {
        // Stores indices of the previous node,
        // from which the given node can be reached
        var previous = new int[Nodes.Count];
        previous[0] = -1;

        // Stores the minimum weight of the edge
        // for accessing the given node
        var minWeight = new int[Nodes.Count];
        Array.Fill(minWeight, int.MaxValue);
        minWeight[0] = 0;

        // Indicates whether the given node is already in
        // the MST
        var isInMst = new bool[Nodes.Count];
        Array.Fill(isInMst, false);

        for (var i = 0; i < Nodes.Count - 1; i++)
        {
            var mwi = GetMinWeightIndex(minWeight, isInMst);
            isInMst[mwi] = true;

            for (var j = 0; j < Nodes.Count; j++)
            {
                var edge = this[mwi, j];
                var weight = edge is not null
                    ? edge.Weight
                    : -1;

                if (edge is not null &&
                    !isInMst[j] &&
                    weight < minWeight[j])
                {
                    previous[j] = mwi;
                    minWeight[j] = weight;
                }
            }
        }

        var result = new List<Edge<T>>();
        for (var i = 1; i < Nodes.Count; i++)
        {
            result.Add(this[previous[i], i]!);
        }

        return result;
    }

    /// <summary>
    /// Finds an index of the node, which is not located in the MST
    /// and can be reached with the minimum cost
    /// </summary>
    /// <param name="weights"></param>
    /// <param name="isInMst"></param>
    /// <returns></returns>
    private int GetMinWeightIndex(int[] weights, bool[] isInMst)
    {
        var minValue = int.MaxValue;
        var minIndex = 0;

        for (var i = 0; i < Nodes.Count; i++)
        {
            if (!isInMst[i] && weights[i] < minValue)
            {
                minValue = weights[i];
                minIndex = i;
            }
        }

        return minIndex;
    }

    #endregion

    #region Coloring

    public int[] Color()
    {
        // Stores the indices of colors chosen for particular nodes
        var colors = new int[Nodes.Count];
        Array.Fill(colors, -1);
        colors[0] = 0;

        // Stores information about the availability of colors
        var available = new bool[Nodes.Count];
        for (var i = 1; i < Nodes.Count; i++)
        {
            Array.Fill(available, true);

            foreach (var neighbor in Nodes[i].Neighbors)
            {
                var ci = colors[neighbor.Index];
                if (ci >= 0)
                {
                    available[ci] = false;
                }
            }

            colors[i] = Array.IndexOf(available, true);
        }

        return colors;
    }

    #endregion

    #region Shortest path

    public List<Edge<T>> GetShortestPath(Node<T> source, Node<T> target)
    {
        // Stores the indices of previous nodes, from which the given node
        // can be reached with the smallest overall cost
        var previous = new int[Nodes.Count];
        Array.Fill(previous, -1);

        // Stores the current minimum distances to the given node
        var distances = new int[Nodes.Count];
        Array.Fill(distances, int.MaxValue);
        distances[source.Index] = 0;

        var nodes = new SimplePriorityQueue<Node<T>>();
        for (var i = 0; i < Nodes.Count; i++)
        {
            // The priority of each element is equal to the current
            // distance to the node.
            nodes.Enqueue(Nodes[i], distances[i]);
        }

        while (nodes.Count != 0)
        {
            var node = nodes.Dequeue();
            for (var i = 0; i < node.Neighbors.Count; i++)
            {
                var neighbor = node.Neighbors[i];
                var weight = i < node.Weights.Count
                    ? node.Weights[i]
                    : 0;

                var wTotal = distances[node.Index] + weight;

                if (distances[neighbor.Index] > wTotal)
                {
                    distances[neighbor.Index] = wTotal;
                    previous[neighbor.Index] = node.Index;
                    nodes.UpdatePriority(
                        neighbor,
                        distances[neighbor.Index]);
                }
            }
        }

        var indices = new List<int>();
        var index = target.Index;
        while (index >= 0)
        {
            indices.Add(index);
            index = previous[index];
        }

        indices.Reverse();
        var result = new List<Edge<T>>();
        for (var i = 0; i < indices.Count - 1; i++)
        {
            var edge = this[indices[i], indices[i + 1]]!;
            result.Add(edge);
        }

        return result;
    }

    #endregion

}
