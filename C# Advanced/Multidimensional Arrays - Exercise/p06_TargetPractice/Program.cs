namespace p06_TargetPractice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static char[][] matrix;

        public static void Main()
        {
            matrix = CreateMatrix().ToArray();

            InitializeSnake();

            ShotInformation();

            PrintFinalResult();
        }

        private static void PrintFinalResult()
        {
            Console.WriteLine(string.Join(Environment.NewLine, matrix.Select(x => string.Join(string.Empty, x))));
        }

        private static void ShotInformation()
        {
            var tokens = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            var row = tokens[0];
            var col = tokens[1];
            var shotRadius = tokens[2];

            SnakeShooting(row, col, shotRadius);

            for (var i = 0; i < matrix[0].Length; i++)
            {
                for (var j = matrix.Length - 1; j > 0; j--)
                {
                    if (matrix[j][i] == ' ' && matrix[j - 1][i] != ' ')
                    {
                        CellFallsDown(j, i);
                    }
                }
            }
        }

        private static void CellFallsDown(int row, int col)
        {
            while (row < matrix.Length)
            {
                if (matrix[row][col] == ' ')
                {
                    var temp = matrix[row - 1][col];
                    matrix[row - 1][col] = matrix[row][col];
                    matrix[row][col] = temp;
                    row++;
                }
                else
                {
                    return;
                }
            }
        }

        private static void SnakeShooting(int row, int col, int shotRadius)
        {
            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix[i].Length; j++)
                {
                    if (IsCellDamaged(i, j, row, col, shotRadius))
                    {
                        matrix[i][j] = ' ';
                    }
                }
            }
        }

        private static bool IsCellDamaged(int i, int j, int row, int col, int shotRadius)
        {
            var distance = Math.Sqrt((i - row) * (i - row) + (j - col) * (j - col));

            return distance <= shotRadius;
        }

        private static void InitializeSnake()
        {
            var snake = Console.ReadLine();

            var snakeQueue = new Queue<char>(snake);

            var startingColumn = matrix[0].Length - 1;

            for (var i = matrix.Length - 1; i >= 0; i--)
            {
                if (startingColumn == matrix[i].Length - 1)
                {
                    for (var j = startingColumn; j >= 0; j--)
                    {
                        if (!snakeQueue.Any())
                        {
                            snakeQueue = new Queue<char>(snake);
                        }

                        matrix[i][j] = snakeQueue.Dequeue();


                        if (j == 0)
                        {
                            startingColumn = 0;
                            break;
                        }
                    }
                }
                else if (startingColumn == 0)
                {
                    for (var j = startingColumn; j < matrix[i].Length; j++)
                    {
                        if (!snakeQueue.Any())
                        {
                            snakeQueue = new Queue<char>(snake);
                        }

                        matrix[i][j] = snakeQueue.Dequeue();

                        if (j == matrix[i].Length - 1)
                        {
                            startingColumn = matrix[i].Length - 1;
                            break;
                        }
                    }
                }
            }
        }

        private static IEnumerable<char[]> CreateMatrix()
        {
            var matrixSize = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var rows = matrixSize[0];
            var cols = matrixSize[1];

            var matrixToReturn = new char[rows][].Select(x => x = new char[cols]).ToArray();

            return matrixToReturn;
        }
    }
}