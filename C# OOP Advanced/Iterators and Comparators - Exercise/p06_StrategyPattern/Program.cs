namespace p06_StrategyPattern
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            SortedSet<Person> nameComperator = new SortedSet<Person>(new NameComperator());

            SortedSet<Person> ageComperator = new SortedSet<Person>(new AgeComperator());

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split().ToArray();

                string name = tokens[0];

                int age = int.Parse(tokens[1]);

                Person person = new Person(name, age);

                nameComperator.Add(person);
                ageComperator.Add(person);
            }

            foreach (var person in nameComperator)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }

            foreach (var person in ageComperator)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }
        }
    }
}