namespace _10.ForceBook;

class Program
{
    static void Main(string[] args)
    {
        // user -> side
        Dictionary<string, string> sideByUser = new Dictionary<string, string>();
        // side -> members
        Dictionary<string, HashSet<string>> membersBySide = new Dictionary<string, HashSet<string>>();

        string input = default;
        while ((input = Console.ReadLine()) != "Lumpawaroo")
        {
            if (input.Contains(" | "))
            {
                TryAddNewMember(input, sideByUser, membersBySide);
            }
            else if (input.Contains(" -> "))
            {
                MoveMembers(input, sideByUser, membersBySide);
            }
        }

        foreach (var (side, members) in membersBySide
                     .Where(x => x.Value.Count > 0)
                     .OrderByDescending(x => x.Value.Count)
                     .ThenBy(x => x.Key))
        {
            Console.WriteLine($"Side: {side}, Members: {members.Count}");
            foreach (string user in members.OrderBy(x => x))
            {
                Console.WriteLine($"! {user}");
            }
        }
    }
    
    private static void TryAddNewMember(string input, Dictionary<string, string> sideByUser, Dictionary<string, HashSet<string>> membersBySide)
    {
        string[] tokens = input.Split(" | ");
        string side = tokens[0],
               member = tokens[1];

        if (sideByUser.ContainsKey(member))
            return;

        SetMemberSide(member, side, sideByUser, membersBySide);
    }
    
    private static void MoveMembers(string input, Dictionary<string, string> sideByUser, Dictionary<string, HashSet<string>> membersBySide)
    {
        string[] tokens = input.Split(" -> ");
        string member = tokens[0],
               side = tokens[1];
        
        if (sideByUser.ContainsKey(member))
        {
            string currentSide = sideByUser[member];
            membersBySide[currentSide].Remove(member);
        }
        
        SetMemberSide(member, side, sideByUser, membersBySide);

        Console.WriteLine($"{member} joins the {side} side!");
    }
    
    private static void SetMemberSide(string member, string side, Dictionary<string, string> sideByUser, Dictionary<string, HashSet<string>> membersBySide)
    {
        sideByUser[member] = side;
        
        if(!membersBySide.ContainsKey(side))
            membersBySide[side] = new HashSet<string>();
        
        membersBySide[side].Add(member);
    }
}