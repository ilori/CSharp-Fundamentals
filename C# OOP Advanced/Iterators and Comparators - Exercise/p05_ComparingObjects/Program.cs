namespace p05_ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            List<Person> people = new List<Person>();

            while (input != "END")
            {
                string[] tokens = input.Split().ToArray();

                string name = tokens[0];

                int age = int.Parse(tokens[1]);

                string town = tokens[2];

                people.Add(new Person(name, age, town));

                input = Console.ReadLine();
            }

            int index = int.Parse(Console.ReadLine());

            Person person = people[index - 1];

            int totalPeople = people.Count;

            people.RemoveAt(index - 1);

            int equals = default(int);

            foreach (var p in people)
            {
                int result = p.CompareTo(person);

                if (result == 0)
                {
                    equals++;
                }
            }


            int notEqual = totalPeople - (equals + 1);

            string output = equals == 0 ? "No matches" : $"{equals + 1} {notEqual} {totalPeople}";

            Console.WriteLine(output);
        }
    }
}