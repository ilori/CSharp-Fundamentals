namespace p07_EqualityLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            SortedSet<Person> sortedSet = new SortedSet<Person>();

            HashSet<Person> hashSet = new HashSet<Person>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                string name = input[0];

                var age = int.Parse(input[1]);

                Person person = new Person(name, age);

                sortedSet.Add(person);
                hashSet.Add(person);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}