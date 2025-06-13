namespace EqualityLogic;

class Program
{
    static void Main(string[] args)
    {
        SortedSet<Person> sortedPeople = new SortedSet<Person>();
        HashSet<Person> hashPeople = new HashSet<Person>();
        
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            Person person = new Person(name: data[0], age: int.Parse(data[1]));
            sortedPeople.Add(person);
            hashPeople.Add(person);
        }

        Console.WriteLine(sortedPeople.Count);
        Console.WriteLine(hashPeople.Count);
    }
}