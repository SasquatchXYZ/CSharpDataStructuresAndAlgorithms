namespace SudokuPuzzle;

public class Solver
{
    private readonly int[,] _board;

    public Solver(int[,] board)
    {
        _board = board;
    }

    /// <summary>
    /// Attempts to solve the Sudoku puzzle using a backtracking
    /// algorithm, filling in empty cells to complete the board.
    /// </summary>
    /// <returns>
    /// True if the Sudoku puzzle is successfully solved;
    /// otherwise, false if no solution can be found.
    /// </returns>
    public bool Solve()
    {
        var (row, col) = GetEmpty();
        if (row < 0 && col < 0) return true;

        for (var i = 1; i <= 9; i++)
        {
            if (IsCorrect(row, col, i))
            {
                _board[row, col] = i;

                if (Solve())
                    return true;

                _board[row, col] = 0;
            }
        }

        return false;
    }

    /// <summary>
    /// Finds the next empty cell in the Sudoku board by scanning
    /// row by row and column by column.
    /// </summary>
    /// <returns>
    /// A tuple containing the row and column indices of the next empty cell,
    /// or (-1, -1) if no empty cells are found.
    /// </returns>
    private (int Row, int Column) GetEmpty()
    {
        for (var r = 0; r < 9; r++)
        {
            for (var c = 0; c < 9; c++)
            {
                if (_board[r, c] == 0) return (r, c);
            }
        }

        return (-1, -1);
    }

    /// <summary>
    /// Determines whether placing a given number in a specific cell
    /// on the Sudoku board is valid, according to Sudoku rules.
    /// </summary>
    /// <param name="row">The row index of the cell being validated.</param>
    /// <param name="col">The column index of the cell being validated.</param>
    /// <param name="num">The number being checked for validity.</param>
    /// <returns>
    /// True if the number can be placed in the specified cell without
    /// violating Sudoku rules; otherwise, false.
    /// </returns>
    private bool IsCorrect(int row, int col, int num)
    {
        // Check row and column for duplicates
        for (var i = 0; i < 9; i++)
        {
            if (_board[row, i] == num) return false;
            if (_board[i, col] == num) return false;
        }

        // Check 3x3 subgrid for duplicates
        var rs = row - row % 3;
        var cs = col - col % 3;
        for (var r = rs; r < rs + 3; r++)
        {
            for (var c = cs; c < cs + 3; c++)
            {
                if (_board[r, c] == num) return false;
            }
        }

        return true;
    }

    public void Print()
    {
        for (var r = 0; r < 9; r++)
        {
            if (r % 3 == 0 && r != 0)
                Console.WriteLine("-----------------------------");

            for (var c = 0; c < 9; c++)
            {
                if (c % 3 == 0 && c != 0)
                    Console.Write("|");

                Console.Write($" {_board[r, c]} ");
            }

            Console.WriteLine();
        }
    }
}
