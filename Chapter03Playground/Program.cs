using static Chapter03Playground.Utilities;
using System.Diagnostics;
using SortingAlgorithms;

List<AbstractSort> algorithms =
[
    new SelectionSort(),
    new InsertionSort(),
    new BubbleSort(),
    new MergeSort(),
    new ShellSort(),
    new Quicksort(),
    new HeapSort()
];

const string path = "../../../SortingAlgorithmTesting.md";

var fs = new FileStream(path, FileMode.Create);
var sw = new StreamWriter(fs);

Console.WriteLine($"\nStarting Sorting Algorithms Testing at {DateTime.Now}");
sw.WriteLine($"\n# Sorting Algorithms Testing");
sw.WriteLine($"## {DateTime.Now:D}");

for (var n = 0; n <= 100_000; n += 10_000)
{
    Console.WriteLine($"\nCurrently Running tests for n = {n:N0}:");
    sw.WriteLine($"\n## Results for n = {n:N0}:");
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
        sw.WriteLine($"{type.Name}: {avg} ms");
    }
}

sw.Flush();
sw.Close();
fs.Close();

Console.WriteLine($"Sorting Algorithms Testing finished at {DateTime.Now}");
