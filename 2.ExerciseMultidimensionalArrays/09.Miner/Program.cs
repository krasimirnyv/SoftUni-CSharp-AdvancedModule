namespace _09.Miner;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int[]> moves = new Dictionary<string, int[]>
        {
            ["up"] = new[] { -1, 0 },
            ["right"] = new[] { 0, 1 },
            ["down"] = new[] { 1, 0 },
            ["left"] = new[] { 0, -1 }
        };
        
        int size = int.Parse(Console.ReadLine());
        string[] commands = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        char[,] matrix = ReadMatrix(size);

        (int row, int col) = Find(matrix, 's');
        int coals = Count(matrix, 'c');
        
        bool gameOver = false;
        foreach (string command in commands)
        {
            int[] change = moves[command];
            int nextRow = row + change[0],
                nextCol = col + change[1];

            if (nextRow < 0 || nextRow >= matrix.GetLength(0) ||
                nextCol < 0 || nextCol >= matrix.GetLength(1))
            {
                continue;
            }
            
            row = nextRow;
            col = nextCol;

            if (matrix[row, col] == 'c')
            {
                matrix[row, col] = '*';
                if (--coals == 0) 
                    break;
            }
            else if (matrix[row, col] == 'e')
            {
                gameOver = true;
                break;
            }
        }

        if (gameOver)
        {
            Console.WriteLine($"Game over! ({row}, {col})");
        }
        else if (coals == 0)
        {
            Console.WriteLine($"You collected all coals! ({row}, {col})");
        }
        else
        {
            Console.WriteLine($"{coals} coals left. ({row}, {col})");
        }
    }

    static char[,] ReadMatrix(int size)
    {
        char[,] matrix = new char[size, size];

        for (int row = 0; row < size; row++)
        {
            char[] values = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            for (int col = 0; col < size; col++)
            {
                matrix[row, col] = values[col];
            }
        }

        return matrix;
    }

    static (int RowIndex, int ColIndex) Find(char[,] matrix, char symbol)
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

        throw new InvalidOperationException("Start not found");
    }

    static int Count(char[,] matrix, char symbol)
    {
        int count = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == symbol)
                {
                    count++;
                }
            }
        }

        return count;
    }
}
