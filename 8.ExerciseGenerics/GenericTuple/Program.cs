namespace GenericTuple;

public class Program
{
    public static void Main(string[] args)
    {
        string[] first = Console.ReadLine().Split();
        MyThreeuple<string, string, string> t1 = new MyThreeuple<string, string, string>($"{first[0]} {first[1]}", first[2], string.Join(' ', first.Skip(3)));
        
        string[] second = Console.ReadLine().Split();
        MyThreeuple<string, int, bool> t2 = new MyThreeuple<string, int, bool>(second[0], int.Parse(second[1]), second[2] == "drunk");

        string[] third = Console.ReadLine().Split();
        MyThreeuple<string, double, string> t3 = new MyThreeuple<string, double, string>(third[0], double.Parse(third[1]), third[2]);

        Console.WriteLine(t1);
        Console.WriteLine(t2);
        Console.WriteLine(t3);
    }
}
