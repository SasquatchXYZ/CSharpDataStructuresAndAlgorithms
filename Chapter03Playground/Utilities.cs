namespace Chapter03Playground;

public static class Utilities
{
    public static int[] GetRandomArray(long length)
    {
        var array = new int[length];
        for (var i = 0; i < length; i++)
        {
            array[i] = Random.Shared.Next(-100_000, 100_000);
        }

        return array;
    }
}
