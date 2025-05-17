using System.Globalization;

namespace _12.CupsAndBottles;

class Program
{
    static void Main(string[] args)
    {
        Stack<int> cups = ReadStackInReverse();
        Stack<int> bottles = ReadStack();

        int wastedWater = 0;
        while(cups.Count > 0 && bottles.Count > 0)
        {
            int currentCup = cups.Pop();
            int currentBottle = bottles.Pop();
            
            int diff = currentBottle - currentCup;
            if (diff < 0)
            {
                cups.Push(-1 * diff);
            }
            else
            {
                wastedWater += diff;
            }
        }

        if (bottles.Count > 0)
        {
            Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
        }
        else if (cups.Count > 0)
        {
            Console.WriteLine($"Cups: {string.Join(' ', cups)}");
        }

        Console.WriteLine($"Wasted litters of water: {wastedWater}");
    }

    static Stack<int> ReadStackInReverse()
    {
        Stack<int> toReverse = ReadStack();
        return new Stack<int>(toReverse);
    }

    static Stack<int> ReadStack() 
        => new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
}
