List<double> numbers = [];

do
{
    Console.Write("Enter the number: ");
    var numString = Console.ReadLine() ?? string.Empty;
    if (!double.TryParse(numString, out var num))
        break;

    numbers.Add(num);
    Console.WriteLine($"Average value: {numbers.Average()}");
} while (true);
