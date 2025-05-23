namespace _07.TheV_Logger;

class Program
{
    static void Main(string[] args)
    {

        // vlogger -> followers
        Dictionary<string, HashSet<string>> followers = new Dictionary<string, HashSet<string>>();
        // vlogger -> followings
        Dictionary<string, HashSet<string>> followings = new Dictionary<string, HashSet<string>>();

        string input = default;
        while ((input = Console.ReadLine()) != "Statistics")
        {
            if (input.Contains(" joined "))
            {
                string[] tokens = input.Split(" joined ", StringSplitOptions.RemoveEmptyEntries);

                string vlogger = tokens[0];
                if (!followers.ContainsKey(vlogger))
                {
                    followers[vlogger] = new HashSet<string>();
                    followings[vlogger] = new HashSet<string>();
                }
            }
            else if (input.Contains(" followed "))
            {
                string[] tokens = input.Split(" followed ", StringSplitOptions.RemoveEmptyEntries);

                string follower = tokens[0];
                string followed = tokens[1];

                if (!followers.ContainsKey(follower) ||
                    !followers.ContainsKey(followed) ||
                    follower == followed ||
                    followings[follower].Contains(followed))
                {
                    continue;
                }

                followers[followed].Add(follower);
                followings[follower].Add(followed);
            }
        }

        Console.WriteLine($"The V-Logger has a total of {followers.Count} vloggers in its logs.");

        var sorted = followers
            .OrderByDescending(x => x.Value.Count)
            .ThenBy(x => followings[x.Key].Count)
            .ThenBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Value);

        int rank = 1;
        foreach (var kvp in sorted)
        {
            string vlogger = kvp.Key;
            int followerCount = kvp.Value.Count;
            int followingCount = followings[vlogger].Count;

            Console.WriteLine($"{rank}. {vlogger} : {followerCount} followers, {followingCount} following");

            if (rank == 1)
            {
                foreach (string follower in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"*  {follower}");
                }
            }

            rank++;
        }
    }
}
