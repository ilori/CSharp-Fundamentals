namespace p05_RubiksMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static int[][] matrix;

        public static void Main()
        {
            matrix = CreateMatrix().ToArray();

            CommandParser();

            var result = RearangedMatrix();

            Console.WriteLine(result);
        }

        private static string RearangedMatrix()
        {
            var sb = new StringBuilder();

            var initialValue = 1;

            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] != initialValue)
                    {
                        sb.AppendLine(PositionSwap(i, j, initialValue));
                    }
                    else
                    {
                        sb.AppendLine("No swap required");
                    }

                    initialValue++;
                }
            }

            return sb.ToString();
        }

        private static string PositionSwap(int row, int col, int initialValue)
        {
            for (var i = row; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == initialValue)
                    {
                        var tempNumber = matrix[i][j];
                        matrix[i][j] = matrix[row][col];
                        matrix[row][col] = tempNumber;

                        return $"Swap ({row}, {col}) with ({i}, {j})";
                    }
                }
            }

            return string.Empty;
        }

        private static void CommandParser()
        {
            var n = int.Parse(Console.ReadLine());


            for (var i = 0; i < n; i++)
            {
                ParseCommand();
            }
        }

        private static void ParseCommand()
        {
            var tokens = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var index = int.Parse(tokens[0]);
            var command = tokens[1];
            var rotations = int.Parse(tokens[2]);

            if (command == "up")
                RotateColumns(index, rotations % matrix.Length);
            else if (command == "down")
            {
                RotateColumns(index, matrix.Length - (rotations % matrix.Length));
            }
            else if (command == "left")
            {
                RotateRows(index, rotations % matrix[index].Length);
            }
            else if (command == "right")
            {
                RotateRows(index, matrix[index].Length - (rotations % matrix[index].Length));
            }
        }

        private static void RotateRows(int index, int rotations)
        {
            var replacementValues = new Queue<int>(matrix[index].Length);

            for (var j = 0; j < matrix[index].Length; j++)
            {
                if (rotations == matrix[index].Length)
                {
                    rotations = 0;
                }

                replacementValues.Enqueue(matrix[index][rotations]);
                rotations++;
            }

            matrix[index] = replacementValues.ToArray();
        }

        private static void RotateColumns(int index, int rotations)
        {
            var replacementValues = new Queue<int>(matrix.Length);

            while (replacementValues.Count < matrix.Length)
            {
                if (rotations == matrix.Length)
                {
                    rotations = 0;
                }

                replacementValues.Enqueue(matrix[rotations][index]);
                rotations++;
            }

            foreach (var row in matrix)
            {
                row[index] = replacementValues.Dequeue();
            }
        }

        private static IEnumerable<int[]> CreateMatrix()
        {
            var matrixSize = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var matrixToReturn = new int[matrixSize[0]][].Select(x => x = new int[matrixSize[1]]).ToArray();

            var numbersInMatrix = 1;

            foreach (var cell in matrixToReturn)
            {
                for (var j = 0; j < cell.Length; j++)
                {
                    cell[j] = numbersInMatrix;
                    numbersInMatrix++;
                }
            }

            return matrixToReturn;
        }
    }
}