public class Pet : IResidence
{
    public Pet(string name, string birthdate)
    {
        Name = name;
        Birthdate = birthdate;
    }

    public string Name { get; set; }
    public string Birthdate { get; set; }
    public string Id { get; set; }
    public string Model { get; set; }
}