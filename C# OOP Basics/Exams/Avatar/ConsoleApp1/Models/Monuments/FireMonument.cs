using System.Text;

public class FireMonument : Monument
{
    public FireMonument(string name, int fireAffinity) : base(name)
    {
        FireAffinity = fireAffinity;
    }

    public int FireAffinity { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"###Fire Monument: {this.Name}, Fire Affinity: {this.FireAffinity}");

        return sb.ToString().Trim();
    }
}