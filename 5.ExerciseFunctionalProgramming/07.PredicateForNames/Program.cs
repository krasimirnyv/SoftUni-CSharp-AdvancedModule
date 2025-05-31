namespace _07.PredicateForNames;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Func<string, bool> condition = x => x.Length <= n;
        PrintWhere(names, condition);
    }

    static void PrintWhere(string[] names, Func<string, bool> condition)
    {
        foreach (string name in names)
        {
            if (condition(name))
                Console.WriteLine(name);
        }
    }
}
