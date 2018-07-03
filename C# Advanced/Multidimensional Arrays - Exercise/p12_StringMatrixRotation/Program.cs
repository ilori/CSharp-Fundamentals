namespace p12_StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static char[][] matrix;

        public static void Main()
        {
            var rotations = GetDegreesInformation();
            CommandParser();

            for (var i = 0; i < rotations; i++)
            {
                matrix = RotateTheMatrix();
            }

            PrintTheMatrix();
        }

        private static char[][] RotateTheMatrix()
        {
            var finalResult = new char[matrix.Max(w => w.Length)][];

            for (var row = 0; row < finalResult.Length; row++)
            {
                finalResult[row] = new char[matrix.Length];

                for (var col = 0; col < finalResult[row].Length; col++)
                {
                    finalResult[row][col] = matrix[matrix.Length - 1 - col][row];
                }
            }

            return finalResult;
        }

        private static void PrintTheMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }


        private static void CommandParser()
        {
            var list = new List<string>();

            var word = Console.ReadLine();

            while (word != "END")
            {
                list.Add(word);
                word = Console.ReadLine();
            }

            var rows = list.Count;
            var cols = list.Max(x => x.Length);

            matrix = InitializeMatrix(rows, cols, list);
        }

        private static char[][] InitializeMatrix(int rows, int cols, List<string> list)
        {
            var matrixToReturn = new char[rows][];

            for (var i = 0; i < list.Count; i++)
            {
                matrixToReturn[i] = list[i].PadRight(cols).ToCharArray();
            }

            return matrixToReturn;
        }

        private static int GetDegreesInformation()
        {
            var input = Console.ReadLine().Split(new[] {"(", ")"}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var degrees = int.Parse(input[1]);

            var rotationCount = degrees / 90 % 4;

            return rotationCount;
        }
    }
}