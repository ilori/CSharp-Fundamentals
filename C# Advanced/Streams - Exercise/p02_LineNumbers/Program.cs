namespace p02_LineNumbers
{
    using System.IO;
    using System.Text;
    using DataInformation;

    public class Program
    {
        public static void Main()
        {
            var text = ReadAllText(Data.Path + "text.txt");

            WriteAllText(text);
        }

        private static void WriteAllText(string text)
        {
            using (var writer = new StreamWriter(Data.Path + "output.txt"))
            {
                writer.WriteLine(text, 0, text.Length);
            }
        }

        private static string ReadAllText(string path)
        {
            var sb = new StringBuilder();

            using (var reader = new StreamReader(path))
            {
                string line;
                var lineNumber = 1;
                while ((line = reader.ReadLine()) != null)
                {
                    sb.AppendLine($"Line {lineNumber}: {line}");
                    lineNumber++;
                }
            }

            return sb.ToString();
        }
    }
}