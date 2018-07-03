public class Car
{
    public string Model { get; set; }

    public decimal FuelAmount { get; set; }

    public decimal FuelConsumption { get; set; }

    public decimal DistanceTraveled { get; set; }


    public override string ToString()
    {
        return $"{this.Model} {this.FuelAmount:F2} {this.DistanceTraveled}";
    }
}