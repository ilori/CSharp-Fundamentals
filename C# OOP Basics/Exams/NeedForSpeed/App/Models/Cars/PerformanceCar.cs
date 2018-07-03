using System.Collections.Generic;

public class PerformanceCar : Car
{
    private const double HorsePowerIncrease = 0.5;
    private const double SuspensionDecrease = 0.25;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration,
        int suspension, int durability) : base(brand, model, yearOfProduction, horsepower, acceleration, suspension,
        durability)
    {
        this.Horsepower += (int) (base.Horsepower * HorsePowerIncrease);
        this.Suspension -= (int) (base.Suspension * SuspensionDecrease);
        this.AddOns = new List<string>();
    }

    public List<string> AddOns { get; set; }


    public override string ToString()
    {
        var sb = base.ToString();

        var areThereAddons = this.AddOns.Count > 0 ? string.Join(", ", this.AddOns) : "None";

        sb += "Add-ons: " + areThereAddons;

        return sb;
    }
}