using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FireNation : Nation
{
    public FireNation() : base("Fire")
    {
        this.FireBenders = new List<FireBender>();
        this.FireMonuments = new List<FireMonument>();
    }

    public List<FireBender> FireBenders { get; set; }
    public List<FireMonument> FireMonuments { get; set; }


    public override double TotalPower => this.NationTotalPower();

    public override double NationTotalPower()
    {
        var bendersPower = FireBenders.Sum(x => x.Power * x.HeatAggression);
        var monumentsAffinity = FireMonuments.Sum(x => x.FireAffinity);
        var totalPower = bendersPower += (bendersPower / 100) * monumentsAffinity;

        return totalPower;
    }

    public override void AssignBenders(Bender bender)
    {
        this.FireBenders.Add((FireBender) bender);
    }

    public override void AssignMonuments(Monument monument)
    {
        this.FireMonuments.Add((FireMonument) monument);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        var benders = this.FireBenders.Count > 0
            ? Environment.NewLine + string.Join(Environment.NewLine, this.FireBenders)
            : "None";
        var monuments = this.FireMonuments.Count > 0
            ? Environment.NewLine + string.Join(Environment.NewLine, this.FireMonuments)
            : "None";

        sb.AppendLine($"{this.Name} Nation").AppendLine($"Benders: {benders}").AppendLine($"Monuments: {monuments}");

        return sb.ToString().Trim();
    }

    public override void RemoveBinders()
    {
        this.FireBenders.Clear();
    }

    public override void RemoveMonuments()
    {
        this.FireMonuments.Clear();
    }
}