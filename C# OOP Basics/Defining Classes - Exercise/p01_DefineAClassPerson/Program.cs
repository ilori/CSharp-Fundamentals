using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var people = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(" ").ToArray();

            var name = input[0];
            var age = int.Parse(input[1]);
            people.Add(new Person()
            {
                Age = age,
                Name = name
            });
        }

        foreach (var person in people.Where(x=>x.Age > 30).OrderBy(x=>x.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}