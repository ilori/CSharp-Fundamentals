namespace p11_PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());


            var plants = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var totalDays = new int[n];

            var indexes = new Stack<int>();

            indexes.Push(0);

            for (var i = 1; i < plants.Length; i++)
            {
                var maxDays = default(int);

                while (indexes.Count > 0 && plants[indexes.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, totalDays[indexes.Pop()]);
                }

                if (indexes.Count > 0)
                {
                    totalDays[i] = maxDays + 1;
                }

                indexes.Push(i);
            }

            Console.WriteLine(totalDays.Max());
        }
    }
}