namespace FibonacciSeries;

public class Fibonacci
{

    /// <summary>
    /// Simple recursive implementation
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static long SimpleRecursiveFibonacci(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        return SimpleRecursiveFibonacci(n - 1) + SimpleRecursiveFibonacci(n - 2);
    }


    private readonly Dictionary<int, long> _cache = [];

    /// <summary>
    /// Dynamic programming with a top-down approach
    /// using memoization to cache calculated results
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public long TopDownFibonacci(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        if (_cache.TryGetValue(n, out var fibonacci)) return fibonacci;
        var result = TopDownFibonacci(n - 1) + TopDownFibonacci(n - 2);
        _cache[n] = result;
        return result;
    }

    /// <summary>
    /// Calculates the Fibonacci number for a given position
    /// using an iterative bottom-up approach.
    /// </summary>
    /// <param name="n">The position in the Fibonacci sequence (zero-based index).</param>
    /// <returns>The Fibonacci number at the specified position.</returns>
    public static long BottomUpFibonacci(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;

        long a = 0;
        long b = 1;
        for (var i = 2; i <= n; i++)
        {
            var result = a + b;
            a = b;
            b = result;
        }

        return b;
    }
}
