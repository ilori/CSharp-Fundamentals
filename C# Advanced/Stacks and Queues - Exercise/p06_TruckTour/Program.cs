namespace p06_TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var pumps = new Queue<Tuple<int, int, int>>();

            for (var i = 0; i < n; i++)
            {
                var information = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var gas = information[0];
                var distance = information[1];

                pumps.Enqueue(new Tuple<int, int, int>(gas, distance, i));
            }

            while (true)
            {
                var totalGas = 0;
                var startingPump = pumps.Dequeue();

                var startingIndex = startingPump.Item3;
                totalGas += startingPump.Item1;
                totalGas -= startingPump.Item2;

                pumps.Enqueue(startingPump);

                while (totalGas >= 0)
                {
                    startingPump = pumps.Dequeue();
                    totalGas += startingPump.Item1;
                    totalGas -= startingPump.Item2;
                    var currentIndex = startingPump.Item3;

                    if (currentIndex == startingIndex)
                    {
                        if (totalGas >= 0)
                        {
                            Console.WriteLine(startingIndex);
                            return;
                        }

                        return;
                    }

                    pumps.Enqueue(startingPump);
                }
            }
        }
    }
}