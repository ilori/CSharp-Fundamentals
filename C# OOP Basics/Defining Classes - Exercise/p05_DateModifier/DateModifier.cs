using System;
using System.Globalization;

public static class DateModifier
{
    public static int GetDifference(string startDate, string endDate)
    {
        var firstDate = DateTime.ParseExact(startDate, "yyyy MM dd", CultureInfo.InvariantCulture);
        var secondDate = DateTime.ParseExact(endDate, "yyyy MM dd", CultureInfo.InvariantCulture);

        var timeSpan = firstDate - secondDate;

        return Math.Abs(timeSpan.Days);
    }
}