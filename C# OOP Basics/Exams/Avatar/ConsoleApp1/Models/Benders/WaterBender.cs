using System.Text;

public class WaterBender : Bender
{
    public WaterBender(string name, int power, double waterClarity) : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    public double WaterClarity { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"###Water Bender: {this.Name}, Power: {this.Power}, Water Clarity: {this.WaterClarity:F2}");
        return sb.ToString().Trim();

    }
}