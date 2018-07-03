namespace p06_TrafficJam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var carsPerGreenLight = int.Parse(Console.ReadLine());

            var input = Console.ReadLine();

            var results = new List<string>();

            while (input != "end")
            {
                results.Add(input);

                input = Console.ReadLine();
            }


            var greenCount = results.Count(x => x == "green");
            var allowedCarsInQueue = greenCount * carsPerGreenLight;

            var queue = new Queue<string>(results.Where(x => x != "green").Take(allowedCarsInQueue));
            var carsCount = queue.Count;

            while (queue.Count > 0)
            {
                var carName = queue.Dequeue();

                Console.WriteLine($"{carName} passed!");
            }

            Console.WriteLine($"{carsCount} cars passed the crossroads.");
        }
    }
}