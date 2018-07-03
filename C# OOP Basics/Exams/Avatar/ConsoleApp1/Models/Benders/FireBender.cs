using System.Text;

public class FireBender : Bender
{
    public FireBender(string name, int power, double heatAggression) : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }

    public double HeatAggression { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"###Fire Bender: {this.Name}, Power: {this.Power}, Heat Aggression: {this.HeatAggression:F2}");
        return sb.ToString().Trim();
    }
}