namespace EqualityLogic;

public class Person : IEquatable<Person>, IComparable<Person>
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; }
    public int Age { get; }
    
    public int CompareTo(Person? other)
    {
        if (other is null) return -1;

        int nameCompareResult = Comparer<string>.Default.Compare(this.Name, other.Name);
        if (nameCompareResult != 0) return nameCompareResult;
        
        return Comparer<int>.Default.Compare(this.Age, other.Age);
    }
    
    public bool Equals(Person? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return CompareTo(other) == 0;
    }

    public override bool Equals(object? obj)
        => obj is Person person && Equals(person);
    
    public override int GetHashCode()
        => HashCode.Combine(this.Name, this.Age);
}
