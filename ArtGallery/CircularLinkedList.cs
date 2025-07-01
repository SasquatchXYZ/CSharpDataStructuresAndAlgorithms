using System.Collections;

namespace ArtGallery;

public class CircularLinkedList<T> : LinkedList<T>
{
    public new IEnumerator GetEnumerator() => new CircularEnumerator<T>(this);
}
