namespace _08.BalancedParenthesis;

class Program
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine()!;

        Console.WriteLine(IsBalanced(text) ? "YES" : "NO");
    }

    private static bool IsBalanced(string text)
    {
        Dictionary<char, char> parenthesis = new Dictionary<char, char>
        {
            {'{', '}'},
            {'[', ']'},
            {'(', ')'}
        };
        
        Stack<char> stack = new Stack<char>();

        foreach (char symbol in text)
        {
            if (parenthesis.ContainsKey(symbol))
            {
                stack.Push(parenthesis[symbol]);
            }
            else
            {
                if (stack.Count == 0)
                    return false;

                char expectedSymbol = stack.Peek();
                if(expectedSymbol != symbol)
                    return false;
                
                stack.Pop();
            }
        }
        
        return stack.Count == 0;
    }
}
