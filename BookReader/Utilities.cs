namespace BookReader;

public static class Utilities
{
    public static string GetSpaces(int count) =>
        string.Join(null, Enumerable.Range(0, count).Select(_ => " "));
}
