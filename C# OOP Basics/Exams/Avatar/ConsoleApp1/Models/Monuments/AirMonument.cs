using System.Text;

public class AirMonument : Monument
{
    public AirMonument(string name, int airAffinity) : base(name)
    {
        AirAffinity = airAffinity;
    }

    public int AirAffinity { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"###Air Monument: {this.Name}, Air Affinity: {this.AirAffinity}");

        return sb.ToString().Trim();
    }
}