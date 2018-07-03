using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static readonly List<IBuyer> Buyers = new List<IBuyer>();

    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        for (var i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split().ToArray();

            var buyer = InputReader.Read(input);

            if (!Buyers.Any(x => x.Name == buyer.Name))
            {
                Buyers.Add(buyer);
            }
        }

        var name = Console.ReadLine();

        while (name != "End")
        {
            var buyer = Buyers.SingleOrDefault(x => x.Name == name);

            buyer?.BuyFood();

            name = Console.ReadLine();
        }

        PrintTotalFood();
    }

    private static void PrintTotalFood()
    {
        Console.WriteLine(Buyers.Sum(x => x.Food));
    }
}