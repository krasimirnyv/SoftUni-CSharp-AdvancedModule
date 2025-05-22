namespace _04.MatrixShuffling;

class Program
{
    static void Main(string[] args)
    {
        int[] dimensions = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int rows = dimensions[0], cols = dimensions[1];
        string[,] matrix = ReadMatrix(rows, cols);

        string input = default;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (!ValidateTokens(tokens, matrix))
            {
                Console.WriteLine("Invalid input!");
                continue;
            }
            
            int row1 = int.Parse(tokens[1]),
                col1 = int.Parse(tokens[2]),
                row2 = int.Parse(tokens[3]),
                col2 = int.Parse(tokens[4]);

            (matrix[row1, col1], matrix[row2, col2]) = (matrix[row2, col2], matrix[row1, col1]);
            
            Print(matrix);
        }
        
    }
    
    private static string[,] ReadMatrix(int rows, int cols)
    {
        string[,] matrix = new string[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            string[] values = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = values[col];
            }
        }

        return matrix;
    }
    
    private static bool ValidateTokens(string[] tokens, string[,] matrix)
    {
        // swap <row1> <col1> <row2> <col2>
        if (tokens.Length != 5 || tokens[0] != "swap")
        {
            return false;
        }
        
        // validate integers for rows and cols
        int row1, col1, row2, col2;
        bool isValidRow1 = int.TryParse(tokens[1], out row1);
        bool isValidCol1 = int.TryParse(tokens[2], out col1);
        bool isValidRow2 = int.TryParse(tokens[3], out row2);
        bool isValidCol2 = int.TryParse(tokens[4], out col2);

        if (!isValidRow1 || !isValidCol1 || !isValidRow2 || !isValidCol2)
        {
            return false;
        }
        
        // validate indexes for rows and cols in the matrix
        if (row1 < 0 || row1 >= matrix.GetLength(0) ||
            col1 < 0 || col1 >= matrix.GetLength(1) ||
            row2 < 0 || row2 >= matrix.GetLength(0) ||
            col2 < 0 || col2 >= matrix.GetLength(1))
        {
            return false;
        }

        return true;
    }
    
    private static void Print(string[,] matrix)
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