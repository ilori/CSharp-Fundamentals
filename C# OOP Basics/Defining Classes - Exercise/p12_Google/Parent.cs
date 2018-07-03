public class Parent
{
    public string Name { get; set; }

    public string Birthday { get; set; }

    public override string ToString()
    {
        return $"{Name} {Birthday}";
    }
}