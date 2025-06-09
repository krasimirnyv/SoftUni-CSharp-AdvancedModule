namespace Workshop.List;

class Program
{
    static void Main(string[] args)
    {
        MyList();
        MyLinkedList();
    }

    private static void MyList()
    {
        MyList myList = new MyList();
        
        for (int i = 1; i <= 100; i++)
            myList.Add(Random.Shared.Next(0, 1000) + 1);

        for (int i = 0; i < 5; i++)
            myList[i] = 10 + i;
        
        myList.RemoveAt(3);
        myList.RemoveAt(1);
        
        myList.Insert(0, 8);
        myList.Insert(1, 88);
        
        for (int i = 0; i < myList.Count; i++)
            Console.Write($"{myList[i]} ");
        Console.WriteLine();

        for (int i = myList.Count - 1; i >= 0; i--)
            Console.Write($"{myList[i]} ");
        Console.WriteLine();
    }
    
    private static void MyLinkedList()
    {
        MyLinkedList myLinkedList = new MyLinkedList();
        for (int i = 0; i < 20; i++) 
        {
            if (i % 2 == 0) myLinkedList.AddFront(i + 1);
            else myLinkedList.AddBack(i + 1);
            
            Console.WriteLine(string.Join(" <-> ", myLinkedList.ToArray())); 
        }

        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine($"Elements at index #{i}: {myLinkedList[i]}");
        }
        
        for (int i = 0; i < 20; i++)
        {
            if (i % 2 == 0) Console.WriteLine($"Removed {myLinkedList.RemoveFront} from the front");
            else Console.WriteLine($"Removed {myLinkedList.RemoveBack()} from the back");

            Console.WriteLine(string.Join(" <-> ", myLinkedList.ToArray()));
        }
    }
}