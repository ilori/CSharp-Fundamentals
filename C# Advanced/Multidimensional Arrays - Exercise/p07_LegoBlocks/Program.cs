namespace p07_LegoBlocks
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static int[][] firstJaggaedArray;
        private static int[][] secondJaggaedArray;
        private static int[][] finalJaggedArray;


        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            CreateJaggedArrays(n);

            Console.WriteLine(AreArraysMatcing() ? ArraysMatch() : ArraysDoesNotMatch());
        }


        private static void CreateJaggedArrays(int n)
        {
            firstJaggaedArray = new int[n][];
            secondJaggaedArray = new int[n][];

            for (int i = 0; i < n; i++)
            {
                firstJaggaedArray[i] = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            for (int i = 0; i < n; i++)
            {
                secondJaggaedArray[i] = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }
        }

        private static bool AreArraysMatcing()
        {
            var areArraysMatching = true;

            if (firstJaggaedArray.Length != secondJaggaedArray.Length)
            {
                return false;
            }

            for (int i = 0; i < firstJaggaedArray.Length - 1; i++)
            {
                if (firstJaggaedArray[i].Length + secondJaggaedArray[i].Length !=
                    firstJaggaedArray[i + 1].Length + secondJaggaedArray[i + 1].Length)
                {
                    areArraysMatching = false;
                    break;
                }
            }

            return areArraysMatching;
        }

        private static string ArraysMatch()
        {
            var tempArray = new int[secondJaggaedArray.Length][];

            var sb = new StringBuilder();

            for (var i = 0; i < tempArray.Length; i++)
            {
                var secondArrayNumbers = secondJaggaedArray[i].Reverse().ToArray();
                tempArray[i] = secondArrayNumbers;
            }

            secondJaggaedArray = tempArray;

            finalJaggedArray = new int[firstJaggaedArray.Length][];

            for (var i = 0; i < finalJaggedArray.Length; i++)
            {
                finalJaggedArray[i] = new int[firstJaggaedArray[i].Length + secondJaggaedArray[i].Length];
            }

            for (var i = 0; i < firstJaggaedArray.Length; i++)
            {
                for (var j = 0; j < firstJaggaedArray[i].Length; j++)
                {
                    var number = firstJaggaedArray[i][j];
                    finalJaggedArray[i][j] = number;
                }
            }


            for (var i = 0; i < secondJaggaedArray.Length; i++)
            {
                var colIndex = firstJaggaedArray[i].Length;

                for (var j = 0; j < finalJaggedArray[i].Length - firstJaggaedArray[i].Length; j++)
                {
                    var number = secondJaggaedArray[i][j];
                    finalJaggedArray[i][colIndex] = number;
                    colIndex++;
                }
            }

            foreach (var row in finalJaggedArray)
            {
                sb.AppendLine($"[{string.Join(", ", row)}]");
            }

            return sb.ToString();
        }

        private static string ArraysDoesNotMatch()
        {
            var arraysCellCount = default(int);

            var sb = new StringBuilder();

            for (int i = 0; i < firstJaggaedArray.Length; i++)
            {
                arraysCellCount += firstJaggaedArray[i].Length;
            }

            for (int i = 0; i < secondJaggaedArray.Length; i++)
            {
                arraysCellCount += secondJaggaedArray[i].Length;
            }


            sb.AppendLine($"The total number of cells is: {arraysCellCount}");

            return sb.ToString();
        }
    }
}