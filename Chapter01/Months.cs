using System.Globalization;

namespace Chapter01;

public static class Months
{
    public static void PrintMonths()
    {
        var culture = new CultureInfo("en-US");
        var months = new string[12];
        for (var month = 1; month <= 12; month++)
        {
            var firstDay = new DateTime(DateTime.Now.Year, month, 1);
            var name = firstDay.ToString("MMMM", culture);
            months[month - 1] = name;
        }

        foreach (var month in months)
        {
            Console.WriteLine(month);
        }
    }
}
