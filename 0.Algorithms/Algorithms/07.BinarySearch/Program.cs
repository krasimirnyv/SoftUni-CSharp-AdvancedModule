namespace _07.BinarySearch;

// IV. Searching Algorithms

class Program
{
    static void Main(string[] args)
    {
        int[] array = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int keyNumber = int.Parse(Console.ReadLine());

        Console.WriteLine(BinarySearch.IndexOf(array, keyNumber));
    }
}

public class BinarySearch
{
    public static int IndexOf(int[] array, int key)
    {
        int low = 0;
        int high = array.Length - 1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (array[mid] > key)
            {
                high = mid - 1; // Search in the left half
            }
            else if (array[mid] < key)
            {
                low = mid + 1; // Search in the right half
            }
            else
            {
                return mid; // Found the key
            }
        }
        
        return -1; // Key not found
    }
}