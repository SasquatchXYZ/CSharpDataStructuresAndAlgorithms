namespace Chapter01;

public class StringShenanigans
{
    public static void PrintFormatedNamesAndTemps()
    {
        string[] names =
        [
            "Marcin", "Adam", "Martyna"
        ];

        DateTime[] dates =
        [
            new(1988, 11, 9), new(1995, 4, 25), new(2003, 7, 24)
        ];

        float[] temperatures =
        [
            36.6f, 39.1f, 35.9f
        ];

        Console.WriteLine($"{"Name",-8} {"Birth date",10} {"Temp. [C]",11} -> Result");
        for (var i = 0; i < names.Length; i++)
        {
            var line =
                $"{names[i],-8} {dates[i],10:dd.MM.yyyy} {temperatures[i],11:F1} -> {temperatures[i] switch {
                    > 40.0f => "Very high",
                    > 37.0f => "High",
                    > 36.0f => "Normal",
                    > 35.0f => "Low",
                    _ => "Very low" }}";

            Console.WriteLine(line);
        }
    }
}
