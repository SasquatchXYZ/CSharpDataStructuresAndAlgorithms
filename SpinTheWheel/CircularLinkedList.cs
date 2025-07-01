using System.Collections;

namespace SpinTheWheel;

public class CircularLinkedList<T> : LinkedList<T>
{
    public new IEnumerator GetEnumerator() => new CircularEnumerator<T>(this);
}
