namespace p08_CustomComparator
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();

            var evenNums = numbers.Where(x => x % 2 == 0).ToList();
            evenNums.Sort();

            var oddNums = numbers.Where(x => x % 2 != 0).ToList();
            oddNums.Sort();

            evenNums.AddRange(oddNums);

            Console.WriteLine(string.Join(" ", evenNums));
        }
    }
}