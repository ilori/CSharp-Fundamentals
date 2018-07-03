namespace p02_ExtendedDatabase.Contracts
{
    public interface IPerson : IIdentifiable
    {
        string Username { get; }
    }
}