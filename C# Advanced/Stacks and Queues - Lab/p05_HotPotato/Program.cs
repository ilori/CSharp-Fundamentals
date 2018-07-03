namespace p05_HotPotato
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split(' ');

            var limit = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(names);

            while (queue.Count > 1)
            {
                for (int i = 1; i < limit; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}