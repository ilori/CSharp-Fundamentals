using System.Text;

public class EarthBender : Bender
{
    public EarthBender(string name, int power, double groundSaturation) : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public double GroundSaturation { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"###Earth Bender: {this.Name}, Power: {this.Power}, Ground Saturation: {this.GroundSaturation:F2}");
        return sb.ToString().Trim();

    }
}