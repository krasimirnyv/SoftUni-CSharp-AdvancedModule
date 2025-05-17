namespace _03.MaximumAndMinimumElement;

class Program
{
    static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>();
        
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            int[] query = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            if (query[0] == 1)
            {
                stack.Push(query[1]);
            }
            else if (stack.Count > 0)
            {
                if (query[0] == 2)
                {
                    stack.Pop();
                }
                else if (query[0] == 3)
                {
                    Console.WriteLine(stack.Max());
                }
                else if (query[0] == 4)
                {
                    Console.WriteLine(stack.Min());
                }
            }
        }

        Console.WriteLine(string.Join(", ", stack));
    }
}
