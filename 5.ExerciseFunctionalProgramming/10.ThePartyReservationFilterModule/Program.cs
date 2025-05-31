using System.Diagnostics;

namespace _10.ThePartyReservationFilterModule;

class Program
{
    static void Main(string[] args)
    {
        HashSet<(string, string)> activeFilterKeys = [];

        Dictionary<string, Action<string, string>> operationHandlers = new Dictionary<string, Action<string, string>>
        {
            ["Add filter"] = (condition, parameter) =>
            {
                activeFilterKeys.Add((condition, parameter));
            },
            ["Remove filter"] = (condition, parameter) =>
            {
                activeFilterKeys.Remove((condition, parameter));
            }
        };

        Dictionary<string, Func<string, Func<string, bool>>> filterBuilders = new Dictionary<string, Func<string, Func<string, bool>>>
            {
                ["Starts with"] = parameter => value => value.StartsWith(parameter),
                ["Ends with"] = parameter => value => value.EndsWith(parameter),
                ["Length"] = parameter =>
                {
                    int length = int.Parse(parameter);
                    return value => value.Length == length;
                },
                ["Contains"] = parameter => value => value.Contains(parameter)
            };
        
        string[] guests = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        string command = default;
        while ((command = Console.ReadLine()) != "Print")
        {
            string[] tokens = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
            string operation = tokens[0],
                   condition = tokens[1],
                   parameter = tokens[2];

            operationHandlers[operation](condition, parameter);
        }

        string[] filteredGuests = ApplyFilters(guests, activeFilterKeys, filterBuilders);
        Console.WriteLine(string.Join(' ', filteredGuests));
    }

    static string[] ApplyFilters(string[] guests, HashSet<(string, string)> activeFilterKeys,
        Dictionary<string, Func<string, Func<string, bool>>> filterBuilders)
    {
        List<string> result = [];

        foreach (string name in guests)
        {
            bool isFiltered = false;
            foreach (var (condition, parameter) in activeFilterKeys)
            {
                Func<string, bool> predicate = filterBuilders[condition](parameter);
                if (predicate(name))
                {
                    isFiltered = true;
                    break;
                }
            }
            
            if (!isFiltered)
                result.Add(name);
        }

        return result.ToArray();
    }
}
