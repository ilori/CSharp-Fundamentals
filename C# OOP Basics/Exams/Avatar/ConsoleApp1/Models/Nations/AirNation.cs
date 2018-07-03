using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AirNation : Nation
{
    public AirNation() : base("Air")
    {
        this.AirBenders = new List<AirBender>();
        this.AirMonuments = new List<AirMonument>();
    }

    public List<AirBender> AirBenders { get; set; }
    public List<AirMonument> AirMonuments { get; set; }


    public override double TotalPower => this.NationTotalPower();

    public override double NationTotalPower()
    {
        var bendersPower = AirBenders.Sum(x => x.Power * x.AerialIntegrity);
        var monumentsAffinity = AirMonuments.Sum(x => x.AirAffinity);
        var totalPower = bendersPower += (bendersPower / 100) * monumentsAffinity;

        return totalPower;
    }

    public override void AssignBenders(Bender bender)
    {
        this.AirBenders.Add((AirBender) bender);
    }

    public override void AssignMonuments(Monument monument)
    {
        this.AirMonuments.Add((AirMonument) monument);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        var benders = this.AirBenders.Count > 0
            ? Environment.NewLine + string.Join(Environment.NewLine, this.AirBenders)
            : "None";
        var monuments = this.AirMonuments.Count > 0
            ? Environment.NewLine + string.Join(Environment.NewLine, this.AirMonuments)
            : "None";

        sb.AppendLine($"{this.Name} Nation").AppendLine($"Benders: {benders}").AppendLine($"Monuments: {monuments}");

        return sb.ToString().Trim();
    }

    public override void RemoveBinders()
    {
        this.AirBenders.Clear();
    }

    public override void RemoveMonuments()
    {
        this.AirMonuments.Clear();
    }
}