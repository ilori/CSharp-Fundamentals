namespace Logger.Models
{
    using System;
    using Contracts;
    using Enums;

    public class Error : IError
    {
        public Error(DateTime dateTime, string message, ErrorLevel errorLevel)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.ErrorLevel = errorLevel;
        }

        public DateTime DateTime { get; }
        public string Message { get; }
        public ErrorLevel ErrorLevel { get; }
    }
}