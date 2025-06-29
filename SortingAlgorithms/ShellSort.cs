namespace SortingAlgorithms;

public class ShellSort : AbstractSort
{
    public override void Sort(int[] array)
    {
        for (var h = array.Length / 2; h > 0; h /= 2)
        {
            for (var i = h; i < array.Length; i++)
            {
                var j = i;
                var ai = array[i];
                while (j >= h && array[j - h] > ai)
                {
                    array[j] = array[j - h];
                    j -= h;
                }

                array[j] = ai;
            }
        }
    }
}
