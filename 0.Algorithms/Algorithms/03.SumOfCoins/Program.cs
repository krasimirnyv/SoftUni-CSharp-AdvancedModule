namespace _03.SumOfCoins;

// II. Greedy Algorithms

class Program
{
    static void Main(string[] args)
    {
        int[] availableCoins = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .OrderByDescending(c => c)
            .ToArray();
        
        int targetSum = int.Parse(Console.ReadLine());
        
        try
        {
            Dictionary<int, int> result = ChooseCoins(availableCoins, targetSum);
            
            Console.WriteLine($"Number of coins to take: {result.Values.Sum()}");
        
            foreach (var (valueOfCoin, numberOfCoins) in result)
                Console.WriteLine($"{numberOfCoins} coin(s) with value {valueOfCoin}");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Error");
        }
    }
    
    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        Dictionary<int, int> chosenCoins = new Dictionary<int, int>();
        
        int currentSum = 0;
        int index = 0;

        while (currentSum != targetSum && index < coins.Count)
        {
            int currentCoin = coins[index];
            int remainder = targetSum - currentSum;
            int numberOfCoinsToTake = remainder / currentCoin;

            if (currentSum + currentCoin <= targetSum)
            {
                chosenCoins.Add(currentCoin, numberOfCoinsToTake);
                currentSum += numberOfCoinsToTake * currentCoin;
            }
            
            index++;
        }

        if (currentSum != targetSum)
        {
            throw new InvalidOperationException();
        }
        
        return chosenCoins;
    }
}