namespace p02_SumNumbers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();

            var totalSum = input.Sum();
            var count = input.Count;

            Console.WriteLine(count);
            Console.WriteLine(totalSum);
        }
    }
}