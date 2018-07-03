namespace p09_Crossfire
{
    using System;
    using System.Linq;

    public class Program
    {
        private static long[][] matrix;

        public static void Main()
        {
            matrix = CreateAndFillMatrix();

            PlayTheGame();

            PrintTheMatrix();
        }

        private static void PlayTheGame()
        {
            var input = Console.ReadLine().Trim();


            while (input != "Nuke it from orbit")
            {
                var tokens = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();

                var row = tokens[0];
                var col = tokens[1];
                var radius = tokens[2];

                BlastTheMatrix(row, col, radius);


                input = Console.ReadLine().Trim();
            }
        }

        private static void PrintTheMatrix()
        {
            for (var i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }

        private static void BlastTheMatrix(int row, int col, int radius)
        {
            for (var a = row - radius; a <= row + radius; a++)
            {
                if (IsInMatrix(a, col))
                {
                    matrix[a][col] = -1;
                }
            }

            for (var b = col - radius; b <= col + radius; b++)
            {
                if (IsInMatrix(row, b))
                {
                    matrix[row][b] = -1;
                }
            }

            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] < 0)
                    {
                        matrix[i] = matrix[i].Where(n => n > 0).ToArray();
                        break;
                    }
                }

                if (matrix[i].Length < 1)
                {
                    matrix = matrix.Take(i).Concat(matrix.Skip(i + 1)).ToArray();
                    i--;
                }
            }
        }

        private static bool IsInMatrix(int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length;
        }

        private static long[][] CreateAndFillMatrix()
        {
            var matrixSize = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var rows = matrixSize[0];
            var cols = matrixSize[1];

            var matrixToReturn = new long[rows][];

            var cellValue = 1;

            for (var i = 0; i < matrixToReturn.Length; i++)
            {
                matrixToReturn[i] = new long[cols];

                for (var j = 0; j < matrixToReturn[i].Length; j++)
                {
                    matrixToReturn[i][j] = cellValue;
                    cellValue++;
                }
            }

            return matrixToReturn;
        }
    }
}