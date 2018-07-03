namespace p02_ExtendedDatabase.Models
{
    using Contracts;

    public class Person : IPerson
    {
        public Person(int id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public int Id { get; private set; }
        public string Username { get; private set; }
    }
}