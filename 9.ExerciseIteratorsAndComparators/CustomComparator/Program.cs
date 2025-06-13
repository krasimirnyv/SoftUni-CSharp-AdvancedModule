namespace CustomComparator;

public class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        IComparer<int> myComparer = Comparer<int>.Create((a, b) =>
        {
            bool aIsEven = a % 2 == 0, bIsEven = b % 2 == 0;
            if (aIsEven == bIsEven)
                return Comparer<int>.Default.Compare(a, b);

            return aIsEven ? -1 : 1;
        });
        
        Array.Sort(numbers, myComparer);

        Console.WriteLine(string.Join(' ', numbers));
    }
}
