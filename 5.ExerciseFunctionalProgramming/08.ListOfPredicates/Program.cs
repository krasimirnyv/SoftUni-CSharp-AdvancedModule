namespace _08.ListOfPredicates;

class Program
{
    static void Main(string[] args)
    {
        int endRange = int.Parse(Console.ReadLine());
        HashSet<int> dividers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToHashSet();

        Predicate<int>[] condisions = new Predicate<int>[dividers.Count];

        for (int i = 0; i < dividers.Count; i++)
        {
            int divider = dividers.ElementAt(i);
            condisions[i] = x => x % divider == 0;
        }

        int[] result = FilterInRange(1, endRange, condisions);
        Console.WriteLine(string.Join(' ', result));
    }

    static int[] FilterInRange(int start, int end, Predicate<int>[] condisions)
    {
        List<int> result = [];
        for (int i = start; i <= end; i++)
        {
            if (MatchesAll(i, condisions))
                result.Add(i);
        }

        return result.ToArray();
    }

    static bool MatchesAll(int value, Predicate<int>[ ] condisions)
    {
        foreach (Predicate<int> condision in condisions)
        {
            if (!condision(value))
                return false;
        }

        return true;
    }
}
