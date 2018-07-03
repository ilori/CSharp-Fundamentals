namespace p07_BalancedParenthesis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var stack = new Stack<char>();

            var areBalanced = true;

            foreach (var symbol in input)
            {
                switch (symbol)
                {
                    case '(':
                    case '[':
                    case '{':
                        stack.Push(symbol);
                        break;
                    case ')':
                        if (!stack.Any())
                        {
                            areBalanced = false;
                        }
                        else if (stack.Pop() != '(')
                        {
                            areBalanced = false;
                        }

                        break;
                    case ']':
                        if (!stack.Any())
                        {
                            areBalanced = false;
                        }
                        else if (stack.Pop() != '[')
                        {
                            areBalanced = false;
                        }

                        break;
                    case '}':
                        if (!stack.Any())
                        {
                            areBalanced = false;
                        }
                        else if (stack.Pop() != '{')
                        {
                            areBalanced = false;
                        }

                        break;
                }

            }
            Console.WriteLine(areBalanced ? "YES" : "NO");

        }
    }
}