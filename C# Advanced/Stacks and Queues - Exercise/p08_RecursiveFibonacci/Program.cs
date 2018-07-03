namespace p08_RecursiveFibonacci
{
    using System;

    public class Program
    {
        private static long[] fibonacciNumbers;

        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            fibonacciNumbers = new long[n];
            fibonacciNumbers[0] = 1;
            if (n > 1)
            {
                fibonacciNumbers[1] = 1;
            }

            Console.WriteLine(GetFibonacciNumbers(n - 1));
        }

        private static long GetFibonacciNumbers(int n)
        {
            if (fibonacciNumbers[n] == 0)
            {
                fibonacciNumbers[n] = GetFibonacciNumbers(n - 1) + GetFibonacciNumbers(n - 2);
            }
            return fibonacciNumbers[n];
        }
    }
}