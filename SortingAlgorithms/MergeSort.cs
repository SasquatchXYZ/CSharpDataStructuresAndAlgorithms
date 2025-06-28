namespace SortingAlgorithms;

public class MergeSort : AbstractSort
{
    public override void Sort(int[] array)
    {
        if (array.Length <= 1) return;

        var middle = array.Length / 2;
        var left = GetSubarray(array, 0, middle - 1);
        var right = GetSubarray(array, middle, array.Length - 1);

        Sort(left);
        Sort(right);

        int i = 0, j = 0, k = 0;
        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
            {
                array[k] = left[i++];
            }
            else
            {
                array[k] = right[j++];
            }

            k++;
        }

        while (i < left.Length)
        {
            array[k++] = left[i++];
        }

        while (j < right.Length)
        {
            array[k++] = right[j++];
        }
    }

    private static int[] GetSubarray(int[] array, int start, int end)
    {
        var result = new int[end - start + 1];
        Array.Copy(array, start, result, 0, end - start + 1);
        return result;
    }
}
