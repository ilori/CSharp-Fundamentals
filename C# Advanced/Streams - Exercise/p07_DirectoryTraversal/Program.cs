namespace p07_DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var path = Console.ReadLine();
            var fileDictionary = ReadFromPath(path);
            WriteToTxt(fileDictionary);
        }

        private static void WriteToTxt(Dictionary<string, List<FileInfo>> fileDictionary)
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var fullFileName = desktop + "\\report.txt";

            using (var writer = new StreamWriter(fullFileName))
            {
                foreach (var kvp in fileDictionary)
                {
                    var extension = kvp.Key;

                    writer.WriteLine(extension);

                    var fileInfos = kvp.Value.OrderByDescending(x => x.Length);

                    foreach (var file in fileInfos)
                    {
                        var fileSize = (double) file.Length / 1024;

                        writer.WriteLine($"--{file.Name} - {fileSize:F3}kb");
                    }
                }
            }
        }

        private static Dictionary<string, List<FileInfo>> ReadFromPath(string path)
        {
            var fileDictionary = new Dictionary<string, List<FileInfo>>();

            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                var info = new FileInfo(file);

                var extension = info.Extension;

                if (!fileDictionary.ContainsKey(extension))
                {
                    fileDictionary[extension] = new List<FileInfo>();
                }

                fileDictionary[extension].Add(info);
            }

            fileDictionary = fileDictionary.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);
            return fileDictionary;
        }
    }
}