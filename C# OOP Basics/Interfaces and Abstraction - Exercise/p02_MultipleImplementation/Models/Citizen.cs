public class Citizen : IPerson
{
    public Citizen(string name, int age, string id, string birthDate)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birthDate;
    }

    public string Name { get; }
    public int Age { get; }
    public string Id { get; }
    public string Birthdate { get; }
}