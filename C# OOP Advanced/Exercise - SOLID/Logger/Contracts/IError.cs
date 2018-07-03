namespace Logger.Contracts
{
    using System;
    using Enums;

    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        ErrorLevel ErrorLevel { get; }
    }
}