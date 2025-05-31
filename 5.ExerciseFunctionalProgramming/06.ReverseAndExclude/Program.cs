namespace _06.ReverseAndExclude;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int n = int.Parse(Console.ReadLine());
        Func<int, bool> condition = x => x % n != 0;

        int[] filtered = FilterInReverse(numbers, condition);
        Console.WriteLine(string.Join(' ', filtered));
    }
    
    static int[] FilterInReverse(int[] numbers, Func<int, bool> condition)
    {
        List<int> result = [];
        for (int i = numbers.Length - 1; i >= 0; i--)
        {
            if (condition(numbers[i])) 
                result.Add(numbers[i]);
        }
        
        return result.ToArray();
    }
}
