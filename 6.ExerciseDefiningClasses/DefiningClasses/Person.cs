namespace DefiningClasses;

public class Person
{
    private string name;
    private int age;

    public Person()
    :this(age: 1)
    {
    }

    public Person(int age)
    :this(name: "No name", age)
    {
    }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public int Age
    {
        get => this.age;
        set => this.age = value;
    }

    public override string ToString()
    {
        return $"{Name} - {Age}";
    }
}