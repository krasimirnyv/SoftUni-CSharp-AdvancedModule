namespace _01.ActionPrint;

class Program
{
    static void Main(string[] args)
    {
        string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        Action<string> print = Console.WriteLine;
        
        ForEach(names, print);
    }

    static void ForEach(string[] names, Action<string> action)
    {
        foreach (string name in names)
        {
            action(name);
        }
    }
}
