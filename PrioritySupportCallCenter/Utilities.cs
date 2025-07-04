namespace PrioritySupportCallCenter;

public class Utilities
{
    public static void Log(string text, bool isPriority)
    {
        Console.ForegroundColor = isPriority ? ConsoleColor.Red : ConsoleColor.Gray;
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {text}");
        Console.ResetColor();
    }
}
