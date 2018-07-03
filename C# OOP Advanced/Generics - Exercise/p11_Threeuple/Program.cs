namespace p11_Threeuple
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

            Tuple<string, string, string> firstResult =
                Tuple.Create(fistInput[0] + " " + fistInput[1], fistInput[2], fistInput[3]);
            Tuple<string, int, string> secondResult = Tuple.Create(secondInput[0], int.Parse(secondInput[1]),
                secondInput[2] == "drunk" ? "True" : "False");
            Tuple<string, double, string> thirdResult =
                Tuple.Create(thirdInput[0],double.Parse(thirdInput[1]),thirdInput[2]);

            Console.WriteLine($"{firstResult.Item1} -> {firstResult.Item2} -> {firstResult.Item3}");
            Console.WriteLine($"{secondResult.Item1} -> {secondResult.Item2} -> {secondResult.Item3}");
            Console.WriteLine($"{thirdResult.Item1} -> {thirdResult.Item2:F1} -> {thirdResult.Item3}");
        }
    }
}