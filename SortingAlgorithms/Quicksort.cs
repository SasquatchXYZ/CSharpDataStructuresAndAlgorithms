namespace SortingAlgorithms;

public static class Quicksort
{
    public static void Sort(int[] array)
    {
        SortPart(array, 0, array.Length - 1);
    }

    public static void SortPart(int[] array, int lowerIndex, int upperIndex)
    {
        if (lowerIndex >= upperIndex) return;

        var pivot = array[upperIndex];
        var j = lowerIndex - 1;
        for (var i = lowerIndex; i < upperIndex; i++)
        {
            if (array[i] < pivot)
            {
                j++;
                (array[j], array[i]) = (array[i], array[j]);
            }
        }

        var p = j + 1;
        (array[p], array[upperIndex]) = (array[upperIndex], array[p]);

        SortPart(array, lowerIndex, p - 1);
        SortPart(array, p + 1, upperIndex);
    }
}
