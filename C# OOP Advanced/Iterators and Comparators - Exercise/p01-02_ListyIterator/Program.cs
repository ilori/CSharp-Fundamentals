namespace p01_ListyIterator
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static ListyIterator<string> list;

        public static void Main()
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            try
            {
                while (input != "END")
                {
                    string[] tokens = input.Split().ToArray();

                    string command = tokens[0];

                    tokens = tokens.Skip(1).ToArray();

                    switch (command)
                    {
                        case "Create":
                            list = Create(tokens);
                            break;
                        case "HasNext":
                            string hasNext = list.HasNext() ? "True" : "False";
                            sb.AppendLine(hasNext);
                            break;
                        case "Move":
                            string move = list.Move() ? "True" : "False";
                            sb.AppendLine(move);
                            break;
                        case "Print":
                            sb.AppendLine(list.Print());
                            break;
                        case "PrintAll":
                            sb.AppendLine(list.PrintAll());
                            break;
                    }

                    input = Console.ReadLine();
                }

                Console.WriteLine(sb.ToString().Trim());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static ListyIterator<string> Create(string[] tokens)
        {
            return new ListyIterator<string>(tokens);
        }
    }
}