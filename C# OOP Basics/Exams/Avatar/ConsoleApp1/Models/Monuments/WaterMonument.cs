using System.Text;

public class WaterMonument : Monument
{
    public WaterMonument(string name, int waterAffinity) : base(name)
    {
        WaterAffinity = waterAffinity;
    }

    public int WaterAffinity { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"###Water Monument: {this.Name}, Water Affinity: {this.WaterAffinity}");

        return sb.ToString().Trim();
    }
}