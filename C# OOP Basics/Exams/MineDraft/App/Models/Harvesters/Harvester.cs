using System;
using System.Text;

public abstract class Harvester : IIdentifiable
{
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public virtual string Type { get; protected set; }

    public string Id { get; private set; }

    public double OreOutput
    {
        get => this.oreOutput;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's OreOutput");
            }

            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get => this.energyRequirement;
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's EnergyRequirement");
            }

            this.energyRequirement = value;
        }
    }


    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.Type} Harvester - {this.Id}").AppendLine($"Ore Output: {this.OreOutput}")
            .AppendLine($"Energy Requirement: {this.EnergyRequirement}");

        return sb.ToString().Trim();
    }
}