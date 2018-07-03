namespace p03_CustomMinFunction
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


            Func<List<int>, int> minNumber = n =>
            {
                var smallest = int.MaxValue;


                foreach (var num in n)
                {
                    if (num < smallest)
                    {
                        smallest = num;
                    }
                }

                return smallest;
            };

            var smallestNumber = minNumber(input);

            Console.WriteLine(smallestNumber);
        }
    }
}