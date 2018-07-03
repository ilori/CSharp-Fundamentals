namespace p07_EqualityLogic
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; }

        public int Age { get; }

        public int CompareTo(Person other)
        {
            if (string.Compare(this.Name, other.Name, StringComparison.InvariantCulture) != 0)
            {
                return string.Compare(this.Name, other.Name, StringComparison.InvariantCulture);
            }

            return this.Age.CompareTo(other.Age);
        }


        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Age.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Person other = (Person) obj;

            if (other == null)
            {
                return false;
            }

            return this.Age == other.Age && this.Name == other.Name;
        }
    }
}