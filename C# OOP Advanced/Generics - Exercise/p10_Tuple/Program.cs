namespace p10_Tuple
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string[] fistInput = Console.ReadLine().Split().ToArray();
            string[] secondInput = Console.ReadLine().Split().ToArray();
            string[] thirdInput = Console.ReadLine().Split().ToArray();

            Tuple<string, string> firstResult = Tuple.Create(fistInput[0] + " " + fistInput[1], fistInput[2]);
            Tuple<string, int> secondResult = Tuple.Create(secondInput[0], int.Parse(secondInput[1]));
            Tuple<int, double> thirdResult = Tuple.Create(int.Parse(thirdInput[0]), double.Parse(thirdInput[1]));

            Console.WriteLine($"{firstResult.Item1} -> {firstResult.Item2}");
            Console.WriteLine($"{secondResult.Item1} -> {secondResult.Item2}");
            Console.WriteLine($"{thirdResult.Item1} -> {thirdResult.Item2}");
        }
    }
}