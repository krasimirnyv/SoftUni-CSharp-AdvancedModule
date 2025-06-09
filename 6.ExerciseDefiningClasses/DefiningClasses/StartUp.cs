namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {
        Family family = new Family();
        
        int lines = int.Parse(Console.ReadLine());
        while (lines-- > 0)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = input[0];
            int age = int.Parse(input[1]);

            Person person = new Person(name, age);
            family.AddMember(person);
        }

        foreach (Person member in family.People
                     .Where(a => a.Age > 30)
                     .OrderBy(n => n.Name))
        {
            Console.WriteLine(member);
        }
    }
}
