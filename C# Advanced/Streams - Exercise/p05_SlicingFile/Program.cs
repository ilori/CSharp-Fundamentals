namespace p05_SlicingFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using DataInformation;

    public class Program
    {
        public static void Main()
        {
            Slice(Data.Path + "sliceMe.mp4", Data.Path, 5);

            var files = new List<string>()
            {
                "Part-0.mp4",
                "Part-1.mp4",
                "Part-2.mp4",
                "Part-3.mp4",
                "Part-4.mp4",
            };
            Assemble(files, Data.Path);
        }


        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            var extension = sourceFile.Substring(sourceFile.LastIndexOf('.'));


            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                var size = (long) Math.Ceiling((double) reader.Length / parts);


                for (var i = 0; i < parts; i++)
                {
                    var currentSize = 0;

                    destinationDirectory = destinationDirectory == string.Empty ? Data.Path : destinationDirectory;

                    var currendPart = destinationDirectory + $"Part-{i}{extension}";

                    using (var writer = new FileStream(currendPart, FileMode.Create))
                    {
                        var buffer = new byte[4096];

                        while (reader.Read(buffer, 0, buffer.Length) == 4096)
                        {
                            writer.Write(buffer, 0, buffer.Length);
                            currentSize += buffer.Length;
                            if (currentSize >= size)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            var extension = files[0].Substring(files[0].LastIndexOf('.'));

            destinationDirectory = destinationDirectory == string.Empty ? Data.Path : destinationDirectory;


            var assembledFile = $"{destinationDirectory}Assembled{extension}";

            using (var writer = new FileStream(assembledFile, FileMode.Create))
            {
                var buffer = new byte[4096];

                foreach (var file in files)
                {
                    using (var reader = new FileStream(Data.Path + file, FileMode.Open))
                    {
                        while (reader.Read(buffer, 0, buffer.Length) == buffer.Length)
                        {
                            writer.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
    }
}