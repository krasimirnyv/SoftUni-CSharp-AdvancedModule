using System.Globalization;

namespace DateModifier;

public class DateModifier
{
    static void Main(string[] args)
    {
       string date1 = Console.ReadLine();
       string date2 = Console.ReadLine();

       DateModifier dateModifier = new DateModifier();
       int daysDifference = dateModifier.GetDateDifference(date1, date2);
       Console.WriteLine(daysDifference);
    }

    public int GetDateDifference(string date1, string date2)
    {
        DateTime firstDate = DateTime.ParseExact(date1, "yyyy MM dd", CultureInfo.InvariantCulture);
        DateTime secondDate = DateTime.ParseExact(date2, "yyyy MM dd", CultureInfo.InvariantCulture);

        TimeSpan difference = secondDate - firstDate;

        return Math.Abs(difference.Days);
    }
}