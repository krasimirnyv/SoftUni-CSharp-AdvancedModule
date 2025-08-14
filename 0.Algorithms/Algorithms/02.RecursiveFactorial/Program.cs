namespace _02.RecursiveFactorial;

// I. Recursion

class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        int result = Factorial(number);
        Console.WriteLine(result);
    }

    private static int Factorial(int number)
    {
        if (number == 0)
            return 1;
        
        return number * Factorial(number - 1);
    }
}
