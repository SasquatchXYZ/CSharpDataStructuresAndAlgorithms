using SpinTheWheel;

CircularLinkedList<string> categories = new();
categories.AddLast("Sport");
categories.AddLast("Culture");
categories.AddLast("History");
categories.AddLast("Geography");
categories.AddLast("People");
categories.AddLast("Technology");
categories.AddLast("Nature");
categories.AddLast("Science");

var isStopped = true;
var random = new Random();
var targetTime = DateTime.Now;
var ms = 0;

foreach (var category in categories)
{
    if (isStopped)
    {
        Console.WriteLine("Press [Enter] to start.");
        var key = Console.ReadKey().Key;
        if (key == ConsoleKey.Enter)
        {
            ms = random.Next(1000, 5000);
            targetTime = DateTime.Now.AddMilliseconds(ms);
            isStopped = false;
            Console.WriteLine(category);
        }
        else
        {
            return;
        }
    }
    else
    {
        var remaining = (int) (targetTime - DateTime.Now).TotalMilliseconds;
        var waiting = Math.Max(100, (ms - remaining) / 5);
        await Task.Delay(waiting);

        if (DateTime.Now >= targetTime)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            isStopped = true;
        }

        Console.WriteLine(category);
        Console.ResetColor();
    }
}
