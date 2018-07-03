using System;

public class Program
{
    public static void Main()
    {
        var firstDate = Console.ReadLine();
        var secondDate = Console.ReadLine();

        var difference = DateModifier.GetDifference(firstDate, secondDate);

        Console.WriteLine(difference);
    }
}