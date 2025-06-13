namespace GenericBox;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<double> list = new List<double>(capacity: n);
        for (int i = 1; i <= n; i++)
        {
            double number = double.Parse(Console.ReadLine());
            list.Add(number);
        }
        
        double compareValue = double.Parse(Console.ReadLine());
        int count = CountGreaterThan(list, compareValue); 
        Console.WriteLine(count);
    }

    static int CountGreaterThan<TValue>(List<TValue> list, TValue compareValue)
    {
        int count = 0;
        foreach (TValue element in list)
        {
            if (Comparer<TValue>.Default.Compare(element, compareValue) > 0)
                count++;
        }
        
        return count;
    }
}
