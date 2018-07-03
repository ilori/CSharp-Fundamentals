namespace p03_DependencyInversion
{
    using System;
    using Contracts;
    using Models;

    public class Program
    {
        public static void Main()
        {
            ICalculationStrategy strategy = new AdditionStrategy();

            ICalculator calculator = new Calculator(strategy);

            string input = Console.ReadLine();

            while (input != "End")
            {
                var tokens = input.Split();

                if (tokens[0] == "mode")
                {
                    char @operator = char.Parse(tokens[1]);

                    strategy = null;

                    switch (@operator)
                    {
                        case '+':
                            strategy = new AdditionStrategy();
                            break;
                        case '-':
                            strategy = new SubtractionStrategy();
                            break;
                        case '*':
                            strategy = new MultiplyStrategy();
                            break;
                        case '/':
                            strategy = new DivisionStrategy();
                            break;
                    }

                    calculator.ChangeStrategy(strategy);
                }
                else
                {
                    int leftOperand = int.Parse(tokens[0]);

                    int rightOperand = int.Parse(tokens[1]);

                    int result = calculator.PerformCalculation(leftOperand, rightOperand);

                    Console.WriteLine(result);
                }

                input = Console.ReadLine();
            }
        }
    }
}