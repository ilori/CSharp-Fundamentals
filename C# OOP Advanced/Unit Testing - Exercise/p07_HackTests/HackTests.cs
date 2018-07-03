namespace p07_HackTests
{
    using Moq;
    using NUnit.Framework;
    using p07_Hack;

    public class HackTests
    {
        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(-4)]
        [TestCase(6)]
        [TestCase(7)]
        public void MathAbsMethodShouldReturnTheAbsoluteValueOfANumber(int value)
        {
            
        }
    }
}