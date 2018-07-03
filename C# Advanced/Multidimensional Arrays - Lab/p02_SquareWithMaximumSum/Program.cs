namespace p02_SquareWithMaximumSum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var n = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();


            var matrix = new int[n[0], n[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            var biggestSum = default(int);
            var firstRowNumbers = string.Empty;
            var secondRowNumbers = string.Empty;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    var firstRowFirstNumber = matrix[i, j];
                    var firstRowSecondNumber = matrix[i, j + 1];

                    var secondRowFirstNumber = matrix[i + 1, j];
                    var secondRowSecondNumber = matrix[i + 1, j + 1];

                    var currentSum = firstRowFirstNumber + firstRowSecondNumber + secondRowFirstNumber +
                                     secondRowSecondNumber;

                    if (biggestSum < currentSum)
                    {
                        biggestSum = currentSum;
                        firstRowNumbers = $"{matrix[i, j]} {matrix[i, j + 1]}";
                        secondRowNumbers = $"{matrix[i + 1, j]} {matrix[i + 1, j + 1]}";
                    }
                }
            }

            Console.WriteLine(firstRowNumbers);
            Console.WriteLine(secondRowNumbers);
            Console.WriteLine(biggestSum);
        }
    }
}