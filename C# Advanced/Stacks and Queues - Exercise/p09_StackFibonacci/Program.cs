namespace p09_StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());


            var stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);

            for (int i = 1; i < n; i++)
            {
                var firstNumber = stack.Pop();
                var secondNumber = stack.Pop();
                var thirdNumber = firstNumber + secondNumber;

                stack.Push(secondNumber);
                stack.Push(firstNumber);
                stack.Push(thirdNumber);
            }

            Console.WriteLine(stack.Pop());
        }
    }
}