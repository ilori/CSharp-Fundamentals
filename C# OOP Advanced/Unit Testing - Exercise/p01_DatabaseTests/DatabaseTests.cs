namespace p01_DatabaseTests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;
    using p01_Database;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new[] {1, 1, 2, 4, 5, 6})]
        [TestCase(new int[] { })]
        [TestCase(new[] {-6, -7})]
        [TestCase(new[] {0, 16})]
        public void TestValidConstructor(int[] values)
        {
            Database db = new Database(values);

            Type type = typeof(Database);

            FieldInfo info = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.FieldType == typeof(int[]));

            int[] actualValues = ((int[]) info.GetValue(db)).Take(values.Length).ToArray();

            Assert.That(actualValues, Is.EquivalentTo(values));
        }

        [Test]
        public void TestInvalidConstructor()
        {
            int[] testValues = new int[20];

            Assert.That(() => new Database(testValues),
                Throws.InvalidOperationException);
        }

        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [TestCase(-20)]
        [TestCase(-159)]
        [TestCase(1)]
        public void TestAddMethodValid(int value)
        {
            Database db = new Database();

            db.Add(value);

            Type type = typeof(Database);

            FieldInfo valuesInfo = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.FieldType == typeof(int[]));

            FieldInfo currentIndexInfo = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.FieldType == typeof(int));

            int currnetIndex = (int) currentIndexInfo.GetValue(db);

            int actualValue = ((int[]) valuesInfo.GetValue(db)).Take(currnetIndex).Last();

            Assert.That(actualValue, Is.EqualTo(value));
        }

        [Test]
        public void TestInvalidAddMethod()
        {
            Database db = new Database();

            Type type = typeof(Database);

            FieldInfo currentIndexInfo = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.FieldType == typeof(int));

            currentIndexInfo.SetValue(db, 16);

            Assert.That(() => db.Add(1),
                Throws.InvalidOperationException);
        }

        [TestCase(new[] {1, 1, 2, 4, 5, 6})]
        [TestCase(new[] {-6, -7})]
        [TestCase(new[] {0, 16})]
        public void TestValidRemoveMethod(int[] values)
        {
            Database db = new Database();

            FieldInfo valuesInfo = typeof(Database).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.FieldType == typeof(int[]));

            FieldInfo currentIndexInfo = typeof(Database).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.FieldType == typeof(int));

            valuesInfo.SetValue(db, values);

            currentIndexInfo.SetValue(db, values.Length);

            int currentIndex = (int) currentIndexInfo.GetValue(db) - 1;

            int[] currentArray = (int[]) valuesInfo.GetValue(db);

            db.Remove();

            int[] actualArray = currentArray.Take(currentIndex).ToArray();

            Assert.That(currentIndex, Is.EqualTo(actualArray.Length));
        }

        [Test]
        public void TestInvalidRemoveMehod()
        {
            Database db = new Database();

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [TestCase(new[] {1, 1, 2, 4, 5, 6})]
        [TestCase(new[] {-6, -7})]
        [TestCase(new[] {0, 16})]
        public void TestValidFetchMethod(int[] values)
        {
            Database db = new Database(values);

            Assert.That(db.Fetch(),Is.EqualTo(values));
        }
    }
}