public class Robot : IResidence
{
    public Robot(string id, string model)
    {
        Id = id;
        Model = model;
    }

    public string Id { get; set; }
    public string Model { get; set; }
    public string Name { get; set; }
    public string Birthdate { get; set; }
}