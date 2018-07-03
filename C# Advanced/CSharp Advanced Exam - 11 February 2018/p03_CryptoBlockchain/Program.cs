namespace p03_CryptoBlockchain
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var final = string.Empty;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                final += input;
            }

            var regex = new Regex(@"{\D*([0-9]{3,})\D*}|\[\D*([0-9]{3,})\D*]");

            var mathes = regex.Matches(final);


            var nums = new List<int>();

            for (int i = 0; i < mathes.Count; i++)
            {
                var matchToString = mathes[i].Value;
                var first = mathes[i];

                var number = default(string);

                if (matchToString.StartsWith('{'))
                {
                    number = first.Groups[1].Value;
                }
                else if (matchToString.StartsWith('['))
                {
                    number = first.Groups[2].Value;
                }

                if (number.Length % 3 == 0)
                {
                    var start = 0;
                    var end = start + 3;
                    while (number.Length > 0)
                    {
                        nums.Add(int.Parse(number.Substring(start, end)) - matchToString.Length);
                        number = number.Remove(start, end);
                    }
                }
            }

            var finalOutput = string.Empty;
            foreach (var num in nums)
            {
                var a = Convert.ToChar(num);
                finalOutput += a;
            }

            Console.WriteLine(finalOutput);
        }
    }
}