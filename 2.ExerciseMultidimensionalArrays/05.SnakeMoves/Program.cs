namespace _05.SnakeMoves;

class Program
{
    static void Main(string[] args)
    {
        int[] dimensions = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        
        int rows = dimensions[0], cols = dimensions[1];
        
        Queue<char> snake = new Queue<char>(Console.ReadLine().ToCharArray());
        
        char[][] matrix = ReadMatrix(rows, cols);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int actualIndex;
                if (i % 2 == 0)
                {
                    actualIndex = j;
                }
                else
                {
                    actualIndex = cols - (j + 1);
                }
                
                matrix[i][actualIndex] = snake.Peek();
                snake.Enqueue(snake.Dequeue());
            }
        }
        
        Print(matrix, rows, cols);
    }
    
    private static char[][] ReadMatrix(int rows, int cols)
    {
        char[][] matrix = new char[rows][];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
           matrix[row] = new char[cols];
        }

        return matrix;
    }
    
    private static void Print(char[][] matrix, int rows, int cols)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write($"{matrix[row][col]}");
            }
            
            Console.WriteLine();
        }
    }
}
