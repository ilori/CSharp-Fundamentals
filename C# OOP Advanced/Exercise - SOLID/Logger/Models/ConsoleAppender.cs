namespace Logger.Models
{
    using System;
    using Contracts;
    using Enums;

    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ErrorLevel errorLevel)
        {
            this.Layout = layout;
            this.ErrorLevel = errorLevel;
            this.MessagesAppended = 0;
        }

        public ILayout Layout { get; }

        public ErrorLevel ErrorLevel { get; }

        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            Console.WriteLine(this.Layout.FormatError(error));
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            return
                $"Appender type: {this.GetType().Name}, Layout Type: {this.Layout.GetType().Name}, Report level: {this.ErrorLevel.ToString()}, Messages appended: {this.MessagesAppended}";
        }
    }
}