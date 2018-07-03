namespace p03_DecimalToBinaryConverter
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var result = Convert.ToString(Convert.ToInt32(input, 10), 2);

            Console.WriteLine(result);
        }
    }
}