namespace Logger.Models
{
    using System.IO;
    using Contracts;

    public class LogFile : ILogFile
    {
        private const string DefaultPath = "./data/";

        public LogFile(string fileName)
        {
            this.Path = DefaultPath + fileName;
            InitializeFile();
        }

        private void InitializeFile()
        {
            Directory.CreateDirectory(DefaultPath);
            File.AppendAllText(this.Path, "");
        }

        public string Path { get; }

        public int Size { get; private set; }

        public void Write(string errorLog)
        {
            File.AppendAllText(this.Path, errorLog);

            int sizeAdded = default(int);

            foreach (var symbol in errorLog)
            {
                sizeAdded += symbol;
            }

            this.Size += sizeAdded;
        }
    }
}