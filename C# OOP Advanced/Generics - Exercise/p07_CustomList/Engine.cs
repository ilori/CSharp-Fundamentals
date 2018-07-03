namespace p07_CustomList
{
    using System;
    using System.Linq;

    public class Engine
    {
        private readonly CustomList<string> items;

        public Engine()
        {
            this.items = new CustomList<string>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] args = input.Split().ToArray();
                string command = args[0];

                switch (command)
                {
                    case "Add":
                        items.Add(args[1]);
                        break;
                    case "Remove":
                        items.Remove(int.Parse(args[1]));
                        break;
                    case "Contains":
                        Console.WriteLine(items.Contains(args[1]));
                        break;
                    case "Swap":
                        int index1 = int.Parse(args[1]);
                        int index2 = int.Parse(args[2]);
                        items.Swap(index1, index2);
                        break;
                    case "Greater":
                        Console.WriteLine(items.CountGreaterThan(args[1]));
                        break;
                    case "Max":
                        Console.WriteLine(items.Max());
                        break;
                    case "Min":
                        Console.WriteLine(items.Min());
                        break;
                    case "Sort":
                        items.Sort();
                        break;
                    case "Print":
                        Console.WriteLine(items.ToString());
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}