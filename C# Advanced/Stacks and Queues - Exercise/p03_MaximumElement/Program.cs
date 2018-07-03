namespace p03_MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();

            var maxNumber = default(int);

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (input.Length > 1)
                {
                    var numberToPush = int.Parse(input[1]);
                    stack.Push(numberToPush);
                    if (numberToPush > maxNumber)
                    {
                        maxNumber = numberToPush;
                    }
                }
                else
                {
                    var stackCommand = int.Parse(input[0]);

                    switch (stackCommand)
                    {
                        case 2:
                            var numberToPop = stack.Pop();
                            if (stack.Count == 0)
                            {
                                maxNumber = 0;
                            }

                            if (maxNumber == numberToPop)
                            {
                                maxNumber = stack.Max();
                            }

                            break;

                        case 3:
                            Console.WriteLine(maxNumber);
                            break;
                    }
                }
            }
        }
    }
}