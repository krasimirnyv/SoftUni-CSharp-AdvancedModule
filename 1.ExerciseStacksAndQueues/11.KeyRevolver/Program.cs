namespace _11.KeyRevolver;

class Program
{
    static void Main(string[] args)
    {
        int bulletPrice = int.Parse(Console.ReadLine());
        int gunBarrelSize = int.Parse(Console.ReadLine());
        Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
        Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
        int intelligenceValue = int.Parse(Console.ReadLine());

        int currentBarrel = gunBarrelSize;
        while (bullets.Count > 0 && locks.Count > 0)
        {
            currentBarrel--;
            int bulletSize = bullets.Pop();
            intelligenceValue -= bulletPrice;
            int lockerSize = locks.Peek();

            if (bulletSize <= lockerSize)
            {
                Console.WriteLine("Bang!");
                locks.Dequeue();
            }
            else if (bulletSize > lockerSize)
            {
                Console.WriteLine("Ping!");
            }
            
            if (currentBarrel == 0 && bullets.Count > 0)
            {
                Console.WriteLine("Reloading!");
                currentBarrel = bullets.Count < gunBarrelSize ? bullets.Count : gunBarrelSize;
            }
        }

        if (locks.Count == 0)
            Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue}");
        else if (bullets.Count == 0)
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
    }
}
