namespace _04.EvenTimes;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, int> numbers = new Dictionary<int, int>();
        
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if (!numbers.ContainsKey(number))
                numbers[number] = 0;

            numbers[number]++;
        }

        Console.WriteLine(numbers.First(x => x.Value % 2 == 0).Key);
    }
}
