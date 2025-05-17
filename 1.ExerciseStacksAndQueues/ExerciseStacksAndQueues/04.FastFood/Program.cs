namespace _04.FastFood;

class Program
{
    static void Main(string[] args)
    {
        uint food = uint.Parse(Console.ReadLine());
        Queue<uint> orders = new Queue<uint>(Console.ReadLine().Split().Select(uint.Parse));
        
        Console.WriteLine(orders.Max());
        while (orders.Count > 0)
        {
            uint currentOrder = orders.Peek();
            if (food < currentOrder) 
                break;
            
            food -= orders.Dequeue();
        }

        Console.WriteLine(orders.Count == 0 ? "Orders complete" : $"Orders left: {string.Join(' ', orders)}");
    }
}
