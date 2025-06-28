namespace SortingAlgorithms;

public static class InsertionSort
{
    public static void Sort(int[] array)
    {
        // The initial value is set to 1 instead of 0 because the unsorted
        // portion of the array contains one element at the start.
        for (var i = 1; i < array.Length; i++)
        {
            var j = i;
            // Moves the first element from the unsorted portion of
            // the array (with index equal to `i`) to the correct location
            // within the sorted part by swapping
            while (j > 0 && array[j] < array[j - 1])
            {
                (array[j], array[j - 1]) = (array[j - 1], array[j]);
                j--;
            }
        }
    }
}
