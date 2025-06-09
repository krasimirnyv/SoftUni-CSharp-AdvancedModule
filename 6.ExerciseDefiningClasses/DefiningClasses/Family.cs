namespace DefiningClasses;

public class Family
{
    private List<Person> people;

    public List<Person> People
    {
        get => this.people;
        set => this.people = value;
    }

    public Family()
    {
        this.People = new List<Person>();
    }

    public void AddMember(Person member)
    {
        this.People.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.People.OrderByDescending(p => p.Age).First();
    } 
}