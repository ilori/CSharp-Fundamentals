namespace p01_SumMatrixElements
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var n = Console.ReadLine().Split(new[] {",", " "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            var matrix = new int[n[0], n[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine().Split(new[] {",", " "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            var totalSum = matrix.Cast<int>().Sum();


            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(totalSum);
        }
    }
}