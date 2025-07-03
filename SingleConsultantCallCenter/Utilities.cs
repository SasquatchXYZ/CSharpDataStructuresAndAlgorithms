namespace SingleConsultantCallCenter;

public class Utilities
{
    public static void Log(string text) =>
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {text}");
}
