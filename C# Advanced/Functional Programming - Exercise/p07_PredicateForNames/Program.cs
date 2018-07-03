namespace p07_PredicateForNames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var lenght = int.Parse(Console.ReadLine());

            var names = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<List<string>, int, List<string>> filtered = (n, i) => n.Where(x => x.Length <= i).ToList();

            Action<List<string>> toPrint = n => Console.WriteLine(string.Join(Environment.NewLine, n));

            toPrint(filtered(names, lenght));
        }
    }
}