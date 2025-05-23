namespace _03.PeriodicTable;

class Program
{
    static void Main(string[] args)
    {
        HashSet<string> periodicTable = new HashSet<string>();
        
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] elements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string element in elements)
            {
                periodicTable.Add(element);
            }
        }

        Console.WriteLine(string.Join(' ', periodicTable.OrderBy(x => x)));
    }
}
