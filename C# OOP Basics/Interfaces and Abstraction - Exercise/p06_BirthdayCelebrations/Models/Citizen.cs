public class Citizen : IResidence
{
    public Citizen(string name, int age, string id, string birthDate)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birthDate;
    }

    public string Name { get; set; }
    public string Birthdate { get; set; }
    public string Id { get; set; }
    public int Age { get; set; }
    public string Model { get; set; }
}