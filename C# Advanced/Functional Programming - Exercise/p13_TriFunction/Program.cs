namespace p13_TriFunction
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            bool IsItLonger(string str, int num) => str.ToCharArray().Select(c => (int) c).Sum() >= num;

            string BiggestNameSum(string[] arr, int num, Func<string, int, bool> func) =>
                arr.FirstOrDefault(s => func(s, num));

            var result = BiggestNameSum(names, n, IsItLonger);
            Console.WriteLine(result);
        }
    }
}