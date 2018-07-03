namespace p01_Reverse_Strings
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var stack = new Stack<char>(input.ToCharArray());

            var result = string.Empty;

            foreach (var c in stack)
            {
                result += c;
            }

            Console.WriteLine(result);
        }
    }
}