namespace _08.Ranking;

class Program
{
    static void Main(string[] args)
    {
        // contest -> password
        Dictionary<string, string> passwordByContest = ReadContestsInfo();
        // username -> contest -> points
        Dictionary<string, Dictionary<string, int>> internsInfo = ReadInternsInfo(passwordByContest);

        int maxPoints = 0;
        string bestIntern = String.Empty;
        foreach (var (intern, submissions) in internsInfo)
        {
            int totalPoints = submissions.Sum(x => x.Value);
            if (totalPoints > maxPoints)
            {
                maxPoints = totalPoints;
                bestIntern = intern;
            }
        }

        Console.WriteLine($"Best candidate is {bestIntern} with total {maxPoints} points.\n" +
                          $"Ranking:");

        foreach (var (intern, submissions) in internsInfo.OrderBy(x => x.Key))
        {
            Console.WriteLine(intern);
            foreach (var (contest, points) in submissions.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"#  {contest} -> {points}");
            }
        }
    }
    
    private static Dictionary<string, string> ReadContestsInfo()
    {
        // contest -> password
        Dictionary<string, string> result = new Dictionary<string, string>();
        
        string input = default;
        while ((input = Console.ReadLine()) != "end of contests")
        {
            string[] tokens = input.Split(':');
            string contest = tokens[0],
                   password = tokens[1];
            
            result[contest] = password;
        }
        
        return result;
    }
    
    private static Dictionary<string, Dictionary<string, int>> ReadInternsInfo(Dictionary<string, string> passwordByContest)
    {
        // username -> contest -> points
        Dictionary<string, Dictionary<string, int>> result = new Dictionary<string, Dictionary<string, int>>();

        string input = default;
        while ((input = Console.ReadLine()) != "end of submissions")
        {
            string[] tokens = input.Split("=>");
            string contest = tokens[0],
                password = tokens[1],
                username = tokens[2];
            
            int points = int.Parse(tokens[3]);

            if (!passwordByContest.ContainsKey(contest) || passwordByContest[contest] != password)
                continue;

            if (!result.ContainsKey(username))
                result[username] = new Dictionary<string, int>();

            if (!result[username].ContainsKey(contest))
                result[username][contest] = 0;

            if (points > result[username][contest])
                result[username][contest] = points;
        }

        return result;
    }
}
