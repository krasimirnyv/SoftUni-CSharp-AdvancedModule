namespace _01.BasicStackOperations;

class Program
{
    static void Main(string[] args)
    {
        int[] input = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        
        int pushing = input[0], poping = input[1], check = input[2];
        
        Stack<int> stack = new Stack<int>();
        
        int[] numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        
        for (int i = 0; i < pushing; i++)
        {
            stack.Push(numbers[i]);
        }

        for (int i = 0; i < poping; i++)
        {
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;           
            }
            
            stack.Pop();
        }

        if (stack.Count == 0)
        {
            Console.WriteLine(0);
        }
        else if (!stack.Contains(check))
        {
            Console.WriteLine(stack.Min());
        }
        else
        {
            Console.WriteLine("true");
        }
    }
}