namespace Stack;

class Program
{
    static void Main(string[] args)
    {
        MyStack<int> stack = new MyStack<int>();
        
        string input = default;
        while ((input = Console.ReadLine()) != "END")
        {
            if (input == "Pop") stack.Pop();
            else // input == "Push ..."
            {
                input = input.Remove(0, 4);
                int[] numbers = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                foreach (int number in numbers) 
                    stack.Push(number);
            }
        }

        foreach (int number in stack)
            Console.WriteLine(number);
        
        foreach (int number in stack)
            Console.WriteLine(number);
    }
}
