namespace p02_ExtendedDatabaseTests
{
    using System;
    using NUnit.Framework;
    using p02_ExtendedDatabase.Contracts;
    using p02_ExtendedDatabase.Models;
    using p02_ExtendedDatabase.Repository;

    public class DatabaseTests
    {
        [Test]
        public void DatabaseAddPerson()
        {
            Database db = new Database();

            Person person = new Person(111, "Test");

            db.Add(person);

            Assert.That(db.Count, Is.EqualTo(1));
        }

        [Test]
        [TestCase(7, "Levski", 7, "Levski")]
        [TestCase(2, "Litex", 2, "Litex")]
        [TestCase(992016, "Rip", 992016, "Rip")]
        public void TestInvalidDatabaseAddMethod(int firstPersonId, string firstPersonUsername, int secondPersonId,
            string secondPersonUsername)
        {
            Database db = new Database();

            var firstPerson = new Person(firstPersonId, firstPersonUsername);
            var secondPerson = new Person(secondPersonId, secondPersonUsername);

            db.Add(firstPerson);

            Assert.That(() => db.Add(secondPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void TestRemovePersonMethod()
        {
            Database db = new Database();

            Person firstPerson = new Person(7, "Levski");

            Person secondPerson = new Person(2, "Litex");


            db.Add(firstPerson);

            db.Add(secondPerson);


            db.Remove(firstPerson);

            db.Remove(secondPerson);

            Assert.That(db.Count, Is.EqualTo(0));
        }

        [TestCase(1, "1", 2, "2", 3, "3", 3)]
        [TestCase(5, "5", 7, "7", 4, "4", 5)]
        [TestCase(11, "11", 12, "12", 13, "13", 12)]
        public void TestValidFindByIdMethod(int firstPersonId, string firstPersonUsername, int secondPersonId,
            string secondPersonUsername,
            int thirdPersonId,
            string thirdPersonUsername, int idToSearch)
        {
            Database db = new Database();

            IPerson firstPerson = new Person(firstPersonId, firstPersonUsername);
            IPerson secondPerson = new Person(secondPersonId, secondPersonUsername);
            IPerson thirdPerson = new Person(thirdPersonId, thirdPersonUsername);

            db.Add(firstPerson);
            db.Add(secondPerson);
            db.Add(thirdPerson);


            IPerson keyPerson = db.Find(idToSearch);

            Assert.That(keyPerson.Id, Is.EqualTo(idToSearch));
        }

        [Test]
        [TestCase(1, "1", 2, "2", 3, "3", "1")]
        [TestCase(1, "1", 2, "2", 3, "3", "2")]
        [TestCase(1, "1", 2, "2", 3, "3", "3")]
        public void TestFindByUsernameMethod(int firstPersonId, string firstPersonUsername, int secondPersonId,
            string secondPersonUsername,
            int thirdPersonId, string thirdPersonUsername, string usernameToSearch)
        {
            Database db = new Database();

            IPerson firstPerson = new Person(firstPersonId, firstPersonUsername);
            IPerson secondPerson = new Person(secondPersonId, secondPersonUsername);
            IPerson thirdPerson = new Person(thirdPersonId, thirdPersonUsername);

            db.Add(firstPerson);
            db.Add(secondPerson);
            db.Add(thirdPerson);

            IPerson keyPerson = db.Find(usernameToSearch);

            Assert.That(keyPerson.Username, Is.EqualTo(usernameToSearch));
        }

        [Test]
        public void TestInvalidFindByIdMethod()
        {
            Database db = new Database();

            db.Add(new Person(1, "Litex"));

            Assert.Throws<InvalidOperationException>(() => db.Find(2));
        }

        [Test]
        public void TestInvalidId()
        {
            Database db = new Database();

            Assert.Throws<ArgumentOutOfRangeException>(() => db.Find(-1));
        }
    }
}