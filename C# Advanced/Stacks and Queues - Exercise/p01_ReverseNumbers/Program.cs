namespace p01_ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var userInput = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var stack = new Stack<int>(userInput);

            Console.WriteLine(string.Join(" ", stack));
        }
    }
}