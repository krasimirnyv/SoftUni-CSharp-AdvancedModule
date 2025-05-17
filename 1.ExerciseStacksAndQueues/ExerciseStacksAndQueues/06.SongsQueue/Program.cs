namespace _06.SongsQueue;

class Program
{
    static void Main(string[] args)
    {
        Queue<string> songs = new Queue<string>();
        HashSet<string> uniqueNames = new HashSet<string>();

        string[] initialSongs = Console.ReadLine().Split(", ");

        foreach (string song in initialSongs)
        {
            AddSongToQueue(uniqueNames, song, songs);
        }
        
        while (songs.Count > 0)
        {
            string[] commands = Console.ReadLine().Split();
            if (commands[0] == "Play")
            {
                string removedSong = songs.Dequeue();
                uniqueNames.Remove(removedSong);
            }
            else if (commands[0] == "Add")
            {
                string song = string.Join(' ', commands.Skip(1));
                AddSongToQueue(uniqueNames, song, songs);
            }
            else if (commands[0] == "Show")
            {
                Console.WriteLine(string.Join(", ", songs));
            }
        }

        Console.WriteLine("No more songs!");
    }

    private static void AddSongToQueue(HashSet<string> uniqueNames, string song, Queue<string> songs)
    {
        if (uniqueNames.Add(song))
        {
            songs.Enqueue(song);
        }
        else
        {
            Console.WriteLine($"{song} is already contained!");
        }
    }
}
