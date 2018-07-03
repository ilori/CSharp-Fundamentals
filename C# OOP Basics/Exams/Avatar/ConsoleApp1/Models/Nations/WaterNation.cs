namespace ConsoleApp1.Models.Nations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class WaterNation : Nation
    {
        public WaterNation() : base("Water")
        {
            this.WaterBenders = new List<WaterBender>();
            this.WaterMonuments = new List<WaterMonument>();
        }

        public List<WaterBender> WaterBenders { get; set; }
        public List<WaterMonument> WaterMonuments { get; set; }

        public override double TotalPower => this.NationTotalPower();

        public override double NationTotalPower()
        {
            var bendersPower = WaterBenders.Sum(x => x.Power * x.WaterClarity);
            var monumentsAffinity = WaterMonuments.Sum(x => x.WaterAffinity);
            var totalPower = bendersPower += (bendersPower / 100) * monumentsAffinity;

            return totalPower;
        }

        public override void AssignBenders(Bender bender)
        {
            this.WaterBenders.Add((WaterBender) bender);
        }

        public override void AssignMonuments(Monument monument)
        {
            this.WaterMonuments.Add((WaterMonument) monument);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var benders = this.WaterBenders.Count > 0
                ? Environment.NewLine + string.Join(Environment.NewLine, this.WaterBenders)
                : "None";
            var monuments = this.WaterMonuments.Count > 0
                ? Environment.NewLine + string.Join(Environment.NewLine, this.WaterMonuments)
                : "None";

            sb.AppendLine($"{this.Name} Nation").AppendLine($"Benders: {benders}")
                .AppendLine($"Monuments: {monuments}");

            return sb.ToString().Trim();
        }

        public override void RemoveBinders()
        {
            this.WaterBenders.Clear();
        }

        public override void RemoveMonuments()
        {
            this.WaterMonuments.Clear();
        }
    }
}