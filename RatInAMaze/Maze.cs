namespace RatInAMaze;

public class Maze
{
    // The size of the maze
    private const int Size = 8;
    private const bool T = true;
    private const bool F = false;

    // The actual maze/map...
    // Available squares are filled with `true` values
    // Unavailable/blocked squares are marked with `false`
    private readonly bool[,] _maze = {
        { T, F, T, F, F, T, T, T }, { T, T, T, T, T, F, T, F }, { T, T, F, T, T, F, T, T }, { F, T, T, F, T, F, F, T },
        { F, T, T, T, T, T, T, T }, { T, F, T, F, T, F, F, T }, { T, T, T, T, T, T, T, T }, { F, T, F, F, F, T, F, T }
    };

    // Used for storing the data of the currently checked
    // pathway
    private readonly bool[,] _solution = new bool[Size, Size];

    public bool Go(int row, int col)
    {
        // Check if we have reached the exit
        // of the maze
        if (row == Size - 1 &&
            col == Size - 1 &&
            _maze[row, col])
        {
            _solution[row, col] = true;
            return true;
        }

        if (row >= 0 && row < Size &&
            col >= 0 && col < Size &&
            _maze[row, col])
        {
            if (_solution[row, col]) return false;

            _solution[row, col] = true;
            if (Go(row + 1, col)) return true;
            if (Go(row, col + 1)) return true;
            if (Go(row - 1, col)) return true;
            if (Go(row, col - 1)) return true;
            _solution[row, col] = false;
        }

        return false;
    }

    public void PrintSolution()
    {
        Console.WriteLine($" 0  {string.Join("  ", new List<int> {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8
        })} ");

        for (var row = 0; row < Size; row++)
        {
            Console.Write($" {row + 1} ");
            for (var col = 0; col < Size; col++)
            {
                Console.Write(_solution[row, col] ? " X " : " - ");
            }

            Console.WriteLine();
        }
    }
}
