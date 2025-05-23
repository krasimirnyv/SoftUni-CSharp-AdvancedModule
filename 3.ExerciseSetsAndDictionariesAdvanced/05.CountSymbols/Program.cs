namespace _05.CountSymbols;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<char, int> countsBySymbol = new Dictionary<char, int>();
        
        string text = Console.ReadLine();
        foreach (char symbol in text)
        {
            if (!countsBySymbol.ContainsKey(symbol))
                countsBySymbol[symbol] = 0;

            countsBySymbol[symbol]++;
        }

        foreach (var (symbol, count) in countsBySymbol
                     .OrderBy(x => x.Key))
        {
            Console.WriteLine($"{symbol}: {count} time/s");
        }
    }
}
