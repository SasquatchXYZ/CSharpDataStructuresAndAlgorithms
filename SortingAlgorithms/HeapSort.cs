namespace SortingAlgorithms;

public static class HeapSort
{
    public static void Sort(int[] array)
    {
        // Initial `Heapify` operation to prepare the max-heap
        // Operating in reverse order and on each node that is not a leaf
        for (var i = array.Length / 2 - 1; i >= 0; i--)
        {
            Heapify(array, array.Length, i);
        }

        for (var i = array.Length - 1; i > 0; i--)
        {
            // Swap the root element with the last element
            (array[0], array[i]) = (array[i], array[0]);
            // Re-heapify the array (restoring the max-heap property)
            Heapify(array, i, 0);
        }
    }

    /// <summary>
    /// Converts a subtree rooted at the given index into a max-heap, ensuring
    /// that the largest value among the root, left child, and right child
    /// is moved to the root. Recursively applies the heapify process to affected subtrees.
    /// </summary>
    /// <param name="array">The array representing the heap.</param>
    /// <param name="length">The number of elements currently in the heap.</param>
    /// <param name="index">The index of the root of the subtree to heapify.</param>
    private static void Heapify(int[] array, int length, int index)
    {
        var max = index; // The index of the largest value in the subtree - root
        var left = 2 * index + 1; // The left child index
        var right = 2 * index + 2; // The right child index

        // Check:
        //  1) whether the left child index is still within the heap
        //  2) whether the element with this index is greater than the current root value
        max = left < length && array[left] > array[max] ? left : max;
        // Same check for the right child index
        max = right < length && array[right] > array[max] ? right : max;

        // If the current root is not the largest value, swap it with the largest value
        // and heapify the affected subtree
        if (max != index)
        {
            (array[index], array[max]) = (array[max], array[index]);
            Heapify(array, length, max);
        }
    }
}
