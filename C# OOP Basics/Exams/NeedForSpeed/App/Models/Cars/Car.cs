using System;

public abstract class Car
{
    protected Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension,
        int durability)
    {
        Brand = brand;
        Model = model;
        YearOfProduction = yearOfProduction;
        Horsepower = horsepower;
        Acceleration = acceleration;
        Suspension = suspension;
        Durability = durability;
    }

    public string Brand { get; private set; }

    public string Model { get; private set; }

    public int YearOfProduction { get; private set; }

    public int Horsepower { get; set; }

    public int Acceleration { get; private set; }

    public int Suspension { get; set; }

    public int Durability { get; set; }

    public int OverallPerformance => (this.Horsepower / Acceleration) + (this.Suspension + this.Durability);

    public int EnginePerformance => this.Horsepower / this.Acceleration;

    public int SuspensionPerformance => this.Suspension + this.Durability;


    public override string ToString()
    {
        return
            $"{Brand} {Model} {YearOfProduction}{Environment.NewLine}" +
            $"{Horsepower} HP, 100 m/h in {Acceleration} s{Environment.NewLine}" +
            $"{Suspension} Suspension force, {Durability} Durability{Environment.NewLine}";
    }
}