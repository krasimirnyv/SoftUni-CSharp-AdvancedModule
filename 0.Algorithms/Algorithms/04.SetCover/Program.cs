namespace _04.SetCover;

// II. Greedy Algorithms

class Program
{
    static void Main(string[] args)
    {
        int[] universe = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int numbersOfSets = int.Parse(Console.ReadLine());
        int[][] sets = ReadJaggedArray(numbersOfSets);

        List<int[]> selectedSets = ChooseSets(sets.ToList(), universe.ToList());
        
        Console.WriteLine($"Sets to take ({selectedSets.Count}):");
        foreach (int[] set in selectedSets)
            Console.WriteLine($"{{ {string.Join(", ", set)} }}");
    }
    
    public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
    {
        List<int[]> selectedSets = new List<int[]>();

        while (universe.Count > 0)
        {
            int[] longestSet = sets
                .OrderByDescending(s => s.Count(x => universe.Contains(x)))
                .FirstOrDefault();
            
            selectedSets.Add(longestSet);
            sets.Remove(longestSet);
            universe = universe.Where(x => !longestSet.Contains(x)).ToList();
        }

        return selectedSets;
    }
    
    private static int[][] ReadJaggedArray(int numbersOfSets)
    {
        int[][] sets = new int[numbersOfSets][];
        
        for (int row = 0; row < numbersOfSets; row++)
        {
            int[] rowsValue = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            sets[row] = rowsValue;
        }
        
        return sets;
    }
}