using static Chapter03Playground.Utilities;
using System.Diagnostics;
using SortingAlgorithms;

int[] testArray = [-11, 12, -42, 0, 1, 90, 68, 6, -9];

List<AbstractSort> algorithms = new()
{
    new SelectionSort(),
    new InsertionSort(),
    new BubbleSort(),
    new MergeSort(),
    new ShellSort(),
    new Quicksort(),
    new HeapSort(),
};

for (var n = 0; n <= 100_000; n += 10_000)
{
    Console.WriteLine($"\nRunning tests for n = {n}:");
    List<(Type Type, long Ms)> milliseconds = [];
    for (var i = 0; i < 5; i++)
    {
        var array = GetRandomArray(n);
        var input = new int[n];
        foreach (var algorithm in algorithms)
        {
            array.CopyTo(input, 0);

            var stopwatch = Stopwatch.StartNew();
            algorithm.Sort(input);
            stopwatch.Stop();

            milliseconds.Add((algorithm.GetType(), stopwatch.ElapsedMilliseconds));
        }
    }

    var results = milliseconds
        .GroupBy(pair => pair.Type)
        .Select(group =>
            (group.Key, group.Average(pair => pair.Ms))).ToList();

    foreach (var (type, avg) in results)
    {
        Console.WriteLine($"{type.Name}: {avg} ms");
    }
}
