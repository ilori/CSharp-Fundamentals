namespace p09_DateTimeTests
{
    using System;
    using NUnit.Framework;
    using p09_DateTime;

    public class CustomDateTimeTests
    {
        [Test]
        public void NowShouldReturnCurrentDate()
        {
            CustomDateTime date = new CustomDateTime();

            DateTime expectedValue = DateTime.Now.Date;

            Assert.That(date.Now().Date, Is.EqualTo(expectedValue));
        }

        [Test]
        public void AddingADayToTheLastOneOfAMonthShouldResultInTheFirstDayOfTheNextMonth()
        {
            DateTime testDate = new DateTime(2000, 10, 31);
            DateTime expectedDate = new DateTime(2000, 11, 1);

            testDate = testDate.AddDays(1);

            Assert.That(expectedDate, Is.EqualTo(testDate));
        }
    }
}