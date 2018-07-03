namespace p01_OddLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using DataInformation;

    public class Program
    {
        public static void Main()
        {
            var text = GetAllText(Data.Path + "text.txt");

            ReadOddLines(text);
        }

        private static void ReadOddLines(List<string> text)
        {
            for (var i = 0; i < text.Count; i++)
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine(text[i]);
                }
            }
        }

        private static List<string> GetAllText(string path)
        {
            var text = new List<string>();


            using (var stream = new StreamReader(path))
            {
                string line;

                while ((line = stream.ReadLine()) != null)
                {
                    text.Add(line);
                }
            }

            return text;
        }
    }
}