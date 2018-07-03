using System;

public class Program
{
    public static void Main()
    {
        Scale<double> scale = new Scale<double>(6.6, 6.5);

        Console.WriteLine(scale.GetHeavier());
    }
}