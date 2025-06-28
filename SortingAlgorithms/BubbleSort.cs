namespace SortingAlgorithms;

public static class BubbleSort
{
    public static void Sort(int[] array)
    {
        for (var i = 0; i < array.Length; i++)
        {
            for (var j = 0; j < array.Length - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
    }

    public static void ImprovedSort(int[] array)
    {
        for (var i = 0; i < array.Length; i++)
        {
            var isAnyChange = false;
            for (var j = 0; j < array.Length - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    isAnyChange = true;
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }

            if (!isAnyChange) break;
        }
    }
}
