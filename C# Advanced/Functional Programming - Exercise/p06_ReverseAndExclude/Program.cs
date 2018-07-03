namespace p06_ReverseAndExclude
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();

            var number = int.Parse(Console.ReadLine());

            input = input.Where(x => x % number != 0).Reverse().ToList();

            Console.WriteLine(string.Join(" ",input));
        }
    }
}