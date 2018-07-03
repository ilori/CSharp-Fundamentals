namespace p05_Integration
{
    using System.Collections.Generic;

    public interface ICategory : INameable
    {
        IReadOnlyCollection<IUser> Users { get; }

        void AddUser(IUser user);
    }
}