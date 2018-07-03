namespace Logger.Factories
{
    using System;
    using Contracts;
    using Enums;
    using Models;

    public class AppenderFactory
    {
        private const string DefaultFileName = "logFile{0}.txt";

        private readonly LayoutFactory layoutFactory;

        private int fileNumber;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
        }

        public IAppender CreateAppender(string appenderType, string error, string layoutType)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            ErrorLevel errorLevel = this.ErrorLevelParser(error);

            switch (appenderType)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout, errorLevel);
                case "FileAppender":
                    ILogFile logFile = new LogFile(string.Format(DefaultFileName, this.fileNumber));
                    return new FileAppender(layout, errorLevel, logFile);
                default:
                    throw new ArgumentException("Invalid Appender Type");
            }
        }

        private ErrorLevel ErrorLevelParser(string error)
        {
            bool isErrorValid = Enum.TryParse(error, out ErrorLevel result);

            if (isErrorValid)
            {
                return result;
            }

            throw new ArgumentException($"Invalid Error Level");
        }
    }
}