namespace Logger.Factories
{
    using System;
    using System.Globalization;
    using Contracts;
    using Enums;
    using Models;

    public class ErrorFactory
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public IError CreateError(string dateTimeString, string errorLevelString, string message)
        {
            DateTime dateTime = DateTime.ParseExact(dateTimeString, DateFormat, CultureInfo.InvariantCulture);

            ErrorLevel errorLevel = ErrorLevelParser(errorLevelString);

            IError error = new Error(dateTime, message, errorLevel);

            return error; 
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