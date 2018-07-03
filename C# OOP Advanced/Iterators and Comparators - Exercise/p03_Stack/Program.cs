namespace p03_Stack
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            MyStack<string> stack = new MyStack<string>();

            StringBuilder sb = new StringBuilder();

            while (input != "END")
            {
                string[] tokens = input.Split(new[] {" ", ","}, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = tokens[0];

                tokens = tokens.Skip(1).ToArray();

                try
                {
                    switch (command)
                    {
                        case "Push":
                            stack.Push(tokens);
                            break;
                        case "Pop":
                            stack.Pop();
                            break;
                    }
                }
                catch (Exception e)
                {
                    sb.AppendLine(e.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var item in stack)
            {
                sb.AppendLine(item);
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}