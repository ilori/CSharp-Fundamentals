namespace p05_SequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var number = long.Parse(Console.ReadLine());

            var queue = new Queue<long>();

            var result = new List<long>();

            queue.Enqueue(number);
            result.Add(number);

            for (int i = 0; i < 50; i++)
            {
                var firstNumber = queue.Peek() + 1;
                var secondNumber = queue.Peek() * 2 + 1;
                var thirdNumber = queue.Peek() + 2;

                queue.Enqueue(firstNumber);
                queue.Enqueue(secondNumber);
                queue.Enqueue(thirdNumber);

                result.Add(firstNumber);
                result.Add(secondNumber);
                result.Add(thirdNumber);

                queue.Dequeue();
            }

            Console.WriteLine(string.Join(" ", result.Take(50)));
        }
    }
}