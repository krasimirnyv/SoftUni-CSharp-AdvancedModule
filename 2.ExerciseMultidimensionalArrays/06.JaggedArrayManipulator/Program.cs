namespace _06.JaggedArrayManipulator;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        
        int[][] jaggedArray = new int[n][];

        for (int i = 0; i < n; i++)
        {
            jaggedArray[i] = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();;
        }

        for (int i = 0; i < n - 1; i++)
        {
            AnalizeRows(jaggedArray, i);
        }

        string input = default;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            string command = tokens[0];
            switch (command)
            {
                case "Add":
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    int value = int.Parse(tokens[3]);

                    if (row >= 0 && row < jaggedArray.Length && 
                        col >= 0 && col < jaggedArray[row].Length)
                    {
                        jaggedArray[row][col] += value;
                    }
                    break;
                case "Subtract":
                    row = int.Parse(tokens[1]);
                    col = int.Parse(tokens[2]);
                    value = int.Parse(tokens[3]);
                    
                    if (row >= 0 && row < jaggedArray.Length && 
                        col >= 0 && col < jaggedArray[row].Length)
                    {
                        jaggedArray[row][col] -= value;
                    }
                    break;
            }
        }

        foreach (int[] row in jaggedArray)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }

    private static void AnalizeRows(int[][] jaggedArray, int i)
    {
        // equal length
        if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                jaggedArray[i][j] *= 2;
                jaggedArray[i + 1][j] *= 2;
            }
        }
        else // different length
        {
            int minLength = Math.Min(jaggedArray[i].Length, jaggedArray[i + 1].Length);
            for (int j = 0; j < minLength; j++)
            {
                jaggedArray[i][j] /= 2;
                jaggedArray[i + 1][j] /= 2;
            }

            // one of the arrays is longer than the other
            if (jaggedArray[i].Length > jaggedArray[i + 1].Length)
            {
                for (int j = minLength; j < jaggedArray[i].Length; j++)
                {
                    jaggedArray[i][j] /= 2;
                }
            }
            else // jaggedArray[i].Length < jaggedArray[i + 1].Length
            {
                for (int j = minLength; j < jaggedArray[i + 1].Length; j++)
                {
                    jaggedArray[i + 1][j] /= 2;   
                }
            }
        }
    }
}
