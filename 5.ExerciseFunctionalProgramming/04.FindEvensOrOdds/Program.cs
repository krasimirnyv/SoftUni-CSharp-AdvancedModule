namespace _04.FindEvensOrOdds;

class Program
{
    static void Main(string[] args)
    {
        int[] range = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int start = range[0], end = range[1];
        string command = Console.ReadLine();

        Predicate<int> condition = command switch
        {
            "even" => x => x % 2 == 0,
            "odd" => x => x % 2 != 0,
            _ => throw new InvalidOperationException("Invalid command")
        };

        int[] result = FilterRange(start, end, condition);
        Console.WriteLine(string.Join(' ', result));
    }

    static int[] FilterRange(int start, int end, Predicate<int> condition)
    {
        List<int> result = [];
        for (int i = start; i <= end; i++)
        {
            if (condition(i))
                result.Add(i);
        }

        return result.ToArray();
    }
}
