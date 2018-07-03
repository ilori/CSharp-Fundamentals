namespace p04_CopyBinaryFile
{
    using System.IO;
    using DataInformation;

    public class Program
    {
        public static void Main()
        {
            using (var reader = new FileStream(Data.Path + "copyMe.png", FileMode.Open))
            {
                using (var writer = new FileStream(Data.Path + "copy.png", FileMode.Create))
                {
                    var buffer = new byte[1024];

                    int bytesRead;

                    while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        writer.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}