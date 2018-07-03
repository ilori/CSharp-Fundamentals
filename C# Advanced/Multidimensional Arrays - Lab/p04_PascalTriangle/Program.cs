namespace p04_PascalTriangle
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var jaggedArray = new long[n][];


            for (var i = 0; i < n; i++)
            {
                jaggedArray[i] = new long[i + 1];
            }

            jaggedArray[0][0] = 1;

            for (var row = 0; row < n - 1; row++)
            {
                for (var col = 0; col <= row; col++)
                {
                    jaggedArray[row + 1][col] += jaggedArray[row][col];
                    jaggedArray[row + 1][col + 1] += jaggedArray[row][col];
                }
            }

            var finalResult = string.Empty;

            foreach (var j in jaggedArray)
            {
                finalResult += string.Join($" ", j);
                finalResult += Environment.NewLine;
            }

            Console.WriteLine(finalResult.Trim());
        }
    }
}