using System.Globalization;

namespace Chapter01;

public enum MeanEnum
{
    Car,
    Bus,
    Subway,
    Bike,
    Walk,
}

public static class YearlyTransportPlan
{
    public static void PrintPlan()
    {
        var random = new Random();
        var meansCount = Enum.GetNames<MeanEnum>().Length;
        var year = DateTime.Now.Year;
        var means = new MeanEnum[12][];
        for (var m = 1; m <= 12; m++)
        {
            var daysCount = DateTime.DaysInMonth(year, m);
            means[m - 1] = new MeanEnum[daysCount];
            for (var d = 1; d <= daysCount; d++)
            {
                var mean = (MeanEnum) random.Next(meansCount);
                means[m - 1][d - 1] = mean;
            }
        }

        var months = GetMonthNames();
        var nameLength = months.Max(m => m.Length) + 2;
        for (var m = 1; m <= 12; m++)
        {
            var month = months[m - 1];
            Console.Write($"{month}:".PadRight(nameLength));
            for (var d = 1; d <= means[m - 1].Length; d++)
            {
                var mean = means[m - 1][d - 1];
                var (character, color) = Get(mean);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = color;
                Console.Write(character);
                Console.ResetColor();
                Console.Write(" ");
            }

            Console.WriteLine();
        }
    }

    private static string[] GetMonthNames()
    {
        var culture = new CultureInfo("en-US");
        var names = new string[12];
        foreach (var m in Enumerable.Range(1, 12))
        {
            var firstDay = new DateTime(DateTime.Now.Year, m, 1);
            var name = firstDay.ToString("MMMM", culture);
            names[m - 1] = name;
        }

        return names;
    }

    private static (char Char, ConsoleColor Color) Get(MeanEnum mean) =>
        mean switch
        {
            MeanEnum.Car => ('C', ConsoleColor.Red),
            MeanEnum.Bus => ('U', ConsoleColor.DarkGreen),
            MeanEnum.Subway => ('S', ConsoleColor.Magenta),
            MeanEnum.Bike => ('B', ConsoleColor.Blue),
            MeanEnum.Walk => ('W', ConsoleColor.DarkYellow),
            _ => throw new Exception("Unknown type")
        };
}
