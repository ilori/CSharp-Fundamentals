namespace p04_Froggy
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] items = Console.ReadLine().Split(new[] {" ", ","}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Lake<int> lake = new Lake<int>(items);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}