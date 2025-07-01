namespace SpinTheWheel;

public static class CircularLinkedListExtensions
{
    public static LinkedListNode<T>? Next<T>(this LinkedListNode<T>? node)
    {
        return node?.List is not null
            ? node.Next ?? node.List.First
            : null;
    }
}
