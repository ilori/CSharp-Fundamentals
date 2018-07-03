namespace p05_IntegrationTests
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using p05_Integration;
    using p05_Integration.Models;

    public class IntegrationTests
    {
        [TestCase(10)]
        [TestCase(50)]
        [TestCase(51)]
        [TestCase(1)]
        public void TestValidUserAddCategoryMethod(int count)
        {
            User user = new User("LEVSKI");

            for (int i = 0; i < count; i++)
            {
                user.AddCategory(new Category($"{i}TestCategory"));
            }

            Assert.That(user.Categories.Count, Is.EqualTo(count));
        }

        [Test]
        public void TestInvalidUserAddCategoryMethod()
        {
            User user = new User("LEVSKI");

            Assert.That(() => user.AddCategory(null), Throws.ArgumentNullException);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void TestValidUserRemoveCategoryMethod(int index)
        {
            const int count = 10;

            User user = new User("LEVSKI");

            List<ICategory> categories = new List<ICategory>();

            for (int i = 0; i < count; i++)
            {
                ICategory category = new Category($"{i}Test");

                user.AddCategory(category);

                categories.Add(category);
            }

            int currentCount = user.Categories.Count;

            user.RemoveCategory(categories[index]);

            Assert.That(user.Categories.Count, Is.EqualTo(currentCount - 1));
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(51)]
        [TestCase(1)]
        public void TestValidCategoryAddUserMethod(int count)
        {
            Category category = new Category("LEVSKI");

            for (int i = 0; i < count; i++)
            {
                category.AddUser(new User($"{i}TestCategory"));
            }

            Assert.That(category.Users.Count, Is.EqualTo(count));
        }
    }
}