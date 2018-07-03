public class Car
{
    public string Model { get; set; }

    public double Speed { get; set; }

    public override string ToString()
    {
        return $"{Model} {Speed}";
    }
}