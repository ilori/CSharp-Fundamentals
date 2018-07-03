namespace p01_MatrixOfPalindromes
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var rows = input[0];
            var columns = input[1];

            var matrix = new string[rows, columns];

            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] += alphabet[row];
                    matrix[row, col] += alphabet[row + col];
                    matrix[row, col] += alphabet[row];
                }
            }

            var finalResult = string.Empty;


            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    finalResult += $"{matrix[row, col]} ";
                }

                finalResult += Environment.NewLine;
            }

            Console.WriteLine(finalResult.Trim());
        }
    }
}