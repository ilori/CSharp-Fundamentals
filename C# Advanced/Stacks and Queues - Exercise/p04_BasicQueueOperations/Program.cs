namespace p04_BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var queueInformation = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();


            var queueInput = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var queueSize = queueInformation[0];

            var dequeueCount = queueInformation[1];

            var numberToSearch = queueInformation[2];

            var queue = new Queue<int>(queueInput.Take(queueSize));

            for (int i = 0; i < dequeueCount; i++)
            {
                queue.Dequeue();
            }

            if (!queue.Any())
            {
                Console.WriteLine("0");
                return;
            }

            if (queue.Any(x => x == numberToSearch))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}