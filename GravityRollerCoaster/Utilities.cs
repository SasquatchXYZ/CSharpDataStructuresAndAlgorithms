namespace GravityRollerCoaster;

public static class Utilities
{
    public static void Log(string text, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {text}");
        Console.ResetColor();
    }
}
