using System;

namespace p03_ListIteratorTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;
    using p03_ListIterator;

    public class ListIteratorTests
    {
        [TestCase("Levski", "Litex", "7", "2")]
        [TestCase("Levski", "Litex", "7", "1")]
        [TestCase("SAMO", "LEVSKI")]
        [TestCase("LEVSKI")]
        public void TestValidConstructor(params string[] values)
        {
            ListIterator iterator = new ListIterator(values);

            Assert.That(() => iterator.InitializeComponents(values), !Throws.ArgumentNullException);
        }

        [Test]
        public void TestInvalidConstructor()
        {
            ListIterator iterator = new ListIterator();

            Assert.That(() => iterator.InitializeComponents(null), Throws.ArgumentNullException);
        }

        [TestCase("Levski", "Litex", "7", "2")]
        [TestCase("Levski", "Litex", "7", "1")]
        [TestCase("SAMO", "LEVSKI")]
        public void TestValidMoveMethod(params string[] values)
        {
            ListIterator iter = new ListIterator(values);

            Assert.That(() => iter.Move(), Is.EqualTo(true));
        }

        [Test]
        public void TestInvalidMoveMethod()
        {
            ListIterator iter = new ListIterator();

            Assert.That(() => iter.Move(), Is.EqualTo(false));
        }


        [TestCase("Levski", "Litex", "7", "2")]
        [TestCase("Levski", "Litex", "7", "1")]
        public void TestValidHasNextMethod(params string[] values)
        {
            ListIterator iter = new ListIterator(values);

            iter.Move();
            iter.Move();

            Assert.That(() => iter.HasNext(), Is.EqualTo(true));
        }

        [TestCase("Levski", "Litex", "7", "2")]
        [TestCase("Levski", "Litex", "7", "1")]
        public void TestInvalidHasNextMethod(params string[] values)
        {
            ListIterator iter = new ListIterator(values);

            iter.Move();
            iter.Move();
            iter.Move();

            Assert.That(() => iter.HasNext(), Is.EqualTo(false));
        }

        [TestCase("Levski", "Litex", "7", "2")]
        public void TestValidPrintMethod(params string[] values)
        {
            ListIterator iter = new ListIterator(values);

            FieldInfo listInfo = typeof(ListIterator).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.FieldType == typeof(List<string>));

            List<string> list = (List<string>) listInfo.GetValue(iter);

            FieldInfo indexInfo = typeof(ListIterator).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.FieldType == typeof(int));


            iter.Move();
            iter.Move();

            int currentIndex = (int) indexInfo.GetValue(iter);

            Assert.That(list[currentIndex], Is.EqualTo("7"));
        }
    }
}