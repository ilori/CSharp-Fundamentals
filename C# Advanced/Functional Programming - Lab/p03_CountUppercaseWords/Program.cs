namespace p03_CountUppercaseWords
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => char.IsUpper(x[0])).ToList();


            foreach (var word in input)
            {
                Console.WriteLine(word);
            }
        }
    }
}