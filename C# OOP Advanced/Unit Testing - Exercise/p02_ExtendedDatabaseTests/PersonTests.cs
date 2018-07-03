namespace p02_ExtendedDatabaseTests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;
    using p02_ExtendedDatabase.Models;

    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void TestValidConstructor()
        {
            var person = new Person(72, "Levski");

            Assert.That(person, Is.Not.EqualTo(null));
            Assert.That(person.Id, Is.EqualTo(72));
            Assert.That(person.Username, Is.EqualTo("Levski"));
        }

        [Test]
        public void TestPropertiesSetters()
        {
            Type personType = typeof(Person);

            PropertyInfo[] testProperies = personType
                .GetProperties()
                .Where(p => p.SetMethod.IsPublic)
                .ToArray();

            Assert.That(testProperies.Length, Is.EqualTo(0));
        }
    }
}