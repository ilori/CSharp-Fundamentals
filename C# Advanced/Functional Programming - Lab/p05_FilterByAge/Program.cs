namespace p05_FilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var people = new Dictionary<string, int>(n);

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var name = input[0];

                var age = int.Parse(input[1]);

                if (!people.ContainsKey(name))
                {
                    people[name] = age;
                }
            }

            var condition = Console.ReadLine();

            var ageCondition = int.Parse(Console.ReadLine());

            var format = Console.ReadLine();


            var filter = GetFilter(condition, ageCondition);

            var print = PrintResult(format);

            foreach (var person in people)
            {
                if (filter(person.Value))
                {
                    print(person);
                }
            }
        }


        private static Func<int, bool> GetFilter(string condition, int age)
        {
            if (condition == "younger")
            {
                return x => x < age;
            }

            return x => x >= age;
        }

        private static Action<KeyValuePair<string, int>> PrintResult(string format)
        {
            switch (format)
            {
                case "name":
                    return x => Console.WriteLine(x.Key);
                case "age":
                    return x => Console.WriteLine(x.Value);
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
                default: throw new ArgumentException();
            }
        }
    }
}