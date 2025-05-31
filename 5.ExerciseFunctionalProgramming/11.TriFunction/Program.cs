namespace _11.TriFunction;

class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        string[] names = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Func<string, int, bool> conditionBuilder = (name, num) => GetCharSum(name) >= num;
        Func<string, bool> condition = name => conditionBuilder(name, number);

        PrintFirstName(names, condition);
    }

    static int GetCharSum(string word)
    {
        int sum = 0;
        foreach (char symbol in word)
        {
            sum += symbol;
        }

        return sum;
    }
    
    static void PrintFirstName(string[] names, Func<string, bool> condition)
    {
        foreach (string name in names)
        {
            if (condition(name))
            {
                Console.WriteLine(name);
                return;
            }
        }
    }
}
