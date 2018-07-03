namespace p04_FindEvensOrOdds
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();

            var start = input[0];
            var end = input[1];

            var numbers = Enumerable.Range(start, end - start + 1).ToList();

            var command = Console.ReadLine();

            Console.WriteLine(string.Join(" ",
                command == "odd" ? numbers.Where(x => x % 2 != 0) : numbers.Where(x => x % 2 == 0)));
        }
    }
}