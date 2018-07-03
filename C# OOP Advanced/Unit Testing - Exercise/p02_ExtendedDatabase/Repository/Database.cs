namespace p02_ExtendedDatabase.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Database
    {
        private readonly HashSet<IPerson> people;

        public Database()
        {
            this.people = new HashSet<IPerson>();
        }

        public Database(IEnumerable<IPerson> people)
            : this()
        {
            if (people != null)
            {
                foreach (var person in people)
                {
                    this.Add(person);
                }
            }
        }

        public int Count => this.people.Count;

        public void Add(IPerson person)
        {
            if (this.people.Any(p => p.Id == person.Id || p.Username == person.Username))
            {
                throw new InvalidOperationException();
            }

            this.people.Add(person);
        }

        public void Remove(IPerson person)
        {
            this.people.RemoveWhere(p => p.Id == person.Id && p.Username == person.Username);
        }

        public IPerson Find(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            IPerson person = this.people.FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                throw new InvalidOperationException();
            }

            return person;
        }

        public IPerson Find(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException();
            }

            IPerson person = this.people.FirstOrDefault(p => p.Username == username);

            if (person == null)
            {
                throw new InvalidOperationException();
            }

            return person;
        }
    }
}