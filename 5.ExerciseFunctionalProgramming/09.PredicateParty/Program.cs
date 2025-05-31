namespace _09.PredicateParty;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Action<List<string>, int>> mutationHandlers = new Dictionary<string, Action<List<string>, int>>
        {
            ["Remove"] = (list, index) => list.RemoveAt(index),
            ["Double"] = (list, index) => list.Insert(index + 1, list[index])
        };
        
        Dictionary<string, Func<string, Func<string, bool>>> conditionHandlers = new Dictionary<string, Func<string, Func<string, bool>>>
            {
                ["StartsWith"] = parameter =>
                {
                    return value => value.StartsWith(parameter);
                },
                ["EndsWith"] = parameter =>
                {
                    return value => value.EndsWith(parameter);
                },
                ["Length"] = parameter =>
                {
                    int length = int.Parse(parameter);
                    return value => value.Length == length;
                }
            }; 
        
        List<string> guests = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        string command = default;
        while ((command = Console.ReadLine()) != "Party!")
        {
            string[] line = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string action = line[0],
                   condition = line[1], 
                   parameter = line[2];
            
            Func<string, Func<string, bool>> conditionBuilder = conditionHandlers[condition];
            Func<string, bool> conditionFunc = conditionBuilder(parameter);
            Action<List<string>, int> mutator = mutationHandlers[action];
            
            ExecuteCommand(guests, conditionFunc, mutator);
        }

        Console.WriteLine(guests.Count == 0
            ? "Nobody is going to the party!"
            : $"{string.Join(", ", guests)} are going to the party!");
    }
    
    static void ExecuteCommand(List<string> guests, Func<string, bool> condition, Action<List<string>, int> mutator)
    {
        for (int i = guests.Count - 1; i >= 0; i--)
        {
            if (condition(guests[i])) 
                mutator(guests, i);
        }
    }
}
