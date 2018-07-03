namespace Logger.Models
{
    using Contracts;
    using Enums;

    public class FileAppender : IAppender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
        {
            this.Layout = layout;
            this.ErrorLevel = errorLevel;
            this.logFile = logFile;
        }

        public ILayout Layout { get; }

        public ErrorLevel ErrorLevel { get; }

        private int messagesAppended;

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);

            this.logFile.Write(formattedError);

            this.messagesAppended++;
        }

        public override string ToString()
        {
            return
                $"Appender type: {this.GetType().Name}, Layout Type: {this.Layout.GetType().Name}, Report level: {this.ErrorLevel.ToString()}, Messages appended: {this.messagesAppended}, File size: {this.logFile.Size}";
        }
    }
}