namespace p08_FullDirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var filePaths = Directory.GetFiles(@"../../", "*.*", SearchOption.AllDirectories);

            var files = filePaths.Select(path => new FileInfo(path)).ToList();

            var sorted =
                files.OrderBy(file => file.Length).GroupBy(file => file.Extension)
                    .OrderByDescending(group => group.Count()).ThenBy(group => group.Key);

            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (var writer = new StreamWriter(desktop + "/report.txt"))
            {
                foreach (var group in sorted)
                {
                    writer.WriteLine(group.Key);

                    foreach (var x in group)
                    {
                        var size = x.Length / 1024.0;
                        writer.WriteLine($"--{x.Name} - {size:F3}kb");
                    }
                }
                
            }
        }
    }
}