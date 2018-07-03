namespace p04_MaximalSum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var matrixRows = matrixSize[0];
            var matrixCols = matrixSize[1];

            var matrix = new int[matrixRows, matrixCols];

            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            var biggestSum = default(int);

            var rowIndex = default(int);
            var colIndex = default(int);

            for (var row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (var col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    var firstRowFirstNumber = matrix[row, col];
                    var firstRowSecondNumber = matrix[row, col + 1];
                    var firstRowThirdNumber = matrix[row, col + 2];

                    var secondRowFirstNumber = matrix[row + 1, col];
                    var secondRowSecondNumber = matrix[row + 1, col + 1];
                    var secondRowThirdNumber = matrix[row + 1, col + 2];

                    var thirdRowFirstNumber = matrix[row + 2, col];
                    var thirdRowSecondNumber = matrix[row + 2, col + 1];
                    var thirdRowThirdNumber = matrix[row + 2, col + 2];

                    var currentBiggestSum = firstRowFirstNumber + firstRowSecondNumber + firstRowThirdNumber +
                                            secondRowFirstNumber + secondRowSecondNumber + secondRowThirdNumber +
                                            thirdRowFirstNumber + thirdRowSecondNumber + thirdRowThirdNumber;

                    if (currentBiggestSum > biggestSum)
                    {
                        biggestSum = currentBiggestSum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {biggestSum}");

            Console.WriteLine(
                $"{matrix[rowIndex, colIndex]} {matrix[rowIndex, colIndex + 1]} {matrix[rowIndex, colIndex + 2]}");

            Console.WriteLine(
                $"{matrix[rowIndex + 1, colIndex]} {matrix[rowIndex + 1, colIndex + 1]} {matrix[rowIndex + 1, colIndex + 2]}");

            Console.WriteLine(
                $"{matrix[rowIndex + 2, colIndex]} {matrix[rowIndex + 2, colIndex + 1]} {matrix[rowIndex + 2, colIndex + 2]}");
        }
    }
}