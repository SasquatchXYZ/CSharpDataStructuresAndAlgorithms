namespace SortingAlgorithms;

public class SelectionSort : AbstractSort
{
    public override void Sort(int[] array)
    {
        for (var i = 0; i < array.Length - 1; i++)
        {
            var minIndex = i;
            var minValue = array[i];
            for (var j = i + 1; j < array.Length; j++)
            {
                if (array[j] < minValue)
                {
                    minIndex = j;
                    minValue = array[j];
                }
            }

            (array[i], array[minIndex]) = (array[minIndex], array[i]);
        }
    }
}
