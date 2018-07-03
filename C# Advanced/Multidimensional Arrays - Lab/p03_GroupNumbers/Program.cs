namespace p03_GroupNumbers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var sizeOfArray = new int[3];

            foreach (var number in numbers)
            {
                sizeOfArray[Math.Abs(number % 3)]++;
            }

            var jaggedArray = new int[3][];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = new int [sizeOfArray[i]];
            }

            var zeroRemainder = string.Empty;
            var oneRemainder = string.Empty;
            var twoRemainder = string.Empty;

            foreach (var number in numbers)
            {
                if (Math.Abs(number % 3) == 0)
                {
                    zeroRemainder += number + ",";
                }
                else if (Math.Abs(number % 3) == 1)
                {
                    oneRemainder += number + ",";
                }
                else if (Math.Abs(number % 3) == 2)
                {
                    twoRemainder += number + ",";
                }
            }

            jaggedArray[0] = zeroRemainder.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            jaggedArray[1] = oneRemainder.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            jaggedArray[2] = twoRemainder.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();


            Console.WriteLine(string.Join(" ", jaggedArray[0]));
            Console.WriteLine(string.Join(" ", jaggedArray[1]));
            Console.WriteLine(string.Join(" ", jaggedArray[2]));
        }
    }
}