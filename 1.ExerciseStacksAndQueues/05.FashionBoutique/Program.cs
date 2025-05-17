namespace _05.FashionBoutique;

class Program
{
    static void Main(string[] args)
    {
        Stack<uint> stack = new Stack<uint>(Console.ReadLine().Split().Select(uint.Parse));
        
        uint rackCapacity = uint.Parse(Console.ReadLine());

        uint racks = 0, free = 0;
        while (stack.Count > 0)
        {
            uint currentCloth = stack.Pop();
            if (free < currentCloth)
            {
                racks++;
                free = rackCapacity;
            }

            free -= currentCloth;
        }

        Console.WriteLine(racks);
    }
}
