namespace p06_ZippingSlicedFile
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using DataInformation;

    public class Program
    {
        public static void Main()
        {
            Slice(Data.Path + "sliceMe.mp4", Data.Path, 5);

            Zip(Data.Path + "sliceMe.mp4", Data.Path, 5);
        }

        private static void Zip(string sourceFile, string destinationDirectory, int parts)
        {
            var extension = sourceFile.Substring(sourceFile.LastIndexOf('.'));


            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                var size = (long) Math.Ceiling((double) reader.Length / parts);


                for (var i = 0; i < parts; i++)
                {
                    var currentSize = 0;

                    destinationDirectory = destinationDirectory == string.Empty ? Data.Path : destinationDirectory;

                    var currendPart = destinationDirectory + $"Part-{i}{extension}.gz";


                    using (var writer = new GZipStream(new FileStream(currendPart, FileMode.Create),
                        CompressionLevel.Optimal))
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
    }
}