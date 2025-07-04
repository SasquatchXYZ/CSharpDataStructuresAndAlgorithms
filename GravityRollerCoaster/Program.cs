using static GravityRollerCoaster.Utilities;
using GravityRollerCoaster;
using QueueItem = (System.DateTime StartedAt, System.ConsoleColor Color);

const int rideSeconds = 10;
var random = new Random();
var queue = new CircularQueue<QueueItem>(12);
var color = ConsoleColor.Black;

while (true)
{
    while (queue.Peek() is not null)
    {
        var item = queue.Peek()!.Value;
        var elapsed = DateTime.Now - item.StartedAt;
        if (elapsed.TotalSeconds < rideSeconds)
            break;

        queue.Dequeue();
        Log($"> Exits\tTotal: {queue.Count}", item.Color);
    }

    var isNew = random.Next(3) == 1;
    if (isNew)
    {
        color = color == ConsoleColor.White
            ? ConsoleColor.DarkBlue
            : (ConsoleColor) ((int) color + 1);

        if (queue.Enqueue((DateTime.Now, color)))
        {
            Log($"< Enters\tTotal: {queue.Count}", color);
        }
        else
        {
            Log($"! Not allowed\tTotal: {queue.Count}", ConsoleColor.DarkGray);
        }
    }

    await Task.Delay(500);
}
