namespace p03_WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using DataInformation;

    public class Program
    {
        public static void Main()
        {
            var wordsToSearch = WordsToSearch(Data.Path + "words.txt").ToList();

            var textToSearchIn = TextToSearchIn(Data.Path + "text.txt").ToList();

            var result = WordCount(wordsToSearch, textToSearchIn);

            WriteResultToFile(result);
        }

        private static void WriteResultToFile(IOrderedEnumerable<KeyValuePair<string, int>> result)
        {
            var sb = new StringBuilder();

            foreach (var kvp in result)
            {
                var word = kvp.Key;
                var count = kvp.Value;

                sb.AppendLine($"{word} - {count}");
            }

            using (var writer = new StreamWriter(Data.Path + "result.txt"))
            {
                writer.WriteLine(sb);
            }
        }

        private static IOrderedEnumerable<KeyValuePair<string, int>> WordCount(List<string> wordsToSearch,
            List<string> textToSearchIn)
        {
            var result = new Dictionary<string, int>();

            foreach (var word in wordsToSearch)
            {
                var repeatCount = textToSearchIn.Count(x => x == word);

                if (!result.ContainsKey(word))
                {
                    result[word] = repeatCount;
                }
            }

            return result.OrderByDescending(x => x.Value);
        }

        private static IEnumerable<string> TextToSearchIn(string path)
        {
            var result = new List<string>();

            using (var reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    var a = line.ToLower().Split(new[] {" ", "-", ",", ".", "?", "!"},
                        StringSplitOptions.RemoveEmptyEntries);

                    result.AddRange(a);
                }
            }

            return result;
        }

        private static IEnumerable<string> WordsToSearch(string path)
        {
            var result = new List<string>();

            using (var reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    result.Add(line.Trim().ToLower());
                }
            }

            return result;
        }
    }
}