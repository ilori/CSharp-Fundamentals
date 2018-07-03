﻿using System.Text;

public class AirBender : Bender
{
    public AirBender(string name, int power, double aerialIntegrity) : base(name, power)
    {
        this.AerialIntegrity = aerialIntegrity;
    }

    public double AerialIntegrity { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"###Air Bender: {this.Name}, Power: {this.Power}, Aerial Integrity: {this.AerialIntegrity:F2}");
        return sb.ToString().Trim();

    }
}