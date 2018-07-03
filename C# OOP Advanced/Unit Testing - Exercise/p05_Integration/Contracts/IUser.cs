namespace p05_Integration
{
    using System.Collections.Generic;

    public interface IUser : INameable
    {
        IReadOnlyCollection<ICategory> Categories { get; }

        void AddCategory(ICategory category);

        void RemoveCategory(ICategory category);
    }
}