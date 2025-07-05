var names = new List<string>
{
    "Marcin",
    "Mary",
    "James",
    "Albert",
    "Lily",
    "Emily",
    "marcin",
    "James",
    "Jane"
};

Console.WriteLine($"Original list: {names.Count}");

var sorted = new SortedSet<string>(names,
    Comparer<string>.Create((x, y) =>
        string.Compare(x, y, StringComparison.OrdinalIgnoreCase)));

Console.WriteLine($"Sorted set: {sorted.Count}");

foreach (var name in sorted)
{
    Console.WriteLine(name);
}
