namespace _03.MaximalSum;

class Program
{
    static void Main(string[] args)
    {
        int[] dimensions = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        
        int rows = dimensions[0];
        int cols = dimensions[1];
        
        int[,] matrix = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            int[] values = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = values[col];
            }
        }

        int maxSum = int.MinValue;
        int maxSumRow = -1;
        int maxSumCol = -1;

        for (int i = 0; i < rows - 2; i++)
        {
            for (int j = 0; j < cols - 2; j++)
            {
                int sum = Sum(matrix, i, j, 3, 3);
                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxSumRow = i;
                    maxSumCol = j;
                }
            }
        }

        Console.WriteLine($"Sum = {maxSum}");
        Print(matrix, maxSumRow, maxSumCol, 3, 3);
    }
    
    static int Sum(int[,] matrix, int startRow, int startCol, int rows, int cols)
    {
        int sum = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                sum += matrix[startRow + i, startCol + j];
            }
        }

        return sum;
    }
    
    static void Print(int[,] matrix, int maxSumRow, int maxSumCol, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[maxSumRow + i, maxSumCol + j]} ");
            }

            Console.WriteLine();
        }
    }
}
