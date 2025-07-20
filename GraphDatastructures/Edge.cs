namespace GraphDatastructures;

public class Edge<T>
{
    public required Node<T> From { get; set; }
    public required Node<T> To { get; set; }
    public int Weight { get; set; }

    public override string ToString() =>
        $"{From.Data} -> {To.Data}. Weight: {Weight}.";
}
