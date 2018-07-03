public class Children
{
    public string Name { get; set; }

    public string Birthday { get; set; }

    public override string ToString()
    {
        return $"{Name} {Birthday}";
    }
}