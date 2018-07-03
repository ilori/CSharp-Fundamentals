namespace p03_SquaresInMatrix
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var matrixRows = matrixSize[0];
            var matrixCols = matrixSize[1];

            var matrix = new char[matrixRows, matrixCols];

            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            var characterRepeatCount = default(int);

            for (var row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (var col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var firstRowFirstChar = matrix[row, col];
                    var firstRowSecondChar = matrix[row, col + 1];
                    var secondRowFirstChar = matrix[row + 1, col];
                    var secondRowSecondChar = matrix[row + 1, col + 1];

                    var areCharactersEqual = firstRowFirstChar == firstRowSecondChar &&
                                             firstRowFirstChar == secondRowFirstChar &&
                                             firstRowFirstChar == secondRowSecondChar;

                    if (areCharactersEqual)
                    {
                        characterRepeatCount++;
                    }
                }
            }

            Console.WriteLine(characterRepeatCount);
        }
    }
}