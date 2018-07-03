namespace p02_DiagonalDifference
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var arraySize = int.Parse(Console.ReadLine());

            var matrix = new int[arraySize, arraySize];

            for (var row = 0; row < arraySize; row++)
            {
                var numbers = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (var col = 0; col < arraySize; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            var primaryDiagonalSum = default(int);
            var secondaryDiagonalSum = default(int);

            for (var row = 0; row < arraySize; row++)
            {
                for (var col = row; col <= row; col++)
                {
                    primaryDiagonalSum += matrix[row, col];
                }
            }

            for (var row = arraySize - 1; row >= 0; row--)
            {
                for (var col = arraySize - 1 - row; col < arraySize;)
                {
                    secondaryDiagonalSum += matrix[row, col];
                    break;
                }
            }

            var totalDifference = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);

            Console.WriteLine(totalDifference);
        }
    }
}