namespace p05_AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();

            var command = Console.ReadLine();

            Func<List<int>, List<int>> add = n => n.Select(x => x += 1).ToList();
            Func<List<int>, List<int>> subtract = n => n.Select(x => x -= 1).ToList();
            Func<List<int>, List<int>> multiply = n => n.Select(x => x *= 2).ToList();

            Action<List<int>> print = n => Console.WriteLine(string.Join(" ", n));

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        input = add(input);
                        break;
                    case "subtract":
                        input = subtract(input);
                        break;
                    case "multiply":
                        input = multiply(input);
                        break;
                    case "print":
                        print(input);
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}