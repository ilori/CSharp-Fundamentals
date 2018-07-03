namespace p04_MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }

                if (input[i] == ')')
                {
                    var startIndex = stack.Pop();
                    var lenght = i - startIndex + 1;

                    Console.WriteLine(input.Substring(startIndex,lenght));
                }
            }
        }
    }
}