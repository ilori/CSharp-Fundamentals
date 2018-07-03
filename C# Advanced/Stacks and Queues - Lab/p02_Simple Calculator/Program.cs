namespace p02_Simple_Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                var firstNumber = stack.Pop();
                var oprator = stack.Pop();
                var secondNumber = stack.Pop();
                var sum = default(int);
                switch (oprator)
                {
                    case "+":
                        sum = int.Parse(firstNumber) + int.Parse(secondNumber);
                        stack.Push(sum.ToString());
                        break;

                    case "-":

                        sum = int.Parse(firstNumber) - int.Parse(secondNumber);
                        stack.Push(sum.ToString());
                        break;

                    case "/":

                        sum = int.Parse(firstNumber) / int.Parse(secondNumber);
                        stack.Push(sum.ToString());
                        break;

                    case "*":

                        sum = int.Parse(firstNumber) * int.Parse(secondNumber);
                        stack.Push(sum.ToString());
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}