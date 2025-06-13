namespace ListyIterator;

public class Program
{
    public static void Main(string[] args)
    {
        string[] createData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        ListyIterator<string> iterator = new ListyIterator<string>(createData.Skip(1).ToList());

        string input = default;
        while ((input = Console.ReadLine()) != "END")
        {
            try
            {
                switch (input)
                {
                    case "Move":
                        Console.WriteLine(iterator.MoveNext());
                        break;
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                    case "Print":
                        Console.WriteLine(iterator.GetValue());
                        break;
                    case "PrintAll":
                        Console.WriteLine(string.Join(' ', iterator));
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}