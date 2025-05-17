namespace _02.BasicQueueOperations;

class Program
{
    static void Main(string[] args)
    {
        int[] input = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int toEnqueue = input[0], toDequeue = input[1], check = input[2];

        Queue<int> queue = new Queue<int>();
        
        int[] numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        for (int i = 0; i < toEnqueue; i++)
        {
            queue.Enqueue(numbers[i]);
        }

        for (int i = 0; i < toDequeue; i++)
        {
            if (queue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            
            queue.Dequeue();
        }

        if (queue.Count == 0)
        {
            Console.WriteLine(0);
        }
        else if (!queue.Contains(check))
        {
            Console.WriteLine(queue.Min());
        }
        else
        {
            Console.WriteLine("true");
        }
    }
}
