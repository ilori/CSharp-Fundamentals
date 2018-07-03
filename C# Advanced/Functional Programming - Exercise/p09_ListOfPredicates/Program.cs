namespace p09_ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var range = int.Parse(Console.ReadLine());
            var divisors = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var predicates = divisors.Select(d => (Func<int, bool>) (n => n % d == 0)).ToArray();

            var result = new List<int>();

            for (var i = 1; i <= range; i++)
            {
                var canNumberBeDevided = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(i))
                    {
                        canNumberBeDevided = false;
                        break;
                    }
                }

                if (canNumberBeDevided)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}