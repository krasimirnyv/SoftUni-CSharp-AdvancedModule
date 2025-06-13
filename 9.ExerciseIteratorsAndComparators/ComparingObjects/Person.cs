namespace ComparingObjects;

public class Person : IComparable<Person>
{
    public Person(string name, int age, string town)
    {
        Name = name;
        Age = age;
        Town = town;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Town { get; set; }

    public int CompareTo(Person? other)
    {
        if (other is null) return -1;
        
        int nameCompareResult = Comparer<string>.Default.Compare(this.Name, other.Name);
        if (nameCompareResult != 0) return nameCompareResult;

        int ageCompareResult = Comparer<int>.Default.Compare(this.Age, other.Age);
        if (ageCompareResult != 0) return ageCompareResult;

        return Comparer<string>.Default.Compare(this.Town, other.Town);
    }
}