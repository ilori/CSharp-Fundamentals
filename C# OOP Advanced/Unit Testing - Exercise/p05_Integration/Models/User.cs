namespace p05_Integration.Models
{
    using System;
    using System.Collections.Generic;

    public class User : IUser
    {
        private readonly List<ICategory> categories;

        public User(string name)
        {
            this.Name = name;
            this.categories = new List<ICategory>();
        }


        public string Name { get; }

        public IReadOnlyCollection<ICategory> Categories => this.categories;

        public void AddCategory(ICategory category)
        {
            if (category == null)
            {
                throw new ArgumentNullException($"Category cannot be null!");
            }

            this.categories.Add(category);
        }

        public void RemoveCategory(ICategory category)
        {
            if (category == null)
            {
                throw new ArgumentNullException($"Category cannot be null!");
            }

            this.categories.Remove(category);
        }
    }
}