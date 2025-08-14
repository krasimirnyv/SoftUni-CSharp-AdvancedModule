namespace _06.Quicksort;

// III. Simple Sorting Algorithms

class Program
{
    static void Main(string[] args)
    {
        int[] array = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        
        Console.WriteLine(string.Join(' ', Quick.Sort(array)));
    }
}

public class Quick
{
    private static readonly Random random = new Random();
    
    public static T[] Sort<T>(T[] array) where T : IComparable<T>
    {
        Shuffle(array);
        Sort(array, 0, array.Length - 1);
        
        return array;
    }

    private static void Shuffle<T>(T[] array) where T : IComparable<T>
    {
        for (int i = 0; i < array.Length; i++)
        {
            int randomNumber = random.Next(i, array.Length);
            Swap(array, i, randomNumber);
        }
    }
    private static void Sort<T>(T[] array, int low, int high) where T : IComparable<T>
    {
        if(low >= high)
            return;
        
        int pivotIndex = Partition(array, low, high);
        Sort(array, low, pivotIndex - 1);
        Sort(array, pivotIndex + 1, high);
    }

    private static int Partition<T>(T[] array, int low, int high) where T : IComparable<T>
    {
        if (low >= high)
            return low;

        int i = low;
        int j = high + 1;

        while (true)
        {
            while (Less(array[++i], array[low]))
            {
                if(i == high)
                    break;
            }

            while (Less(array[low], array[--j]))
            {
                if(j == low)
                    break;
            }
            
            if(i >= j)
                break;

            Swap(array, i, j);
        }

        Swap(array, low, j);
        return j;
    }
    
    private static bool Less<T>(T comparable1, T comparable2) where T : IComparable<T>
        => comparable1.CompareTo(comparable2) < 0;
    
    private static void Swap<T>(T[] array, int low, int j) where T : IComparable<T>
    {
        (array[low], array[j]) = (array[j], array[low]);
    }
}
