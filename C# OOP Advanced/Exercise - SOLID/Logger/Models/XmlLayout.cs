namespace Logger.Models
{
    using System;
    using System.Globalization;
    using Contracts;

    public class XmlLayout : ILayout
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        private readonly string format =
            "<log>" + Environment.NewLine +
            "\t<date>{0}</date>" + Environment.NewLine +
            "\t<level>{1}</level>" + Environment.NewLine +
            "\t<message>{2}</message>" + Environment.NewLine +
            "</log>" + Environment.NewLine;

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);

            string formattedError = string.Format(format, dateString, error.ErrorLevel.ToString(), error.Message);

            return formattedError;
        }
    }
}