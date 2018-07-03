namespace p04_AddVAT
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => x + x * 0.20)
                .ToList();

            foreach (var num in input)
            {
                Console.WriteLine($"{num:f2}");
            }
        }
    }
}