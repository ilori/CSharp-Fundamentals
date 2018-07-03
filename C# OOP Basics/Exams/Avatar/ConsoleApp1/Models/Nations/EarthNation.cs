namespace ConsoleApp1.Models.Nations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class EarthNation : Nation
    {
        public EarthNation() : base("Earth")
        {
            this.EarthBenders = new List<EarthBender>();
            this.EarthMonuments = new List<EarthMonument>();
        }

        public List<EarthBender> EarthBenders { get; set; }
        public List<EarthMonument> EarthMonuments { get; set; }

        public override double TotalPower => this.NationTotalPower();

        public override double NationTotalPower()
        {
            var bendersPower = EarthBenders.Sum(x => x.Power * x.GroundSaturation);
            var monumentsAffinity = EarthMonuments.Sum(x => x.EarthAffinity);
            var totalPower = bendersPower += (bendersPower / 100) * monumentsAffinity;

            return totalPower;
        }

        public override void AssignBenders(Bender bender)
        {
            this.EarthBenders.Add((EarthBender) bender);
        }

        public override void AssignMonuments(Monument monument)
        {
            this.EarthMonuments.Add((EarthMonument) monument);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var benders = this.EarthBenders.Count > 0
                ? Environment.NewLine + string.Join(Environment.NewLine, this.EarthBenders)
                : "None";
            var monuments = this.EarthMonuments.Count > 0
                ? Environment.NewLine + string.Join(Environment.NewLine, this.EarthMonuments)
                : "None";

            sb.AppendLine($"{this.Name} Nation").AppendLine($"Benders: {benders}")
                .AppendLine($"Monuments: {monuments}");

            return sb.ToString().Trim();
        }
        public override void RemoveBinders()
        {
            this.EarthBenders.Clear();
        }

        public override void RemoveMonuments()
        {
            this.EarthMonuments.Clear();
        }
    }
}