using System.Text;

public class EarthMonument : Monument
{
    public EarthMonument(string name, int earthAffinity) : base(name)
    {
        EarthAffinity = earthAffinity;
    }

    public int EarthAffinity { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"###Earth Monument: {this.Name}, Earth Affinity: {this.EarthAffinity}");

        return sb.ToString().Trim();
    }
}