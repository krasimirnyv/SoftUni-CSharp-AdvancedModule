namespace _10.RadioactiveMutantVampireBunnies;

class Program
{
    static void Main(string[] args)
    {
        
        int[] dimensions = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        
        int rows = dimensions[0],
            cols = dimensions[1];
        
        char[,] matrix = ReadMatrix(rows, cols);
        char[] commands = Console.ReadLine().ToCharArray();

        (int row, int col) = FindPlayer(matrix, 'P');

        var (isPlayerDead, isPlayerWon, lastRow, lastCol) = PlayerMove(commands, matrix, row, col);
        
        PrintMatrix(matrix);

        if (isPlayerWon)
        {
            Console.WriteLine($"won: {lastRow} {lastCol}");
        } 
        else if (isPlayerDead)
        {
            Console.WriteLine($"dead: {lastRow} {lastCol}");
        }
        
    }

    static (bool isPlayerDead, bool isPlayerWon, int lastRow, int lastCol) PlayerMove(char[] commands, char[,] matrix, int row, int col)
    {
        bool isPlayerDead = false,
             isPlayerWon = false;
        
        int lastRow = row,
            lastCol = col;
        
        foreach (char command in commands)
        {
            int[] change = playerMoves[command];
            int nextRow = row + change[0],
                nextCol = col + change[1];
            
            matrix[row, col] = '.';
            
            // Wins
            if (!IsValid(matrix, nextRow, nextCol))
            {
                FindBunnies(matrix);
                isPlayerWon = true;
                lastRow = row;
                lastCol = col;
                break;
            } 
            
            // Dies
            if (matrix[nextRow, nextCol] == 'B')
            {
                row = nextRow;
                col = nextCol;
                FindBunnies(matrix);
                isPlayerDead = true;
                lastRow = row;
                lastCol = col;
                break;
            }
            
            // Alive
            row = nextRow; 
            col = nextCol;
            matrix[nextRow, nextCol] = 'P';
            
            FindBunnies(matrix);
            // Still alive?
            if (matrix[row, col] == 'B')
            {
                isPlayerDead = true;
                lastRow = row;
                lastCol = col;
                break;           
            }
        }

        return (isPlayerDead, isPlayerWon, lastRow, lastCol);
    }
    
    static readonly Dictionary<char, int[]> playerMoves = new()
    {
        ['U'] = new[] { -1, 0 }, // up
        ['R'] = new[] { 0, 1 },  // right
        ['D'] = new[] { 1, 0 },  // down
        ['L'] = new[] { 0, -1 }  // left
    };

    static char[,] ReadMatrix(int rows, int cols)
    {
        char[,] matrix = new char[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            char[] values = Console.ReadLine().ToCharArray();
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = values[col];
            }
        }
        
        return matrix;
    }
    
    static (int RowIndex, int ColIndex) FindPlayer(char[,] matrix, char symbol)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == symbol)
                {
                    return (row, col);
                }
            }
        }

        throw new InvalidOperationException("Player is not found");
    }

    static void FindBunnies(char[,] matrix)
    {
        List<(int row, int col)> bunnies = new List<(int row, int col)>();
        
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 'B')
                {
                    bunnies.Add((row, col));
                }
            }
        }
        
        foreach ((int row, int col) bunny in bunnies)
        {
            SpreadBunnies(matrix, bunny.row, bunny.col);
        }
    }

    static void SpreadBunnies(char[,] matrix, int row, int col)
    {
        for (int i = 0; i < bunniesMove.GetLength(0); i++)
        {
            int nextRow = row + bunniesMove[i, 0],
                nextCol = col + bunniesMove[i, 1];

            if (IsValid(matrix, nextRow, nextCol) &&
                matrix[nextRow, nextCol] != 'B')
            {
                matrix[nextRow, nextCol] = 'B';
            }
        } 
    }

    static readonly int[,] bunniesMove =
    {
        { -1, 0 }, // up
        { 1, 0 },  // down
        { 0, -1 }, // left
        { 0, 1 }   // right
    };
    
    static bool IsValid(char[,] matrix, int row, int col)
    {
        return row >= 0 && row < matrix.GetLength(0) &&
               col >= 0 && col < matrix.GetLength(1);
    }
    
    static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            
            Console.WriteLine();
        }
    }
}
