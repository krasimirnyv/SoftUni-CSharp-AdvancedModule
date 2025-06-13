namespace ComparingObjects;

public class Program
{
    public static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        
        string input = default;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            Person currentPerson = new Person(data[0], int.Parse(data[1]), data[2]);
            people.Add(currentPerson);
        }
        
        int position = int.Parse(Console.ReadLine());
        Person targetPerson = people[position - 1];

        int matches = 0;
        foreach (Person person in people)
        {
            if (targetPerson.CompareTo(person) == 0)
                matches++;
        }

        Console.WriteLine(matches == 1 ? "No matches" : $"{matches} {people.Count - matches} {people.Count}");
    }
}
