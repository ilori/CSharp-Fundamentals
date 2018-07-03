namespace p02_BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var stackInformation = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();


            var stackInput = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var stackSize = stackInformation[0];

            var popCount = stackInformation[1];

            var numberToSearch = stackInformation[2];

            var stack = new Stack<int>(stackInput.Take(stackSize));

            for (int i = 0; i < popCount; i++)
            {
                stack.Pop();
            }

            if (!stack.Any())
            {
                Console.WriteLine("0");
                return;
            }

            if (stack.Any(x => x == numberToSearch))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}