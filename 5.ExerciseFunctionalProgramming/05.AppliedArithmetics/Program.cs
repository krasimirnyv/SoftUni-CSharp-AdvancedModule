using System.Globalization;

namespace _05.AppliedArithmetics;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        
        Dictionary<string, Action<int[]>> commandHandlers = new Dictionary<string, Action<int[]>>()
        {
            {"add", arr=> Mutate(arr, x => x + 1)},
            {"multiply", arr => Mutate(arr, x => x * 2)},
            {"subtract", arr => Mutate(arr, x => x - 1)},
            {"print", arr => Console.WriteLine(string.Join(' ', arr))}
        };
        
        

        string command = default;
        while ((command = Console.ReadLine()) != "end")
        {
            Action<int[]> handler = commandHandlers[command];
            handler(numbers);
        }
    }

    static void Mutate(int[] numbers, Func<int, int> changeFunc)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = changeFunc(numbers[i]);
        }
    }
}
