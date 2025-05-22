namespace _07.KnightGame;

class Program
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        
        bool[,] board = ReadMatrix(size);

        int actions = 0;
        bool checkForConflict = true;
        while (checkForConflict)
        {
            int maxConflicts = 0,
                maxConflictsRow = -1,
                maxConflictsCol = -1;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (!board[row, col])
                    {
                        continue;
                    }
                    
                    int conflicts = CountConflicts(board, row, col);
                    if (conflicts > maxConflicts)
                    {
                        maxConflicts = conflicts;
                        maxConflictsRow = row;
                        maxConflictsCol = col;
                    }
                }
            }

            if (maxConflicts == 0)
            {
                checkForConflict = false;
            }
            else
            {
                board[maxConflictsRow, maxConflictsCol] = false;
                actions++;
            }
        }

        Console.WriteLine(actions);
    }

    private static bool[,] ReadMatrix(int size)
    {
        bool[,] matrix = new bool[size, size];

        for (int row = 0; row < size; row++)
        {
            string values = Console.ReadLine();
            for (int col = 0; col < size; col++)
            {
                matrix[row, col] = (values[col] == 'K');
            }
        }

        return matrix;
    }

    private static int CountConflicts(bool[,] matrix, int row, int col)
    {
        int count = 0;
        for (int i = 0; i < Moves.GetLength(0); i++)
        {
            int nextRow = row + Moves[i, 0],
                nextCol = col + Moves[i, 1];

            if (nextRow < 0 || nextRow >= matrix.GetLength(0) ||
                nextCol < 0 || nextCol >= matrix.GetLength(1))
            {
                continue;
            }

            if (matrix[nextRow, nextCol])
            {
                count++;
            }
        }
        
        return count;
    }

    private static readonly int[,] Moves =
    {
        { 1, 2 },
        { 1, -2 },
        { -1, 2 },
        { -1, -2 },
        { 2, 1 },
        { 2, -1 },
        { -2, 1 },
        { -2, -1 }
    };
}