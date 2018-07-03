using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static string name;
    private static int earSize;
    private static int decibels;
    private static double furSize;

    public static void Main()
    {
        var input = Console.ReadLine();

        var cats = new List<Cat>();

        while (input != "End")
        {
            var tokens = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToList();

            var type = tokens[0];


            Cat cat;
            switch (type)
            {
                case "Siamese":

                    name = tokens[1];
                    earSize = int.Parse(tokens[2]);
                    cat = new Siamese(name, earSize);
                    cats.Add(cat);
                    break;
                case "Cymric":
                    name = tokens[1];
                    furSize = double.Parse(tokens[2]);
                    cat = new Cymric(name, furSize);
                    cats.Add(cat);
                    break;
                case "StreetExtraordinaire":
                    name = tokens[1];
                    decibels = int.Parse(tokens[2]);
                    cat = new StreetExtraordinaire(name, decibels);
                    cats.Add(cat);
                    break;
            }

            input = Console.ReadLine();
        }

        var catName = Console.ReadLine();

        var catToPrint = cats.SingleOrDefault(x => x.Name == catName);

        if (catToPrint is Siamese)
        {
            Console.WriteLine($"{typeof(Siamese)} {catToPrint.Name} {catToPrint.EarSize}");
        }
        else if (catToPrint is Cymric)
        {
            Console.WriteLine($"{typeof(Cymric)} {catToPrint.Name} {catToPrint.FurSize:F2}");
        }
        else if (catToPrint is StreetExtraordinaire)
        {
            Console.WriteLine($"{typeof(StreetExtraordinaire)} {catToPrint.Name} {catToPrint.Decibels}");
        }
    }
}