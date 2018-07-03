public class Truck : IVehicle
{
    private const double AirConditioner = 1.6;

    public Truck(double fuelQuantity, double fuelConsumption)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
    }

    public double FuelQuantity { get; private set; }
    public double FuelConsumption { get; }

    public string Drive(double distance)
    {
        var fuelNeeded = this.FuelConsumption * distance + AirConditioner * distance;
        if (this.FuelQuantity - fuelNeeded >= 0)
        {
            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";
        }
        else
        {
            return $"{this.GetType().Name} needs refueling";
        }
    }

    public void Refuel(double liters)
    {
        this.FuelQuantity += liters * 0.95;
    }
}