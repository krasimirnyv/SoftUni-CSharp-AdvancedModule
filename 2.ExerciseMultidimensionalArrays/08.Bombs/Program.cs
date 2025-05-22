namespace _08.Bombs;

class Program
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        
        int[,] matrix = ReadMatrix(size);
        
        List<string> coordinates = Console.ReadLine()
            .Split(' ')
            .ToList();

        foreach (string coordinate in coordinates)
        {
            string[] tokens = coordinate.Split(',', StringSplitOptions.RemoveEmptyEntries);
            
            int row = int.Parse(tokens[0]),
                col = int.Parse(tokens[1]);
            
            if (row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1) ||
                matrix[row, col] <= 0)
            {
                continue;
            }
            
            int damage = matrix[row, col];
            matrix[row, col] = 0;

            DealDamage(matrix, row, col, damage);
        }

        CountAliveCells(matrix);
        PrintMatrix(matrix);
    }
    
    static int[,] ReadMatrix(int size)
    {
        int[,] matrix = new int[size, size];

        for (int row = 0; row < size; row++)
        {
            int[] values = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int col = 0; col < size; col++)
            {
                matrix[row, col] = values[col];
            }
        }
        
        return matrix;
    }

    static void DealDamage(int[,] matrix, int row, int col, int damage)
    {
        for (int i = 0; i < cellsAround.GetLength(0); i++)
        {
            int nextRow = row + cellsAround[i, 0],
                nextCol = col + cellsAround[i, 1];

            if (nextRow >= 0 && nextRow < matrix.GetLength(0) &&
                nextCol >= 0 && nextCol < matrix.GetLength(1) &&
                matrix[nextRow, nextCol] > 0)
            {
                matrix[nextRow, nextCol] -= damage;
            }
        }
    }

    static int[,] cellsAround =
    {
        { -1, 0 }, // up
        { 1, 0 },  // down
        { 0, -1 }, // left
        { 0, 1 },  // right
        { -1, -1 },// up left
        { -1, 1 }, // up right
        { 1, -1 }, // down left
        { 1, 1 }   // down right
    };
    
    static void CountAliveCells(int[,] matrix)
    {
        int aliveCount = 0,
            aliveSum = 0;
        
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] > 0)
                {
                    aliveCount++;
                    aliveSum += matrix[row, col];
                }
            }
        }
        
        Console.WriteLine($"Alive cells: {aliveCount}\n" +
                          $"Sum: {aliveSum}");
    }
    
    private static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write($"{matrix[row, col]} ");
            }
            
            Console.WriteLine();
        }
    }
}