using System;
using System.Text;

public abstract class Provider : IIdentifiable
{
    private double energyOutput;

    protected Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public virtual string Type { get; protected set; }


    public string Id { get; private set; }

    public double EnergyOutput
    {
        get => this.energyOutput;
        protected set
        {
            if (value < 0 || value > 9999)
            {
                throw new ArgumentException($"Provider is not registered, because of it's EnergyOutput");
            }

            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.Type} Provider - {this.Id}").AppendLine($"Energy Output: {this.EnergyOutput}");

        return sb.ToString().Trim();
    }
}