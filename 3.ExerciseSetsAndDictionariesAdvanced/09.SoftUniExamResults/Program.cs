namespace _09.SoftUniExamResults;

class Program
{
    static void Main(string[] args)
    {
        
        // user -> points
        Dictionary<string, int> maxPointsByUser = new Dictionary<string,int>();
        // language -> submissions
        Dictionary<string, int> submissionsCountByLanguage = new Dictionary<string, int>();
        
        HashSet<string> bannedUsers = new HashSet<string>();

        string input = default;
        while ((input = Console.ReadLine()) != "exam finished")
        {
            string[] tokens = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
            string username = tokens[0];
            
            if (tokens.Length == 2)
            {
                bannedUsers.Add(username);
            }
            else if (tokens.Length == 3)
            {
                string language = tokens[1];
                int points = int.Parse(tokens[2]);

                if (!maxPointsByUser.ContainsKey(username))
                    maxPointsByUser[username] = 0;

                if (points > maxPointsByUser[username])
                    maxPointsByUser[username] = points;

                if (!submissionsCountByLanguage.ContainsKey(language))
                    submissionsCountByLanguage[language] = 0;

                submissionsCountByLanguage[language]++;
            }
        }

        Console.WriteLine("Results:");
        foreach (var (username, points) in maxPointsByUser
                     .Where(x => !bannedUsers.Contains(x.Key))
                     .OrderByDescending(x => x.Value)
                     .ThenBy(x => x.Key))
        {
            Console.WriteLine($"{username} | {points}");
        }

        Console.WriteLine("Submissions:");
        foreach (var (language, count) in submissionsCountByLanguage
                     .OrderByDescending(x => x.Value)
                     .ThenBy(x => x.Key))
        {
            Console.WriteLine($"{language} - {count}");
        }
    }
}
