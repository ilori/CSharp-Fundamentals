using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var people = new List<Person>();

        for (var i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split().ToArray();

            people.Add(new Person(tokens[0], tokens[1], int.Parse(tokens[2]), decimal.Parse(tokens[3])));
        }

        var bonus = decimal.Parse(Console.ReadLine());
        people.ForEach(x => x.IncreaseSalary(bonus));
        people.ForEach(Console.WriteLine);
    }
}