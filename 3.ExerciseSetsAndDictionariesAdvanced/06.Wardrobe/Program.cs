namespace _06.Wardrobe;

class Program
{
    static void Main(string[] args)
    {
        // color -> item -> count
        Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
        
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(" -> ");

            string color = input[0];
            string[] clothes = input[1].Split(',');

            if (!wardrobe.ContainsKey(color))
                wardrobe[color] = new Dictionary<string, int>();

            foreach (string item in clothes)
            {
                if (!wardrobe[color].ContainsKey(item))
                    wardrobe[color][item] = 0;
                
                wardrobe[color][item]++;
            }
        }
        
        string[] search = Console.ReadLine().Split(' ');

        foreach (var (color, clothes) in wardrobe)
        {
            Console.WriteLine($"{color} clothes:");
            foreach (var (item, count) in clothes)
            {
                string suffix = string.Empty;

                if (color == search[0] && item == search[1])
                    suffix = " (found!)";

                Console.WriteLine($"* {item} - {count}{suffix}");
            }
        }
    }
}
