namespace p05_Integration.Models
{
    using System;
    using System.Collections.Generic;

    public class Category : ICategory
    {
        private readonly List<IUser> users;

        public Category(string name)
        {
            this.Name = name;
            this.users = new List<IUser>();
        }

        public string Name { get; }

        public IReadOnlyCollection<IUser> Users => this.users;

        public void AddUser(IUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException($"User cannot be null!");
            }

            this.users.Add(user);
            user.AddCategory(this);
        }
    }
}