namespace p02_KnightsOfHonor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => string.Concat($"Sir {x}"))
                .ToList();

            Action<List<string>> printNames = p => Console.WriteLine(string.Join(Environment.NewLine, p));

            printNames(input);

        }
    }
}