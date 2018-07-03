namespace p09_DateTime
{
    using System;

    public class CustomDateTime : IDateTime
    {
        public void AddDays(DateTime date, double daysToAdd)
        {
            DateTime dateTime = date.AddDays(daysToAdd);
        }

        public DateTime Now() => DateTime.Now;

        public TimeSpan SubstractDays(DateTime date, int daysToSybstract)
            => date.Subtract(DateTime.Parse($"{daysToSybstract}", System.Globalization.CultureInfo.InvariantCulture));
    }
}