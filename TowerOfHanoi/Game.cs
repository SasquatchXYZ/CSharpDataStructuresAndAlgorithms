namespace TowerOfHanoi;

public class Game
{
    public Game(int discsCount)
    {
        DiscsCount = discsCount;
        From = new Stack<int>();
        To = new Stack<int>();
        Auxiliary = new Stack<int>();

        for (var i = 0; i < discsCount; i++)
        {
            var size = discsCount - i;
            From.Push(size);
        }
    }

    public Stack<int> From { get; private set; }
    public Stack<int> To { get; private set; }
    public Stack<int> Auxiliary { get; private set; }
    public int DiscsCount { get; private set; }
    public int MovesCount { get; private set; }
    public event EventHandler<EventArgs>? MoveCompleted;

    public async Task MoveAsync(int discs, Stack<int> from, Stack<int> to, Stack<int> auxiliary)
    {
        if (discs == 0) return; // Exit condition

        await MoveAsync(
            discs: discs - 1,
            from: from,
            to: auxiliary,
            auxiliary: to);

        to.Push(from.Pop());
        MovesCount++;
        MoveCompleted?.Invoke(this, EventArgs.Empty); // Responsible for refreshing the UI
        await Task.Delay(250);

        await MoveAsync(
            discs: discs - 1,
            from: auxiliary,
            to: to,
            auxiliary: from);
    }
}
