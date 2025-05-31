namespace _03.CustomMinFunction;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Func<int, int, int> findMin = (element, min) => element < min ? element : min;

        int min = Aggregate(numbers, int.MaxValue, findMin);
        Console.WriteLine(min);
    }
    
    static int Aggregate(int[] numbers, int initialValue, Func<int, int, int> agregate)
    {
        if (numbers.Length == 0)
            throw new InvalidOperationException("Cannot find minimum element of empty array");
        
        int accumulatedValue = initialValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            accumulatedValue = agregate(numbers[i], accumulatedValue);
        }

        return accumulatedValue;
    }
}
