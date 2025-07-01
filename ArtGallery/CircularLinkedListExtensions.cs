namespace ArtGallery;

public static class CircularLinkedListExtensions
{
    public static LinkedListNode<T>? Next<T>(this LinkedListNode<T>? node)
    {
        return node?.List is not null
            ? node.Next ?? node.List.First
            : null;
    }

    public static LinkedListNode<T>? Previous<T>(this LinkedListNode<T>? node)
    {
        return node?.List is not null
            ? node.Previous ?? node.List.Last
            : null;
    }
}
