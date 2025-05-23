namespace _02.SetsOfElements;

class Program
{
    static void Main(string[] args)
    {
        int[] sizes = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int n = sizes[0],
            m = sizes[1];
        
        HashSet<int> first = ReadNumbers(n);
        HashSet<int> second = ReadNumbers(m);

        first.IntersectWith(second);
        Console.WriteLine(string.Join(' ', first));
    }

    static HashSet<int> ReadNumbers(int count)
    {
        HashSet<int> numbers = new HashSet<int>();

        for (int i = 0; i < count; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());
            numbers.Add(currentNumber);
        }

        return numbers;
    }
}