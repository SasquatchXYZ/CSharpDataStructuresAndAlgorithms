namespace GraphDatastructures;

public class Subset<T>
{
    public required Node<T> Parent { get; set; }
    public int Rank { get; set; }

    public override string ToString() =>
        $"Rank: {Rank}. Parent: {Parent.Data}. Index: {Parent.Index}.";
}
