Console.WriteLine("Welcome to your encyclopedia");

var definitions = new SortedDictionary<string, string>();

do
{
    Console.WriteLine("\nChoose option ([A]dd, [L]ist): ");
    var keyInfo = Console.ReadKey(intercept: true);
    if (keyInfo.Key == ConsoleKey.A)
    {
        Console.Write("Enter the key: ");
        var key = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter the explanation: ");
        var explanation = Console.ReadLine() ?? string.Empty;
        definitions[key] = explanation;
    }
    else if (keyInfo.Key == ConsoleKey.L)
    {
        foreach (var (key, explanation) in definitions)
        {
            Console.WriteLine($"{key}: {explanation}");
        }
    }
    else
    {
        Console.WriteLine("Do you want to exit? Y or N.");
        if (Console.ReadKey().Key == ConsoleKey.Y)
        {
            break;
        }
    }
} while (true);
