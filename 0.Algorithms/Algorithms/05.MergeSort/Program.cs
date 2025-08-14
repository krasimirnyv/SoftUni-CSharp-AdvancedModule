namespace _05.MergeSort;

// III. Simple Sorting Algorithms

class Program
{
    static void Main(string[] args)
    {
        int[] array = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Console.WriteLine(string.Join(' ', Mergesort<int>.Sort(array)));
    }
}

public class Mergesort<T> where T : IComparable
{
    private static T[] _auxiliaryArray;
    
    public static T[] Sort(T[] array)
    {
        _auxiliaryArray = new T[array.Length];
        Sort(array, 0, array.Length - 1);
        
        return array;
    }
    
    private static void Sort(T[] array, int low, int high)
    {
        if (low >= high) 
            return;
        
        int mid = low + (high - low) / 2;
        Sort(array, low, mid);
        Sort(array, mid + 1, high);
        Merge(array, low, mid, high);
    }
    
    private static void Merge(T[] array, int low, int mid, int high)
    {
        if (IsLess(array[mid], array[mid + 1])) 
            return;

        for (int index = low; index <= high; index++)
            _auxiliaryArray[index] = array[index];
        
        int i = low;
        int j = mid + 1;
        for (int k = low; k <= high; k++)
        {
            if (i > mid)
            {
                array[k] = _auxiliaryArray[j++];
            }
            else if (j > high)
            {
                array[k] = _auxiliaryArray[i++];
            }
            else if (IsLess(_auxiliaryArray[i], _auxiliaryArray[j]))
            {
                array[k] = _auxiliaryArray[i++];
            }
            else
            {
                array[k] = _auxiliaryArray[j++];
            }
        }
    }

    private static bool IsLess(T comparable1, T comparable2)
        => comparable1.CompareTo(comparable2) < 0;
}